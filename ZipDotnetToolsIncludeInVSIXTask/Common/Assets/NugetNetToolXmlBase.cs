using ZipDependencyIncludeInVsixTask;

namespace ZipDotnetToolsIncludeInVSIXTask
{
    internal abstract class NugetNetToolXmlBase : ZipAssetXml
    {
        public string NetToolName { get; set; }
        public string NugetPackageName { get; set; }
    }
}
