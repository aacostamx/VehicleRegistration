using System.Web.Http;
using WebActivatorEx;
using Inkript.VR.API;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Inkript.VR.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1_1_8", "Inkript.VR.API");
                    })
                .EnableSwaggerUi(c => { c.DisableValidator(); });
        }
    }
}
