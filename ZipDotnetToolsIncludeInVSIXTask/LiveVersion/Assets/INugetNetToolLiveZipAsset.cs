using ZipDependencyIncludeInVsixTask;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal interface INugetNetToolLiveZipAsset : INugetNetToolZipAsset
    {
        bool IncludePreRelease { get; set; }
        bool AllowMajorUpdate { get; set; }

    }
}
