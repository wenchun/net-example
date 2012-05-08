set DIRS_TO_CLEAN=Sources\EFLazyLoading Sources\EFLazyClassGen
set DIRS_TO_CLEAN=%DIRS_TO_CLEAN% Tests\DataBindingTest
set DIRS_TO_CLEAN=%DIRS_TO_CLEAN% Tests\DesignerTest
set DIRS_TO_CLEAN=%DIRS_TO_CLEAN% Tests\LazyNorthwind
set DIRS_TO_CLEAN=%DIRS_TO_CLEAN% Tests\LazyNorthwind.Tests
set DIRS_TO_CLEAN=%DIRS_TO_CLEAN% Tests\NonLazyBinding
set DIRS_TO_CLEAN=%DIRS_TO_CLEAN% Tests\NonLazyNorthwind

for %%i in (%DIRS_TO_CLEAN%) do rd /q /s "%%i\bin"
for %%i in (%DIRS_TO_CLEAN%) do rd /q /s "%%i\obj"

rd /q /s TestResults

del Tests\DesignerTest\NorthwindEF.Designer.cs
del Tests\LazyNorthwind\Northwind.cs
del Tests\LazyNorthwind\Northwind.Views.cs
del Tests\NonLazyNorthwind\Northwind.cs
             
pushd ..
del EFLazyLoading.zip
zip -9 -X -r EFLazyLoading.zip EFLazyLoading
popd
