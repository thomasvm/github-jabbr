using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Nancy;

namespace Jabbr.GitHub
{
    public class JsonDeserializer
    {
        public dynamic Convert(string json)
        {
            return System.Web.Helpers.Json.Decode(json);
        }
    }
}