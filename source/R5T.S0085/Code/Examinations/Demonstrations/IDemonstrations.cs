using System;

using R5T.T0141;


namespace R5T.S0085
{
    /// <summary>
    /// Demonstrations for working with dotnet pack paths (example: C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.18\ref\net6.0\).
    /// </summary>
    [DemonstrationsMarker]
    public partial interface IDemonstrations : IDemonstrationsMarker
    {
        public void Get_DocumentationFilePaths_ForDotnetPack()
        {
            /// Inputs.
            var dotnetPackName = Instances.DotnetPackNames.Microsoft_NETCore_App_Ref;
            var targetFramework = Instances.TargetFrameworkMonikers.NET_6;


            /// Run.
            var documentationXmlFilePaths = Instances.DotnetPackPathOperator.Get_DocumentationXmlFilePaths(
                dotnetPackName,
                targetFramework);

            foreach (var filePath in documentationXmlFilePaths)
            {
                Console.WriteLine(filePath);
            }

            Console.WriteLine($"{documentationXmlFilePaths.Length}: Count");
        }

        /// <summary>
        /// Given a dotnet pack name and a target framework moniker, get the dotnet pack directory path.
        /// This requires querying the file system for the versions available for a dotnet pack.
        /// </summary>
        public void Get_DotnetPackDirectoryPath_ForTargetFramework()
        {
            /// Inputs.
            var dotnetPackName = Instances.DotnetPackNames.Microsoft_NETCore_App_Ref;
            var targetFramework = Instances.TargetFrameworkMonikers.NET_6;


            /// Run.
            var dotnetPackDirectoryPath = Instances.DotnetPackPathOperator.Get_DotnetPackDirectoryPath(
                dotnetPackName,
                targetFramework);

            Console.WriteLine($"{dotnetPackName}, {targetFramework} =>\n\t{dotnetPackDirectoryPath}");
        }

        /// <summary>
        /// Combine dotnet packs functionality to get versioned dotnet pack directories by their version,
        /// with version functionality to select the highest sub-version of a major version number,
        /// to get the versioned dotnet pack directory of the highest sub-version.
        /// </summary>
        public void Get_VersionedDirectoryForDotnetMajorVersion()
        {
            /// Inputs.
            var dotnetPackName = Instances.DotnetPackNames.Microsoft_NETCore_App_Ref;
            var dotnetMajorVersion = Instances.DotnetMajorVersions.V6;


            /// Run.
            var versionedDirectoryPathsByVersion = Instances.DotnetPackPathOperator.Get_VersionedPackDirectoryPathsByVersion(
                dotnetPackName);

            var versions = versionedDirectoryPathsByVersion.Keys;

            var highestSubVersion = Instances.VersionOperator.Choose_HighestSubVersionOf(
                versions,
                dotnetMajorVersion);

            var highestSubVersionDirectoryPath = versionedDirectoryPathsByVersion[highestSubVersion];

            Console.WriteLine($"{highestSubVersion} =>\n\t{highestSubVersionDirectoryPath}");
        }

        /// <summary>
        /// Given a .NET pack name, list the .NET versions available for it (and their directory paths).
        /// </summary>
        public void List_VersionedDirectoriesForPack()
        {
            /// Input.
            var dotnetPackName = Instances.DotnetPackNames.Microsoft_NETCore_App_Ref;


            /// Run.
            var versionedDirectoryPathsByVersion = Instances.DotnetPackPathOperator.Get_VersionedPackDirectoryPathsByVersion(
                dotnetPackName);

            foreach (var pair in versionedDirectoryPathsByVersion)
            {
                Console.WriteLine($"{pair.Key} =>\n\t{pair.Value}");
            }
        }
    }
}
