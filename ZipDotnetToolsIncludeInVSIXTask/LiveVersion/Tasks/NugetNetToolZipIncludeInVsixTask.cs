using ZipDependencyIncludeInVsixTask;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    public class NugetNetToolZipIncludeInVsixTask : ZipIncludeInVsixTaskBase
    {
        protected override IZipIncluder ZipIncluder { get; } = new NugetNetToolLiveZipIncluder();
    }
}
