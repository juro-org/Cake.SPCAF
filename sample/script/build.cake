 // build artifacts first by executing ./build.ps1 in root
 #r "../../src/Cake.SPCAF/bin/Release/netstandard2.0/Cake.SPCAF.dll"

Task("SPCAF-Example")
    .Does(() =>
    {
        var settings = new SPCAFSettings();
        settings.Report.Add(Cake.SPCAF.Enums.Report.Xml);
        settings.Report.Add(Cake.SPCAF.Enums.Report.Html);
        //Add wsp file to folder or change filepath
        settings.Inputfiles.Add(new FilePath(@".\example\solution_example.wsp"));
        settings.Output = new FilePath(@".\example\outputfilename.html");
        SPCAF(settings);
    });

RunTarget("SPCAF-Example");