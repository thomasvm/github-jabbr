using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Jabbr.GitHub.Tests
{
    public class JsonDeserializerFacts
    {
        public class WithPayLoad
        {
            [Fact]
            public void Succeeds()
            {
                dynamic payload = Json.Convert(Defaults.ExamplePayload);
            }

            [Fact]
            public void HasRepositoryInfo()
            {
                dynamic payload = Json.Convert(Defaults.ExamplePayload);

                Assert.Equal("github", payload.repository.name);
            }
            
            [Fact]
            public void HasCommits()
            {
                dynamic payload = Json.Convert(Defaults.ExamplePayload);

                Assert.Equal(2, payload.commits.Length);
            }
        }
    }
}
