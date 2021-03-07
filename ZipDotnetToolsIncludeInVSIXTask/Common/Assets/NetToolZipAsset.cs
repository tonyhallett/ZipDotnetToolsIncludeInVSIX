using ToolInstall;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal abstract class NetToolZipAsset : INugetNetToolZipAsset
    {
        private readonly IDotNetToolInstallAndZip dotNetToolInstallAndZip;

        public NetToolZipAsset() : this(new DotNetToolInstallAndZip()) { }
        

        internal NetToolZipAsset(IDotNetToolInstallAndZip dotNetToolInstallAndZip)
        {
            this.dotNetToolInstallAndZip = dotNetToolInstallAndZip;
        }


        public string ZipPrefix { get; set; }

        public string NugetPackageName { get; set; }

        public void GenerateZip(string newZipPath, string updateVersion)
        {
            dotNetToolInstallAndZip.Zip(newZipPath, NugetPackageName, updateVersion);
        }

        public string Type { get; } = "Dotnet tool";
        public string AssetFolder { get; set; }
        public string VSIXSubPath { get; set; }
    }
}
