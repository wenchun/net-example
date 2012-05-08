<?xml version="1.0" encoding="utf-8"?>
<profile dslVersion="1.0.0.0"
       name="MyUmlProfile" displayName="My UML Profile"
       xmlns="http://schemas.microsoft.com/UML2.1.2/ProfileDefinition">
  <stereotypes>
    <stereotype name="humanTask" displayName="人工作業">
      <metaclasses>
        <metaclassMoniker name="/MyUmlProfile/Microsoft.VisualStudio.Uml.Activities.IActivityNode" />
      </metaclasses>
    </stereotype>
    <stereotype name="model" displayName="model">
      <metaclasses>
        <metaclassMoniker name="/MyUmlProfile/Microsoft.VisualStudio.Uml.Classes.IClass" />
      </metaclasses>
    </stereotype>
    <stereotype name="view" displayName="view">
      <metaclasses>
        <metaclassMoniker name="/MyUmlProfile/Microsoft.VisualStudio.Uml.Classes.IClass" />
      </metaclasses>
    </stereotype>
    <stereotype name="controller" displayName="controller">
      <metaclasses>
        <metaclassMoniker name="/MyUmlProfile/Microsoft.VisualStudio.Uml.Classes.IClass" />
      </metaclasses>
    </stereotype>
    <stereotype name="entity" displayName="entity">
      <metaclasses>
        <metaclassMoniker name="/MyUmlProfile/Microsoft.VisualStudio.Uml.Classes.IClass" />
      </metaclasses>
    </stereotype>
  </stereotypes>
  <metaclasses>
    <metaclass name="Microsoft.VisualStudio.Uml.Activities.IActivityNode" />
    <metaclass name="Microsoft.VisualStudio.Uml.Classes.IClass" />
  </metaclasses>
  <propertyTypes></propertyTypes>
</profile>