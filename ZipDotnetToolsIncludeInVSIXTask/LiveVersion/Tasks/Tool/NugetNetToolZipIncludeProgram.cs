using ZipDependencyIncludeInVsixTask;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal class NugetNetToolZipIncludeProgram : ZipIncludeProgramBase
    {
        protected override IZipIncluder ZipIncluder => new NugetNetToolLiveZipIncluder();
    }

}
