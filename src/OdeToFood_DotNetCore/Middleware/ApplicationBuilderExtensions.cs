using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.DotNet.InternalAbstractions;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(
            this IApplicationBuilder app,
            IHostingEnvironment appEnvironment)
        {            
            var node_modules = Path.Combine(appEnvironment.ContentRootPath, "node_modules");
            var provider = new PhysicalFileProvider(node_modules);

            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = provider;

            app.UseStaticFiles(options);
            return app;
        }

        public static IApplicationBuilder UseNodeModulesX(
            this IApplicationBuilder app)
        {
            Microsoft.Extensions.PlatformAbstractions.ApplicationEnvironment sera = new Microsoft.Extensions.PlatformAbstractions.ApplicationEnvironment();

            var path = sera.ApplicationBasePath;
            var otro = Path.Combine(sera.ApplicationBasePath,"node_modules");
            var provider = new PhysicalFileProvider(otro);

            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = provider;

            app.UseStaticFiles(options);
            return app;
        }
    }
}
