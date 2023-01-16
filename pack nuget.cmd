if not exist NuGet mkdir NuGet

del /Q NuGet\*.*

NuGet.exe pack pwExtensionsLibrary.nuspec -OutputDirectory NuGet -IncludeReferencedProjects -Properties Configuration=Release;Platform=AnyCPU -Build

rem pause