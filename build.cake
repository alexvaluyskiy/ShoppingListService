var target = Argument("target", "Build");

// Directories
var output = Directory("build");
var outputBinaries = output + Directory("binaries");

// Arguments
var skipClean = Argument<bool>("skipclean", false);

// Variables
var configuration = "Release";

// Docker Toolbox
var toolBoxScript = @"C:\Program Files\Docker Toolbox\start.sh";
var bash = @"C:\Program Files\Git\bin\bash.exe";

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

Task("LocalEnvUp")
    .Does(() =>
{
    if (!FileExists(toolBoxScript))
        throw new Exception($"Toolbox script not found using path - {toolBoxScript}");
    
    if (!FileExists(bash))
        throw new Exception($"Bash shell is not found using path - {bash}");

    // Copy docker-copmose.yaml to user's working folder
    System.IO.File.Copy("docker-compose.yml", $"{EnvironmentVariable("USERPROFILE")}//docker-compose.yml", true);

    // Start bash script to execute docker-compose under local docker VM
    var process = new System.Diagnostics.Process();
    process.StartInfo = new System.Diagnostics.ProcessStartInfo(bash)
    {
         Arguments = "--login -i start.sh \"docker-compose up -d\"",
         WorkingDirectory = System.IO.Path.GetDirectoryName(toolBoxScript),
         UseShellExecute = false,
         LoadUserProfile = true
    };
    
    process.Start();
    process.WaitForExit();
});

RunTarget(target);