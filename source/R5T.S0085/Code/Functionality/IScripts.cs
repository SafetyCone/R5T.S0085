using System;

using R5T.T0132;


namespace R5T.S0085
{
    [FunctionalityMarker]
    public partial interface IScripts : IFunctionalityMarker
    {
        /// <summary>
        /// Opens the dotnet packs directory in an Explorer window.
        /// </summary>
        public void Open_DotnetPacksDirectory_InExplorer()
        {
            Instances.WindowsExplorerOperator._Platform.OpenDirectoryInExplorer(
                Instances.DotnetPacksDirectoryPaths.Windows.Value);
        }
    }
}
