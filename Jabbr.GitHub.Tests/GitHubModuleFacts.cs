using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.Testing;
using Newtonsoft.Json;
using Xunit;

namespace Jabbr.GitHub.Tests
{
    public class GitHubModuleFacts
    {
        public class GitHub
        {
            protected Browser Browser { get; set; }
            
            [Fact]
            public void WithPayLoad_Succeeds()
            {
                var browser = Defaults.Browser(with => with.Dependency<ConfigurationReader>(Defaults.DefaultConfig));

                var result = browser.Post("/github",
                                          (with) =>
                                              {
                                                  with.HttpRequest();
                                                  with.FormValue("payload", Defaults.ExamplePayload);
                                              });

                Assert.Equal("Send!", result.Body.AsString());
            }
        }
    }
}
