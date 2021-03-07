using ZipDependencyIncludeInVsixTask;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal class NugetNetToolMatchingPackageVersionZipIncludeProgram : ZipIncludeProgramBase
    {
        protected override IZipIncluder ZipIncluder => new NugetNetToolMatchingPackageVersionZipIncluder();
    }

}
