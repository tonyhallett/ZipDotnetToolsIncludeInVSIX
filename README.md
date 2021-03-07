This project builds an MSBuild nuget package containing two tasks that will include zipped dotnet tools or nuget packages in a VSIX.
The zip files may be generated on each build and this can be configured.

The nuget will add the necessary Target to the consuming vsix project and all that remains is to supply msbuild properties in the 
consuming vsix project file.  If desired, the consuming project can create its own Target and use one of the two using tasks
NugetNetToolMatchingPackageVersionZipIncludeInVsixToolTask
NugetNetToolZipIncludeInVsixToolTask

The Target added is :
```
<Project>
  <Target Name="NugetNetToolZipIncludes" BeforeTargets="GetVsixSourceItems" Returns="@(Content)">
    <PropertyGroup>
      <NugetNetToolZipAssetSettingsPath Condition="'$(NugetNetToolZipAssetSettingsPath)'==''">$(MSBuildProjectFullPath)</NugetNetToolZipAssetSettingsPath>
    </PropertyGroup>
    <Message Text="Generating Zip Files For VSIX from settings $(NugetNetToolZipAssetSettingsPath)" />
    <NugetNetToolZipIncludeInVsixToolTask 
        VSIXSubPath="$(NugetNetToolZipVSIXSubPath)" 
        AssetFolder="$(NugetNetToolZipAssetFolder)" 
        AssetSettingsPath="$(NugetNetToolZipAssetSettingsPath)"
        ProjectFolder="$(MSBuildProjectDirectory)"
        UseExisting="$(NugetNetToolZipUseExisting)"
        Force="$(NugetNetToolZipForce)"
        >
            <Output TaskParameter="IncludedZipsInVsix" ItemName="Content" />
    </NugetNetToolZipIncludeInVsixToolTask>
    <NugetNetToolMatchingPackageVersionZipIncludeInVsixToolTask 
        VSIXSubPath="$(NugetNetToolZipVSIXSubPath)" 
        AssetFolder="$(NugetNetToolZipAssetFolder)" 
        AssetSettingsPath="$(NugetNetToolZipAssetSettingsPath)"
        ProjectFolder="$(MSBuildProjectDirectory)"
        UseExisting="$(NugetNetToolZipUseExisting)"
        Force="$(NugetNetToolZipForce)"
        >
            <Output TaskParameter="IncludedZipsInVsix" ItemName="Content" />
    </NugetNetToolMatchingPackageVersionZipIncludeInVsixToolTask>
  </Target>
</Project>
```

Both tasks are supplied the same arguments and if this is not suitable then create your own Target.
The configuration for a task is done in an xml file - AssetSettingsPath.  For the provided Target this defaults to the consuming project file.
Each task expects a specific tag :
NugetNetToolZipIncludes - NugetNetToolZipAsset
NugetNetToolMatchingPackageVersionZipIncludeInVsixToolTask - NugetNetToolPackageVersionZipAsset

Here is the settings for the demo vsix - DemoVsixUsingTask

```
<AssetSettings>
  <NugetNetToolZipAsset>
    <ZipPrefix>coverlet.console</ZipPrefix>
    <NetToolName>coverlet.console</NetToolName>
  </NugetNetToolZipAsset>
  <NugetNetToolZipAsset>
    <ZipPrefix>microsoft.testplatform</ZipPrefix>
    <NugetPackageName>microsoft.testplatform</NugetPackageName>
  </NugetNetToolZipAsset>
  <NugetNetToolZipAsset>
    <ZipPrefix>openCover</ZipPrefix>
    <NugetPackageName>openCover</NugetPackageName>
  </NugetNetToolZipAsset>

  <NugetNetToolZipAsset>
    <ZipPrefix>coverlet.collector</ZipPrefix>
    <NugetPackageName>coverlet.collector</NugetPackageName>
    <VSIXSubPath>DifferentSubPath</VSIXSubPath>
    <AssetFolder>OtherZipAssets</AssetFolder>
  </NugetNetToolZipAsset>

  <NugetNetToolPackageVersionZipAsset>
    <ZipPrefix>reportGenerator</ZipPrefix>
    <NetToolName>dotnet-reportgenerator-globaltool</NetToolName>
    <ProjectFile>ReportGeneratorPlugins.aproj</ProjectFile>
    <PackageReference>ReportGenerator.Core</PackageReference>
  </NugetNetToolPackageVersionZipAsset>
</AssetSettings>
```

Common to each asset type :
ZipPrefix - This will be the prefix of the generated zip.
NetToolName or NugetPackageName - These are both the nuget package name.  Use NetToolName when it needs to be installed with dotnet tool install.

Can be specified on the task for all assets or individually on an asset.
AssetFolder - Specify the path to the folder where the zipped tools will be written to.  This can be relative to the task ProjectFolder.
VSIXSubPath - This determines the folder in the vsix where the zipped tool can be found.  This is not required as will default to the name of the AssetFolder.

NugetNetToolZipAsset specific

IncludePreRelease
AllowMajorUpdate

These are not specified in the example above and default to false.
These affect the versions of the net tool or nuget package that can be installed and zipped.
AllowMajorUpdate will be considered when there is an already generated zip in the AssetFolder.  If false only available versions with the 
same major version will be considered.
Set IncludePreRelease for pre release versions to be installed.


NugetNetToolPackageVersionZipAsset specific
This zip asset type will only install a version that matches the designated PackageReference in the ProjectFile.  The ProjectFile can be relative to ProjectFolder.

Task properties UseExisting and Force
These task properties can be used to control the re-generation of the zip files.
UseExisting will prevent a version update.
Force will recreate the zip when there is no version update.





