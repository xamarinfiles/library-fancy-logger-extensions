using System.Reflection;
using static System.String;

// Source: https://github.com/xamarinfiles/library-fancy-logger-extensions
//
// Problem: unable to use shared project due to anti-virus issue with AssemblyLogger
//
// Solution: copy file to each repo and add to each test project as shared file
// to avoid duplicating code into each test program
namespace XamarinFiles.FancyLogger.Extensions
{
    internal static class LogPrefixHelper
    {
        #region Methods

        // TODO Move to static interface method in IFL after off .NET Std 2.0 (XF)
        // Trims namespace down to use as FancyLogger line prefix:
        //
        // Inputs:
        // RootAssemblyNamespace = "XamarinFiles.FancyLogger."
        // DefaultLogPrefix = "LOG"
        //
        // Outputs:
        // XamarinFiles.FancyLogger.Tests.Smoke.Local => Tests.Smoke.Local
        // XamarinFiles.FancyLogger.Tests.Smoke.NuGet => Tests.Smoke.NuGet
        internal static string GetAssemblyNameTail(Assembly assembly,
            string rootAssemblyNamespace, string defaultLogPrefix)
        {
            var assemblyName = assembly.GetName().Name;
            if (IsNullOrWhiteSpace(assemblyName))
                return "";

            //var splitSegments =
            //    assemblyName.Split(rootAssemblyNamespace,
            //        RemoveEmptyEntries);

            var assemblyNamespaceLength =
                assemblyName.Length - rootAssemblyNamespace.Length;
            var assemblyNameSpaceTail =
                assemblyName.Substring(assemblyNamespaceLength);

            if (IsNullOrEmpty(assemblyNameSpaceTail))
                return defaultLogPrefix;

            return assemblyNameSpaceTail;
        }

        #endregion
    }
}
