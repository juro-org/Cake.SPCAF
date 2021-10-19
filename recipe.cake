#load nuget:?package=Cake.Recipe&version=2.2.1

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./src",
    title: "Cake.SPCAF",
    masterBranchName: "main",
    repositoryOwner: "juro-org",
    repositoryName: "Cake.SPCAF",
    shouldRunDotNetCorePack: true,
    shouldUseDeterministicBuilds: true,
    shouldRunCodecov: false,
    preferredBuildAgentOperatingSystem: PlatformFamily.Linux,
    preferredBuildProviderType: BuildProviderType.GitHubActions);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
							dupFinderExcludePattern: new string[] {
                            BuildParameters.RootDirectoryPath + "/**/Cake.SPCAF.Tests/**/*.cs",
                            BuildParameters.RootDirectoryPath + "/**/Cake.SPCAF/**/*.AssemblyInfo.cs",
							BuildParameters.RootDirectoryPath + "/**/Cake.SPCAF/SPCAFSettings.cs"	
							}						
);


Build.RunDotNetCore();
