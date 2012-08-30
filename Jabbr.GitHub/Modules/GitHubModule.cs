using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;

namespace Jabbr.GitHub
{
    public class GitHubModule : NancyModule
    {
        public GitHubModule(ConfigurationReader reader, JsonDeserializer deserializer)
        {
            Get["/"] = parameters => "Running!";

            Post["/github"] = parameters =>
                                  {
                                      dynamic payload = deserializer.Convert(Request.Form.payload);
                                      string repository = payload.repository.name;

                                      return "Send!";
                                 };
        }
    }
}