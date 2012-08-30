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
                var serializer = new JsonDeserializer();
                dynamic payload = serializer.Convert(Defaults.ExamplePayload);
            }

            [Fact]
            public void HasRepositoryInfo()
            {
                var serializer = new JsonDeserializer();
                dynamic payload = serializer.Convert(Defaults.ExamplePayload);

                Assert.Equal("github", payload.repository.name);
            }
            
            [Fact]
            public void HasCommits()
            {
                var serializer = new JsonDeserializer();
                dynamic payload = serializer.Convert(Defaults.ExamplePayload);

                Assert.Equal(2, payload.commits.Length);
            }
        }
    }
}
