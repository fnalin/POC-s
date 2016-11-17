using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;

namespace DemoWebApiOwin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            ConfigureWebApi(config);
            app.UseWebApi(config);
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            var formatters = config.Formatters;

            //Remove o XML
            formatters.Remove(formatters.XmlFormatter);

            //Config. o json de resposta
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;

            //Deixa a resposta identada e mais amigável (apenas p/ seres humanos)
            jsonSettings.Formatting = Formatting.Indented;

            //Deixa a serialização dos objetos em CamelCase (Default na Web)
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //Evita o loop infinito no case de objetvos encadeados
            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //Permite a configuração de rotas através do decorator [Route]
            config.MapHttpAttributeRoutes();

            //Nossa rota default
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}
