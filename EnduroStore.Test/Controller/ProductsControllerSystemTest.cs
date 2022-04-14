using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduroStore.Test.Controller
{
    using Xunit;
    using Microsoft.AspNetCore.Mvc.Testing;
    public class ProductsControllerSystemTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public ProductsControllerSystemTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }
        [Fact]
        public async Task ProductDetailsShouldReturnCorrect()
        {
            var client = this.factory.CreateClient();

            var result = await client.GetAsync("/Products/Details/24");

            Assert.True(result.IsSuccessStatusCode);
        }

        [Fact]
        public async Task ProductDetailsShouldReturnInCorrect()
        {
            var client = this.factory.CreateClient();

            var result = await client.GetAsync("/Products/Detail/24");

            Assert.False(result.IsSuccessStatusCode);
        }

        public async Task FinishedProductsShouldReturnCorrectUrl()
        {
            var client = this.factory.CreateClient();

            var result = await client.GetAsync("/Admin/Products/FinishedProducts");

            Assert.True(result.IsSuccessStatusCode);
        }

    }
}
