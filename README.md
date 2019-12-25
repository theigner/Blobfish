# About Blobfish
Blobfish is a .NET Standard library that allows you to read and write AnIML files.  
This project is founded and maintained by [Thomas Eigner](https://twitter.com/thomas_eigner) completely outside of any professional activity for a company and licensed under [Apache 2](https://opensource.org/licenses/Apache-2.0).

For project documentation, please visit [readthedocs](https://blobfish.readthedocs.io).

[![Build Status](https://dev.azure.com/theigner/Blobfish/_apis/build/status/theigner.Blobfish?branchName=master)](https://dev.azure.com/theigner/Blobfish/_build/latest?definitionId=3&branchName=master)
[![Documentation Status](https://readthedocs.org/projects/blobfish/badge/?version=latest)](https://blobfish.readthedocs.io/en/latest/?badge=latest)

# Reasons for creating this project
A first approach to read / write AnIML files was to generate classes from the AnIML core schema XSD file using xsd.exe. The result worked perfectly fine in combination with the XmlSerializer but had some drawbacks and some things where nothing but cumbersome to use.  
As a result I decided to implement the AnIML core schema from scratch and thereby integrate some additional functionality that is quite handy (e.g. converting arrays of values to the base64 representation for use in EncodedValueSets etc.).

# About AnIML
AnIML (**An**alytical **I**nformation **M**arkup **L**anguage) is a XML based file format to store analytical data.  
Please see the website of the [AnIML Standard](https://animl.org) for futher information on the standard itself.  
Technical information as well as the schema definitions can be found in the [AnIML GitHub repository](https://github.com/animl)

# Issues and feature requests
Please use the [GitHub Issue Tracker](https://github.com/theigner/Blobfish/issues) to report issues, bugs and feature requests.

# Versioning
The current version of the Blobfish library implements the current AnIML standard version 0.9.

# Package source
The current pre-releases are not published on NuGet but are available on the following NuGet feed in Azure DevOps.

```
https://pkgs.dev.azure.com/theigner/Blobfish/_packaging/Blobfish/nuget/v3/index.json
```

# Credits
The Blobfish libary is using the following open source projects:
- [Bullseye](https://github.com/adamralph/bullseye) in combination with [SimpleExec](https://github.com/adamralph/simple-exec) for building the project with Azure Pipelines.
- [FluentAssertions](http://www.fluentassertions.com/) in combination with [XUnit](https://xunit.github.io/) for unit testing.
- [MinVer](https://github.com/adamralph/minver) for automatic versioning.