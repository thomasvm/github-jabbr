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
        public GitHubModule(ConfigurationReader reader, 
                            TemplateRender renderer,
                            IJabbrSend jabbrSend)
        {
            Get["/"] = parameters => "Running!";

            Post["/github"] = parameters =>
                                  {
                                      // get payload
                                      dynamic payload = Json.Convert(Request.Form.payload);

                                      // compose command from config
                                      string repository = payload.repository.name;
                                      var command = reader.GetCommand(repository);

                                      // generate messages from template
                                      string template = command.Template;
                                      string message = renderer.Render(template, payload);

                                      // send message
                                      command.Message = message;
                                      jabbrSend.Send(command);
                                      
                                      return "Send!";
                                  };
        }
    }
}