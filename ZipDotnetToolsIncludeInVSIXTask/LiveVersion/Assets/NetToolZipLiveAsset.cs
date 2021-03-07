namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal class NetToolZipLiveAsset : NetToolZipAsset, INugetNetToolLiveZipAsset
    {
        public bool IncludePreRelease { get ; set; }
        public bool AllowMajorUpdate { get; set; }
        
    }
}
