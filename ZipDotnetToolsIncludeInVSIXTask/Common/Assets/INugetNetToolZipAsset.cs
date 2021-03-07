using ZipDependencyIncludeInVsixTask;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal interface INugetNetToolZipAsset : IZipAsset
    {
        string NugetPackageName { get; set; }
        
    }
}
