using System.Linq;
using NuGet.Versioning;
using ToolInstall;
using ZipDependencyIncludeInVsixTask;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal class NugetNetToolLiveZipIncluder : ZipIncluderBase<INugetNetToolLiveZipAsset>
    {
        private readonly INugetClientHelper NugetClientHelper;
        private readonly IZipAssetFactory<INugetNetToolLiveZipAsset> zipAssetFactory;

        protected override IZipAssetFactory<INugetNetToolLiveZipAsset> ZipAssetFactory { get => zipAssetFactory; }

        public NugetNetToolLiveZipIncluder() : this(new NugetNetToolLiveZipAssetFactory(), new NugetClientHelper())
        {
        }

        internal NugetNetToolLiveZipIncluder(IZipAssetFactory<INugetNetToolLiveZipAsset> nugetZipAssetFactory, INugetClientHelper nugetClientHelper)
        {
            this.zipAssetFactory = nugetZipAssetFactory;
            NugetClientHelper = nugetClientHelper;
        }

        protected override string GetUpdateVersion(INugetNetToolLiveZipAsset zipAsset, string currentVersion)
        {
            if (zipAsset.AllowMajorUpdate || currentVersion == null)
            {
                var latestVersion = NugetClientHelper.GetLatestVersion(zipAsset.NugetPackageName, zipAsset.IncludePreRelease).GetAwaiter().GetResult();
                return latestVersion.ToNormalizedString();
            }

            var versions = NugetClientHelper.GetVersions(zipAsset.NugetPackageName, zipAsset.IncludePreRelease).GetAwaiter().GetResult();
            var currentNugetVersion = NuGetVersion.Parse(currentVersion);
            var currentMajor = currentNugetVersion.Major;
            var allowedVersions = versions.Where(v => v.Major <= currentMajor).ToList();
            if (allowedVersions.Count == 0)
            {
                logger.LogWarning($"No nuget major version {currentMajor} for {zipAsset.NugetPackageName}");
                return null;
            }
            return allowedVersions.Max().ToNormalizedString();

        }

    }

}
