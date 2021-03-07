namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal class MatchingPackageVersionNetToolZipAsset : NetToolZipAsset, INugetNetToolMatchingPackageVersionZipAsset
    {
        public string ProjectFile { get; set; }
        public string PackageReference { get; set; }
    }
}
