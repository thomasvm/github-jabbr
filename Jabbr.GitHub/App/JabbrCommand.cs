using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jabbr.GitHub
{
    public class JabbrCommand
    {
        public string Host { get; set; }

        public string Username { get; set; }

        public IList<string> Rooms { get; set; }

        public string Template { get; set; }

        public string Password { get; set; }

        public string UserId { get; set; }

        public string Message { get; set; }

        public JabbrCommand()
        {
            Rooms = new List<string>();
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Host))
                throw new ConfigException("No host specified");

            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(UserId))
                throw new ConfigException("No username or userid specified");

            if (!Rooms.Any())
                throw new ConfigException("No rooms specified");
        }

        public IList<string> GetMessages()
        {
            var messages = Message.Split('\n')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();

            return messages;
        }
    }
}