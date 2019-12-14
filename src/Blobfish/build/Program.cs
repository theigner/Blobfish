namespace BlobfishLibBuild
{
    using System.IO;
    using System.Linq;

    using McMaster.Extensions.CommandLineUtils;

    using static Bullseye.Targets;
    using static SimpleExec.Command;

    public class Program
    {
        private const string EchoPrefix = "Blobfish";

        static void Main(string[] args)
        {
            var app = new CommandLineApplication(throwOnUnexpectedArg: false);

            //// Creathe the nupkg directory if it does not exist.
            if (!Directory.Exists("./nupkg"))
            {
                Directory.CreateDirectory("./nupkg");
            }

            //// Remove all files from the nupkg directory.
            Directory.GetFiles("./nupkg").ToList().ForEach(File.Delete);

            app.OnExecute(() =>
            {
                //// Run dotnet build for the Release configuration to build the project
                Target("build", () =>
                {
                    Run("dotnet", $"build -c Release", echoPrefix: EchoPrefix);
                });

                //// Run dotnet test for the Release configuration to execute all tests. Do not execute if the build failed.
                Target("test", DependsOn("build"), () =>
                {
                    Run("dotnet", $"test -c Release", echoPrefix: EchoPrefix);

                });

                //// Run dotnet pack for the Release configuration to create a NuGet package. Do not execute if the build failed.
                Target("pack", DependsOn("build"), () =>
                {
                    //// Find the project file in the src-Subdirectory
                    var projectFile = Directory.GetFiles("./src", "*.csproj", SearchOption.TopDirectoryOnly).First();

                    //// Create the NuGet package. It'll be placed in a directory named "nupkg"
                    Run("dotnet", $"pack {projectFile} -c Release -o ./nupkg", echoPrefix: EchoPrefix);

                    //// Copy the NuGet package to the top level nupkg folder
                    Directory
                        .GetFiles("./nupkg")
                        .ToList()
                        .ForEach(f => File.Copy(f, Path.Combine("../../nupkg", Path.GetFileName(f)), true));
                });

                Target("default", DependsOn("test", "pack"));
                RunTargetsAndExit(app.RemainingArguments, logPrefix: EchoPrefix);
            });

            app.Execute(args);
        }
    }
}
