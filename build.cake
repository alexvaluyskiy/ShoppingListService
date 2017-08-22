var target = Argument("target", "Build");

// Directories
var output = Directory("build");
var outputBinaries = output + Directory("binaries");

// Arguments
var skipClean = Argument<bool>("skipclean", false);

// Variables
var configuration = "Release";

Task("Clean")
  .Does(() =>
{
    // Clean artifact directories.
    CleanDirectories(new DirectoryPath[] {
        output, outputBinaries
    });

    if (!skipClean) {
        // Clean output directories.
        CleanDirectories("./**/bin/" + configuration);
        CleanDirectories("./**/obj/" + configuration);
    }
});

Task("NugetRestore")
  .IsDependentOn("Clean")
  .Does(() =>
{
    DotNetCoreRestore();
});

Task("Build")
    .IsDependentOn("NugetRestore")
    .Does(() =>
{
     var settings = new DotNetCoreBuildSettings
     {
         Framework = "netcoreapp2.0",
         Configuration = configuration,
     };


    DotNetCoreBuild("./ShoppingListService.sln", settings);
});

RunTarget(target);