namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal class MatchingPackageVersionNugetZipAsset : NugetZipAsset, INugetNetToolMatchingPackageVersionZipAsset
    {
        public string ProjectFile { get; set; }
        public string PackageReference { get; set; }
    }
    
}
