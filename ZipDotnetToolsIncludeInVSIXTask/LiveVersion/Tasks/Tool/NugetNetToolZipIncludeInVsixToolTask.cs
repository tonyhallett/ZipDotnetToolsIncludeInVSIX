using System.IO;
using System.Reflection;
using ZipDependencyIncludeInVsixTask;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    public class NugetNetToolZipIncludeInVsixToolTask : ZipIncludeInVsixToolTaskBase
    {
        protected override string ToolName => "NugetNetToolZipIncludeInVsix";

        protected override string GenerateFullPathToTool()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "NugetNetToolZipIncludeToolTaskExe.exe");
        }
    }
}
