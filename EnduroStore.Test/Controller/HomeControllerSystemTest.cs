using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduroStore.Test.Controller
{
    using Xunit;
    using Microsoft.AspNetCore.Mvc.Testing;
   public  class HomeControllerSystemTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public HomeControllerSystemTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }
        [Fact]
        public async Task IndexShpuldReturnCorrectResult()
        {
            var client = this.factory.CreateClient();

            var result = await client.GetAsync("/");

            Assert.True(result.IsSuccessStatusCode);
        }

    }
}
