namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal class NugetNetToolLiveXml : NugetNetToolXmlBase
    {
        public string IncludePreRelease { get; set; }
        public string AllowMajorUpdate { get; set; }
    }
}
