using ZipDependencyIncludeInVsixTask;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    public class NugetNetToolMatchingPackageVersionZipIncludeInVsixTask : ZipIncludeInVsixTaskBase
    {
        protected override IZipIncluder ZipIncluder { get; } = new NugetNetToolMatchingPackageVersionZipIncluder();
    }

}
