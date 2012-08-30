using System;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Web;
using Newtonsoft.Json;

namespace Jabbr.GitHub
{
    public class ConfigurationReader
    {
        private JsonDeserializer deserializer;
        public dynamic Value { get; private set; }

        private const string DEFAULTTEMPLATE = "Default.cshtml";

        public ConfigurationReader(JsonDeserializer deserializer)
        {
            this.deserializer = deserializer;
            string path = "config.json";

            if (HttpContext.Current != null)
                path = HttpContext.Current.Request.MapPath("~/config.json");

            string content = File.ReadAllText(path);
            Value = deserializer.Convert(content);
        }

        public ConfigurationReader(JsonDeserializer deserializer, string content)
        {
            this.deserializer = deserializer;
            Value = deserializer.Convert(content);
        }

        public JabbrCommand GetCommand(string repo)
        {
            dynamic @default = Value.@default ?? deserializer.Convert("{}");
            dynamic specific = Value[repo] ?? deserializer.Convert("{}");

            if(@default == null && specific == null)
                throw new InvalidOperationException("Invalid configuration");

            var command = new JabbrCommand
                       {
                           Host = specific.jabbr ?? @default.jabbr,
                           UserId = specific.userid ?? @default.userid,
                           Username = specific.user ?? @default.user,
                           Password = specific.password ?? @default.password,
                           Template = specific.template ?? @default.template ?? DEFAULTTEMPLATE
                       };

            foreach(string room in (specific.rooms ?? @default.rooms))
                command.Rooms.Add(room);

            command.Validate();

            return command;
        }
    }
}