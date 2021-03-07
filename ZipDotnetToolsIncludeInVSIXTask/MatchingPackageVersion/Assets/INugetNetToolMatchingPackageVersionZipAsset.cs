namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal interface INugetNetToolMatchingPackageVersionZipAsset : INugetNetToolZipAsset
    {
        string ProjectFile { get; set; }
        string PackageReference { get; set; }
    }
}
