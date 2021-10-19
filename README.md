# Cake.SPCAF

[![standard-readme compliant][]][standard-readme]
[![NuGet package][nugetimage]][nuget]

Alias to assist with running SPCAF from Cake build scripts

## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Maintainer](#maintainer)
- [Contributing](#contributing)
- [License](#license)

## Install

```cs
#addin nuget:?package=Cake.SPCAF&version={Version}
```

## Usage

This addin exposes the functionality of [SPCAF] to the Cake DSL by being a very thin wrapper around its command line interface; this means that you can use Cake.SPCAF in the same way as you would normally use [SPCAF CLI].

```cs
#addin nuget:?package=Cake.SPCAF&version={Version}

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
```

## Maintainer

[Jürgen Rosenthal-Buroh @JuergenRB][maintainer]

## Contributing

Cake.SPCAF follows the [Contributor Covenant][contrib-covenant] Code of Conduct.

We accept Pull Requests.

Small note: If editing the Readme, please conform to the [standard-readme][] specification.

## License

[MIT License © Jürgen Rosenthal-Buroh][license]

[SPCAF]:https://rencore.com/products/code/
[SPCAF CLI]:https://go.rencore.com/support/how-to-run-spcaf-from-command-line
[contrib-covenant]: https://www.contributor-covenant.org/version/1/4/code-of-conduct
[maintainer]: https://github.com/JuergenRB
[nuget]: https://nuget.org/packages/Cake.SPCAF
[nugetimage]: https://img.shields.io/nuget/v/Cake.SPCAF.svg?logo=nuget&style=flat-square
[license]: LICENSE.txt
[standard-readme]: https://github.com/RichardLitt/standard-readme
[standard-readme compliant]: https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square
