using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("ModelMetadataExtensions")]
[assembly: AssemblyDescription("Extension to Model Metadata that provide convention based resource lookup")]
[assembly: AssemblyCompany("Phil Haack")]
[assembly: AssemblyProduct("ModelMetadataExtensions")]
[assembly: AssemblyCopyright("Copyright © Phil Haack 2013")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("7aa5644d-b24f-4937-a24d-dee7b5b99604")]

[assembly: AssemblyVersion(AssemblyConstants.AssemblyVersion)]
[assembly: AssemblyFileVersion(AssemblyConstants.AssemblyVersion)]
[assembly: AssemblyInformationalVersion(AssemblyConstants.PackageVersion)]

internal static class AssemblyConstants
{
    internal const string PackageVersion = "0.1.2";
    internal const string PrereleaseVersion = ""; // Until we ship 1.0, this isn't necessary.
    internal const string AssemblyVersion = PackageVersion + ".0";
}