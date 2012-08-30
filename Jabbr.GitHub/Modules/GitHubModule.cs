using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Nancy;

namespace Jabbr.GitHub
{
    public class GitHubModule : NancyModule
    {
        public GitHubModule(ConfigurationReader reader, JsonDeserializer deserializer, TemplateRender renderer)
        {
            Get["/"] = parameters => "Running!";

            Post["/github"] = parameters =>
                                  {
                                      dynamic payload = deserializer.Convert(Request.Form.payload);

                                      string repository = payload.repository.name;
                                      var command = reader.GetCommand(repository);

                                      string template = command.Template;
                                      string message = renderer.Render(template, payload);
                                      

                                      return "Send!";
                                 };
        }
    }
}