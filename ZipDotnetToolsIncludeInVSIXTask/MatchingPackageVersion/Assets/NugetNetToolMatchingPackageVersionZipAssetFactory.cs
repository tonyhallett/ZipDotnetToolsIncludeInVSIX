using System.Collections.Generic;
using System.Linq;
using ZipDependencyIncludeInVsixTask;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal class NugetNetToolMatchingPackageVersionZipAssetFactory : XmlZipAssetFactory<NugetNetToolMatchingPackageVersionXml,INugetNetToolMatchingPackageVersionZipAsset>
    {
        protected override string TagName => "NugetNetToolPackageVersionZipAsset";

        protected override IEnumerable<INugetNetToolMatchingPackageVersionZipAsset> CreateFrom(IEnumerable<NugetNetToolMatchingPackageVersionXml> assets)
        {
            return assets.Select(a =>
            {
                INugetNetToolMatchingPackageVersionZipAsset matchingVersionNetToolAsset;
                if (!string.IsNullOrEmpty(a.NetToolName))
                {
                    matchingVersionNetToolAsset = new MatchingPackageVersionNetToolZipAsset { NugetPackageName = a.NetToolName };
                }
                else
                {
                    matchingVersionNetToolAsset = new MatchingPackageVersionNugetZipAsset { NugetPackageName = a.NugetPackageName };
                }

                matchingVersionNetToolAsset.ProjectFile = a.ProjectFile;
                matchingVersionNetToolAsset.PackageReference = a.PackageReference;
                a.Populate(matchingVersionNetToolAsset);

                return matchingVersionNetToolAsset;
            });
        }
    }
}
