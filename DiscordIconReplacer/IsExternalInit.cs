#if !NETCOREAPP
// Polyfill for .NET Framework 4.x to enable C# 9+ record types and init-only properties.
// See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#records
namespace System.Runtime.CompilerServices;

internal static class IsExternalInit { }
#endif
