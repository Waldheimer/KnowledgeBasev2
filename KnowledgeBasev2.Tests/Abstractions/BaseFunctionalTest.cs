using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeBasev2.Tests.Abstractions
{
    public class BaseFunctionalTest : IClassFixture<TestWebAppFactory>
    {
        protected HttpClient HttpClient { get; init; }
        public BaseFunctionalTest(TestWebAppFactory factory)
        {
            HttpClient = factory.CreateClient();
        }
    }
}
