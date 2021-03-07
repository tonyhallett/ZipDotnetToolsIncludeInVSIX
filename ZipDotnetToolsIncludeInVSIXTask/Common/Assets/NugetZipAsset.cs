using NuGet.Versioning;
using ToolInstall;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal abstract class NugetZipAsset : INugetNetToolZipAsset
    {
        private readonly INugetClientHelper nugetClientHelper;

        public NugetZipAsset():this(new NugetClientHelper())
        {
        }

        internal NugetZipAsset(INugetClientHelper nugetClientHelper)
        {
            this.nugetClientHelper = nugetClientHelper;
        }

        public string ZipPrefix { get; set; }

        public string NugetPackageName { get; set; }

        public void GenerateZip(string newZipPath, string updateVersion)
        {
            NuGetVersion nugetUpdateVersion = NuGetVersion.Parse(updateVersion);
            nugetClientHelper.DownloadNuPkg(NugetPackageName, nugetUpdateVersion, newZipPath).GetAwaiter().GetResult();
        }

        public string Type { get; } = "Nuget package";
        public string AssetFolder { get; set; }
        public string VSIXSubPath { get; set; }
    }
}
