using System;
using System.IO;

using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcRazorRuntimeCompilationOptionsExtensions
    {
        public static MvcRazorRuntimeCompilationOptions AddRazorClassLibraryRuntimeCompilation(this MvcRazorRuntimeCompilationOptions options, string libraryDirectoryPath)
        {
            var fileProvider = new PhysicalFileProvider(libraryDirectoryPath);

            options.FileProviders.Add(fileProvider);

            return options;
        }

        public static MvcRazorRuntimeCompilationOptions AddRazorClassLibraryRuntimeCompilation(this MvcRazorRuntimeCompilationOptions options, string hostContentRootPath, string libraryRelativeDirectoryPath)
        {
            var libraryDirectoryPath = Path.GetFullPath(Path.Combine(hostContentRootPath, libraryRelativeDirectoryPath));

            return options.AddRazorClassLibraryRuntimeCompilation(libraryDirectoryPath);
        }

        public static MvcRazorRuntimeCompilationOptions AddRazorClassLibraryRuntimeCompilation(this MvcRazorRuntimeCompilationOptions options, IHostEnvironment hostEnvironment, string libraryRelativeDirectoryPath)
        {
            return options.AddRazorClassLibraryRuntimeCompilation(hostEnvironment.ContentRootPath, libraryRelativeDirectoryPath);
        }
    }
}
