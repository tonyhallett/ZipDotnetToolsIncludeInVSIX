using System.Collections.Generic;
using System.Linq;
using ZipDependencyIncludeInVsixTask;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal class NugetNetToolLiveZipAssetFactory : XmlZipAssetFactory<NugetNetToolLiveXml, INugetNetToolLiveZipAsset>
    {
        protected override string TagName => "NugetNetToolZipAsset";

        protected override IEnumerable<INugetNetToolLiveZipAsset> CreateFrom(IEnumerable<NugetNetToolLiveXml> assets)
        {
            return assets.Select(a =>
            {

                INugetNetToolLiveZipAsset nugetZipLiveAsset;
                if (!string.IsNullOrEmpty(a.NetToolName))
                {
                    nugetZipLiveAsset = new NetToolZipLiveAsset { NugetPackageName = a.NetToolName };
                }
                else
                {
                    nugetZipLiveAsset = new NugetZipLiveAsset { NugetPackageName = a.NugetPackageName };
                }

                
                var includePreRelease = a.IncludePreRelease == "true";
                var allowMajorUpdate = a.AllowMajorUpdate == "true";
                nugetZipLiveAsset.IncludePreRelease = includePreRelease;
                nugetZipLiveAsset.AllowMajorUpdate = allowMajorUpdate;
                a.Populate(nugetZipLiveAsset);
                
                return nugetZipLiveAsset;
            });
        }
    }
}
