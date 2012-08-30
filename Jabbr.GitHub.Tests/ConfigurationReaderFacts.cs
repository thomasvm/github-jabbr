using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Jabbr.GitHub.Tests
{
    public class ConfigurationReaderFacts
    {
        public class GetCommand
        {
            private ConfigurationReader Reader;

            public GetCommand()
            {
                Reader = Defaults.DefaultConfig;
            }

            [Fact]
            public void Succeeds()
            {
                Reader.GetCommand("repo-a");
            }
        }
    }
}
