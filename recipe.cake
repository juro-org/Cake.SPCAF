#load nuget:?package=Cake.Recipe&version=3.0.1

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

ToolSettings.SetToolSettings(context: Context);


Build.RunDotNetCore();
