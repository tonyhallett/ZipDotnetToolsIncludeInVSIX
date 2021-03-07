namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal class NugetZipLiveAsset : NugetZipAsset,INugetNetToolLiveZipAsset
    {
        public bool IncludePreRelease { get;  set; }
        public bool AllowMajorUpdate { get; set; }
    }
}
