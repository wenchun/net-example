
//  Microsoft (R) .NET Framework IL Disassembler.  Version 1.1.4322.573
//  Copyright (C) Microsoft Corporation 1998-2002. All rights reserved.

.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 1:0:5000:0
}
.assembly extern Microsoft.VisualBasic
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 7:0:5000:0
}
.assembly FirstProgram
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module FirstProgram.exe
// MVID: {ABF10028-360A-478E-8985-D8CCDADF95A4}
.imagebase 0x00400000
.subsystem 0x00000003
.file alignment 512
.corflags 0x00000001
// Image base: 0x03140000
//
// ============== CLASS STRUCTURE DECLARATION ==================
//
.class private auto ansi sealed Module1
       extends [mscorlib]System.Object
{
} // end of class Module1


// =============================================================


// =============== GLOBAL FIELDS AND METHODS ===================


// =============================================================


// =============== CLASS MEMBERS DECLARATION ===================
//   note that class flags, 'extends' and 'implements' clauses
//          are provided here for information only

.class private auto ansi sealed Module1
       extends [mscorlib]System.Object
{
  .custom instance void [Microsoft.VisualBasic]Microsoft.VisualBasic.CompilerServices.StandardModuleAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public static void  Main() cil managed
  {
    .entrypoint
    .custom instance void [mscorlib]System.STAThreadAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       43 (0x2b)
    .maxstack  2
    .locals init (float64 V_0,
             float64 V_1)
    IL_0000:  ldc.r8     12.5
    IL_0009:  stloc.1
    IL_000a:  ldloc.1
    IL_000b:  ldc.r8     46.5
    IL_0014:  call       float64 Module1::Add(float64,
                                              float64)
    IL_0019:  stloc.0
    IL_001a:  ldstr      "The result is "
    IL_001f:  call       void [mscorlib]System.Console::Write(string)
    IL_0024:  ldloc.0
    IL_0025:  call       void [mscorlib]System.Console::WriteLine(float64)
    IL_002a:  ret
  } // end of method Module1::Main

  .method public static float64  Add(float64 n1,
                                     float64 n2) cil managed
  {
    // Code size       6 (0x6)
    .maxstack  2
    .locals init (float64 V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  add
    IL_0003:  stloc.0
    IL_0004:  ldloc.0
    IL_0005:  ret
  } // end of method Module1::Add

} // end of class Module1


// =============================================================

//*********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file Test.res
