using System.IO;
using System.Linq;
using System.Xml.Linq;
using ZipDependencyIncludeInVsixTask;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal class NugetNetToolMatchingPackageVersionZipIncluder : ZipIncluderBase<INugetNetToolMatchingPackageVersionZipAsset>
    {
        private readonly IZipAssetFactory<INugetNetToolMatchingPackageVersionZipAsset> zipAssetFactory;

        protected override IZipAssetFactory<INugetNetToolMatchingPackageVersionZipAsset> ZipAssetFactory { get => zipAssetFactory; }

        public NugetNetToolMatchingPackageVersionZipIncluder() : this(new NugetNetToolMatchingPackageVersionZipAssetFactory()) { }
        internal NugetNetToolMatchingPackageVersionZipIncluder(IZipAssetFactory<INugetNetToolMatchingPackageVersionZipAsset> zipAssetFactory)
        {
            this.zipAssetFactory = zipAssetFactory;
        }

        private string GetProjectFile(string projectFile)
        {
            if (Path.IsPathRooted(projectFile))
            {
                return projectFile;
            }
            return Path.Combine(zipIncludeSettings.ProjectFolder, projectFile);
        }

        protected override string GetUpdateVersion(INugetNetToolMatchingPackageVersionZipAsset zipAsset, string currentVersion)
        {
            var projectFile = GetProjectFile(zipAsset.ProjectFile);
            if (File.Exists(zipAsset.ProjectFile))
            {
                var xDocument = XDocument.Load(projectFile);

                var itemGroups = xDocument.Root.Elements("ItemGroup");
                var packageReferences = itemGroups.SelectMany(g => g.Elements("PackageReference"));
                var packageReference = packageReferences.FirstOrDefault(pr =>
                {
                    return pr.Attribute("Include").Value == zipAsset.PackageReference;
                });
                if (packageReference == null)
                {
                    logger.LogError($"Project file {projectFile} does not contain package reference {zipAsset.PackageReference}");
                }
                var packageReferenceVersion = packageReference.Attribute("Version").Value;
                return packageReferenceVersion;
            }
            else
            {
                logger.LogError($"Project file {projectFile} does not exist");
            }
            return null;
        }
    }

}
