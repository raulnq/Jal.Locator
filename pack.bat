packages\NuGet.CommandLine.2.8.6\tools\nuget pack Jal.Locator\Jal.Locator.csproj -Properties "Configuration=Release;Platform=AnyCPU;OutputPath=bin\Release" -Build -IncludeReferencedProjects -OutputDirectory Jal.Locator.Nuget

packages\NuGet.CommandLine.2.8.6\tools\nuget pack Jal.Locator.CastleWindsor\Jal.Locator.CastleWindsor.csproj -Properties "Configuration=Release;Platform=AnyCPU;OutputPath=bin\Release" -Build -IncludeReferencedProjects -OutputDirectory Jal.Locator.Nuget

pause;