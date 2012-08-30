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
                Reader = new ConfigurationReader(new JsonDeserializer(),
                    @" {
                            default: {
                                jabbr: ""http://yourjabbbr.net"",
                                rooms: [ ""roomA"" ],
                                userid: ""achieved through /who yourusername""        
                            },
                            ""repo-a"": {                                
                                rooms: [ ""roomA"", ""roomB"" ]
                            }
                        }");
            }

            [Fact]
            public void Succeeds()
            {
                Reader.GetCommand("repo-a");
            }

        }
    }
}
