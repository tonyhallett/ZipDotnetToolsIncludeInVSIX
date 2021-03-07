using ZipDotnetToolsIncludeInVSIXTask;

namespace NugetNetToolZipIncludeToolTaskExe
{
    class Program
    {
        static void Main(string[] args)
        {
            new NugetNetToolZipIncludeProgram().Generate(args);
        }
    }
}
