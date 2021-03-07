using System.IO;
using System.Reflection;
using ZipDependencyIncludeInVsixTask;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    public class NugetNetToolMatchingPackageVersionZipIncludeInVsixToolTask : ZipIncludeInVsixToolTaskBase
    {
        protected override string ToolName => "NugetNetToolMatchingPackageVersionZipIncludeInVsix";

        protected override string GenerateFullPathToTool()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "NugetNetToolMatchingPackageVersionZipIncludeToolTaskExe.exe");
        }
    }
}
