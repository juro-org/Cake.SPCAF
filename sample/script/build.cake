 // build artifacts first by executing ./build.ps1 in root
 #r "../../src/Cake.SPCAF/bin/Release/netstandard2.0/Cake.SPCAF.dll"

 //Add wsp file to folder or change filepath
 var wspFile = File(@".\example\solution_example.wsp");
 var outputFile = File(@".\example\outputfilename.html");


Task("SPCAF-Example-Setting")
    .Does(() =>
    {
        var settings = new SPCAFSettings();
        settings.Report.Add(Cake.SPCAF.Enums.Report.Xml);
        settings.Report.Add(Cake.SPCAF.Enums.Report.Html);
        settings.InputFiles.Add(wspFile);
        settings.Output = outputFile;
        SPCAF(settings);
    });

Task("SPCAF-Example-Fluent")
    .Does(() =>
    {
        SPCAF(s => s
            .WithXmlReport()
            .WithHtmlReport()
            .WithInput(wspFile)
            .WithOutput(outputFile)
        );
    });

Task("SPCAF-Example")
    .IsDependentOn("SPCAF-Example-Setting")
    .IsDependentOn("SPCAF-Example-Fluent")
    .Does(() => { Information("Done");});

RunTarget("SPCAF-Example");
