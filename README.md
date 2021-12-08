# Cake.SPCAF

[![standard-readme compliant][]][standard-readme]
[![NuGet package][nugetimage]][nuget]
[![Cake][cakeimage]][cake]

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

 var wspFile = File(@".\example\solution_example.wsp");
 var outputFile = File(@".\example\outputfilename.html");

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
[cakeimage]: https://img.shields.io/static/v1?label=cake&message=v2.0.0&color=8E7D3E&style=flat-square
[cake]: https://cakebuild.net/blog/2021/11/cake-v2.0.0-released
