using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jabbr.GitHub
{
    public class ConfigException : Exception
    {
        public ConfigException(string message) 
            : base(message)
        {
        }
    }
}