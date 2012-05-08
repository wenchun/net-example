// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Globalization;
using System.Reflection;
using System.Data.Metadata.Edm;
using System.CodeDom;
using System.Data.Objects.DataClasses;
using System.Xml;

namespace EFLazyClassGen
{
    class Program
    {
        static string GetClrType(EdmProperty prop)
        {
            PrimitiveType pt = prop.TypeUsage.EdmType as PrimitiveType;
            if (pt != null)
            {
                string nullableSuffix = (prop.Nullable && pt.ClrEquivalentType.IsValueType) ? "?" : "";
                
                return pt.ClrEquivalentType.Name + nullableSuffix;
            }

            return prop.TypeUsage.EdmType.NamespaceName + "." + prop.TypeUsage.EdmType.Name;
        }

        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: EFLazyClassGen input.[csdl|edmx] output.cs");
                return 1;
            }

            try
            {
                string incsdl = args[0];
                string outobjectlayer = args[1];

                EdmItemCollection itemCollection;

                if (Path.GetExtension(incsdl) == ".edmx")
                {
                    XElement edmx = XElement.Load(incsdl);
                    XNamespace csdlNamespace = "http://schemas.microsoft.com/ado/2007/06/edmx";
                    XElement firstCSDL = edmx.Descendants(csdlNamespace + "ConceptualModels").First().Descendants().First();
                    itemCollection = new EdmItemCollection(new XmlReader[] { firstCSDL.CreateReader() });
                }
                else
                {
                    itemCollection = new EdmItemCollection(incsdl);
                }

                using (StreamWriter output = new StreamWriter(outobjectlayer))
                {
                    SourceWriter sourceWriter = new SourceWriter(output);

                    // detect schema namespace from the first entity type (containers don't have namespaces!)
                    EntityType firstEntityType = itemCollection.GetItems<EntityType>().FirstOrDefault();
                    if (firstEntityType == null)
                        throw new InvalidOperationException("Schema must have at least one EntityType");

                    sourceWriter.Variables["schemaNamespace"] = firstEntityType.NamespaceName;

                    WriteAssociationTypes(itemCollection, sourceWriter);

                    sourceWriter.WriteLine(@"[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]");
                    sourceWriter.WriteLine();
                    sourceWriter.WriteLine("namespace {schemaNamespace}");
                    using (sourceWriter.Indent())
                    {
                        sourceWriter.WriteLine("using System;");
                        sourceWriter.WriteLine("using System.Data.Objects.DataClasses;");
                        sourceWriter.WriteLine("using Microsoft.Data.EFLazyLoading;");

                        WriteEntityContainers(itemCollection, sourceWriter);
                        WriteEntityTypes(itemCollection, sourceWriter);
                        WriteComplexTypes(itemCollection, sourceWriter);
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: {0}", ex);
                return 1;
            }
        }

        private static void WriteComplexTypes(EdmItemCollection itemCollection, SourceWriter sourceWriter)
        {
            foreach (ComplexType complexType in itemCollection.GetItems<ComplexType>())
            {
                WriteComplexType(sourceWriter, complexType);
            }
        }

        private static void WriteComplexType(SourceWriter sourceWriter, ComplexType complexType)
        {
            sourceWriter.Variables["complexTypeName"] = complexType.Name;
            sourceWriter.Variables["complexTypeNamespace"] = complexType.NamespaceName;

            sourceWriter.WriteLine("[EdmComplexType(NamespaceName=\"{complexTypeNamespace}\", Name=\"{complexTypeName}\")]");
            sourceWriter.WriteLine("public class {complexTypeName} : ComplexObject");
            using (sourceWriter.Indent())
            {
                foreach (EdmProperty prop in complexType.Properties)
                {
                    sourceWriter.Variables["propertyName"] = prop.Name;
                    sourceWriter.Variables["propertyType"] = GetClrType(prop);
                    sourceWriter.WriteLine("private {propertyType} _{propertyName};");
                }
                sourceWriter.WriteLine();
                foreach (EdmProperty prop in complexType.Properties)
                {
                    sourceWriter.Variables["propertyName"] = prop.Name;
                    sourceWriter.Variables["propertyType"] = GetClrType(prop);
                    sourceWriter.Variables["isNullable"] = prop.Nullable ? "true" : "false";
                    sourceWriter.WriteLine("[EdmScalarProperty(IsNullable={isNullable})]");
                    sourceWriter.WriteLine("public {propertyType} {propertyName}");
                    using (sourceWriter.Indent())
                    {
                        sourceWriter.WriteLine("get { return _{propertyName}; }");
                        sourceWriter.WriteLine("set");
                        using (sourceWriter.Indent())
                        {
                            sourceWriter.WriteLine("ReportPropertyChanging(\"{propertyName}\");");
                            sourceWriter.WriteLine("_{propertyName} = value;");
                            sourceWriter.WriteLine("ReportPropertyChanged(\"{propertyName}\");");
                        }
                    }
                }
            }
        }

        private static void WriteEntityTypes(EdmItemCollection itemCollection, SourceWriter sourceWriter)
        {
            foreach (EntityType entityType in itemCollection.GetItems<EntityType>())
            {
                WriteEntityType(sourceWriter, entityType);
            }
        }

        private static void WriteEntityType(SourceWriter sourceWriter, EntityType entityType)
        {
            sourceWriter.Variables["entityTypeName"] = entityType.Name;
            sourceWriter.Variables["entityTypeNamespace"] = entityType.NamespaceName;
            sourceWriter.Variables["baseClassName"] = entityType.BaseType != null ? entityType.BaseType.Name : "LazyEntityObject";
            sourceWriter.Variables["baseDataClassName"] = entityType.BaseType != null ? (" : " + entityType.BaseType.Name + ".Data") : "";
            if (sourceWriter.Variables["baseDataClassName"] != "")
                sourceWriter.Variables["baseDataClassName"] += ", ILazyEntityDataObject";
            else
                sourceWriter.Variables["baseDataClassName"] += ": ILazyEntityDataObject";

            sourceWriter.Variables["optionalAbstract"] = entityType.Abstract ? "abstract " : "";
            sourceWriter.Variables["optionalNew"] = entityType.BaseType != null ? "new " : "";

            sourceWriter.WriteLine(@"[EdmEntityType(NamespaceName=""{entityTypeNamespace}"", Name=""{entityTypeName}"")]");
            sourceWriter.WriteLine("public {optionalAbstract}partial class {entityTypeName} : {baseClassName}");
            using (sourceWriter.Indent())
            {
                WriteDataClass(sourceWriter, entityType);

                sourceWriter.WriteLine("protected override ILazyEntityDataObject CreateDataObject() { return new Data(); }");

                foreach (EdmProperty prop in entityType.Properties.Where(c => c.DeclaringType == entityType).Where(prop => entityType.KeyMembers.Contains(prop)))
                {
                    using (sourceWriter.NewVariableScope())
                    {
                        sourceWriter.Variables["propertyType"] = GetClrType(prop);
                        sourceWriter.Variables["propertyName"] = prop.Name;
                        sourceWriter.WriteLine("private {propertyType} _{propertyName};");
                    }
                }

                foreach (EdmProperty prop in entityType.Properties.Where(c => c.DeclaringType == entityType))
                {
                    using (sourceWriter.NewVariableScope())
                    {
                        sourceWriter.Variables["propertyType"] = GetClrType(prop);
                        sourceWriter.Variables["propertyName"] = prop.Name;
                        bool isKey = entityType.KeyMembers.Contains(prop);

                        sourceWriter.Variables["isKey"] = isKey ? "true" : "false";
                        sourceWriter.Variables["isNullable"] = prop.Nullable ? "true" : "false";

                        sourceWriter.WriteLine();
                        if (prop.TypeUsage.EdmType is PrimitiveType)
                        {
                            sourceWriter.WriteLine("[EdmScalarProperty(EntityKeyProperty={isKey}, IsNullable={isNullable})]");
                        }
                        else if (prop.TypeUsage.EdmType is ComplexType)
                        {
                            sourceWriter.WriteLine("[EdmComplexProperty]");
                        }
                        else
                            throw new NotSupportedException("Invalid property type");

                        sourceWriter.WriteLine("public {propertyType} {propertyName}");
                        using (sourceWriter.Indent())
                        {
                            sourceWriter.WriteLine("get { return Data.{propertyName}Property.Get(this); }");
                            sourceWriter.WriteLine("set { Data.{propertyName}Property.Set(this, value); }");
                        }

                    }
                }

                foreach (NavigationProperty navprop in entityType.NavigationProperties.Where(c => c.DeclaringType == entityType))
                {
                    using (sourceWriter.NewVariableScope())
                    {
                        sourceWriter.Variables["propertyName"] = navprop.Name;
                        sourceWriter.Variables["associationNamespace"] = navprop.RelationshipType.NamespaceName;
                        sourceWriter.Variables["associationName"] = navprop.RelationshipType.Name;
                        sourceWriter.Variables["relatedEndName"] = navprop.ToEndMember.Name;
                        string itemType = ((RefType)navprop.ToEndMember.TypeUsage.EdmType).ElementType.FullName;
                        if (navprop.ToEndMember.RelationshipMultiplicity == RelationshipMultiplicity.Many)
                        {
                            itemType = "LazyEntityCollection<" + itemType + ">";
                        }
                        sourceWriter.Variables["propertyType"] = itemType;
                        sourceWriter.WriteLine();
                        sourceWriter.WriteLine("[EdmRelationshipNavigationProperty(\"{associationNamespace}\", \"{associationName}\", \"{relatedEndName}\")]");

                        sourceWriter.WriteLine("public {propertyType} {propertyName}");
                        using (sourceWriter.Indent())
                        {
                            sourceWriter.WriteLine("get { return Data.{propertyName}Property.Get(this); }");
                            sourceWriter.WriteLine("set { Data.{propertyName}Property.Set(this, value); }");
                        }
                    }
                }
            }
        }

        private static void WriteDataClass(SourceWriter sourceWriter, EntityType entityType)
        {
            sourceWriter.WriteLine("{optionalNew}internal class Data {baseDataClassName}");
            using (sourceWriter.Indent())
            {
                foreach (EdmProperty prop in entityType.Properties.Where(c => c.DeclaringType == entityType).Where(prop => !entityType.KeyMembers.Contains(prop)))
                {
                    using (sourceWriter.NewVariableScope())
                    {
                        sourceWriter.Variables["propertyType"] = GetClrType(prop);
                        sourceWriter.Variables["propertyName"] = prop.Name;
                        sourceWriter.Variables["initialValue"] = "";
                        if (prop.TypeUsage.EdmType is ComplexType)
                        {
                            sourceWriter.Variables["initialValue"] = " = new " + sourceWriter.Variables["propertyType"] + "()";
                        }
                        sourceWriter.WriteLine("private {propertyType} {propertyName}{initialValue};");
                    }
                }
                sourceWriter.WriteLine();
                foreach (EdmProperty prop in entityType.Properties.Where(c => c.DeclaringType == entityType))
                {
                    using (sourceWriter.NewVariableScope())
                    {
                        sourceWriter.Variables["propertyType"] = GetClrType(prop);
                        sourceWriter.Variables["propertyName"] = prop.Name;
                        if (entityType.KeyMembers.Contains(prop))
                        {
                            sourceWriter.Variables["dataPropertyType"] = "DataKeyProperty<" + entityType.Name + ",Data," + sourceWriter.Variables["propertyType"] + ">";
                            sourceWriter.Variables["fieldName"] = "_" + prop.Name;
                        }
                        else
                        {
                            sourceWriter.Variables["dataPropertyType"] = "DataProperty<" + entityType.Name + ",Data," + sourceWriter.Variables["propertyType"] + ">";
                            sourceWriter.Variables["fieldName"] = prop.Name;
                        }
                        sourceWriter.WriteLine("public static {dataPropertyType} {propertyName}Property = new {dataPropertyType}(c=>c.{fieldName}, (c,v)=>c.{fieldName}=v, \"{propertyName}\");");
                    }
                }

                sourceWriter.WriteLine("ILazyEntityDataObject ILazyEntityDataObject.Copy()");
                using (sourceWriter.Indent())
                {
                    sourceWriter.WriteLine("return (ILazyEntityDataObject)MemberwiseClone();");
                }
                foreach (NavigationProperty navprop in entityType.NavigationProperties.Where(c => c.DeclaringType == entityType))
                {
                    using (sourceWriter.NewVariableScope())
                    {
                        sourceWriter.Variables["propertyName"] = navprop.Name;

                        string itemType = ((RefType)navprop.ToEndMember.TypeUsage.EdmType).ElementType.FullName;
                        sourceWriter.Variables["associationName"] = navprop.RelationshipType.FullName;
                        sourceWriter.Variables["relatedEndName"] = navprop.ToEndMember.Name;
                        if (navprop.ToEndMember.RelationshipMultiplicity == RelationshipMultiplicity.Many)
                        {
                            sourceWriter.Variables["dataPropertyType"] = "DataCollectionProperty<" + entityType.Name + ",Data," + itemType + ">";
                        }
                        else
                        {
                            sourceWriter.Variables["dataPropertyType"] = "DataRefProperty<" + entityType.Name + ",Data," + itemType + ">";
                        }
                        sourceWriter.WriteLine(@"public static {dataPropertyType} {propertyName}Property = new {dataPropertyType}(""{associationName}"",""{relatedEndName}"",""{propertyName}"");");
                    }
                }
            }
        }

        private static void WriteEntityContainers(EdmItemCollection itemCollection, SourceWriter sourceWriter)
        {
            foreach (EntityContainer container in itemCollection.GetItems<EntityContainer>())
            {
                sourceWriter.WriteLine();
                using (sourceWriter.NewVariableScope())
                {
                    sourceWriter.Variables["containerName"] = container.Name;
                    sourceWriter.WriteLine("public partial class {containerName} : LazyObjectContext");
                    using (sourceWriter.Indent())
                    {
                        sourceWriter.WriteLine("public {containerName}() : base(\"name={containerName}\", \"{containerName}\") { }");
                        sourceWriter.WriteLine("public {containerName}(string connectionString) : base(connectionString, \"{containerName}\") { }");
                        sourceWriter.WriteLine("public {containerName}(System.Data.EntityClient.EntityConnection connection) : base(connection, \"{containerName}\") { }");

                        foreach (EntitySet entitySet in container.BaseEntitySets.OfType<EntitySet>())
                        {
                            sourceWriter.Variables["entitySetName"] = entitySet.Name;
                            sourceWriter.Variables["entitySetElementType"] = entitySet.ElementType.FullName;
                            sourceWriter.WriteLine();
                            sourceWriter.WriteLine("private System.Data.Objects.ObjectQuery<{entitySetElementType}> _{entitySetName};");
                            sourceWriter.WriteLine("public System.Data.Objects.ObjectQuery<{entitySetElementType}> {entitySetName}");
                            using (sourceWriter.Indent())
                            {
                                sourceWriter.WriteLine("get");
                                using (sourceWriter.Indent())
                                {
                                    sourceWriter.WriteLine("if (_{entitySetName} == null)");
                                    sourceWriter.WriteLine("    _{entitySetName} = base.CreateQuery<{entitySetElementType}>(\"[{entitySetName}]\");");
                                    sourceWriter.WriteLine("return _{entitySetName};");
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void WriteAssociationTypes(EdmItemCollection itemCollection, SourceWriter sourceWriter)
        {
            foreach (AssociationType associationType in itemCollection.GetItems<AssociationType>())
            {
                using (sourceWriter.NewVariableScope())
                {
                    sourceWriter.Variables["associationName"] = associationType.Name;
                    sourceWriter.Variables["associationNamespace"] = associationType.NamespaceName;

                    sourceWriter.Variables["end1Name"] = associationType.AssociationEndMembers[0].Name;
                    sourceWriter.Variables["end1Multiplicity"] = associationType.AssociationEndMembers[0].RelationshipMultiplicity.ToString();
                    sourceWriter.Variables["end1Type"] = ((RefType)associationType.AssociationEndMembers[0].TypeUsage.EdmType).ElementType.FullName;

                    sourceWriter.Variables["end2Name"] = associationType.AssociationEndMembers[1].Name;
                    sourceWriter.Variables["end2Multiplicity"] = associationType.AssociationEndMembers[1].RelationshipMultiplicity.ToString();
                    sourceWriter.Variables["end2Type"] = ((RefType)associationType.AssociationEndMembers[1].TypeUsage.EdmType).ElementType.FullName;

                    sourceWriter.WriteLine("[assembly: global::System.Data.Objects.DataClasses.EdmRelationshipAttribute(\"{associationNamespace}\", \"{associationName}\", \"{end1Name}\", global::System.Data.Metadata.Edm.RelationshipMultiplicity.{end1Multiplicity}, typeof({end1Type}), \"{end2Name}\", global::System.Data.Metadata.Edm.RelationshipMultiplicity.{end2Multiplicity}, typeof({end2Type}))]");
                }
            }
        }
    }
}
