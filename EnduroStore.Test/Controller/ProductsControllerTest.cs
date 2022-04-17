using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduroStore.Test.Controller
{
    using Xunit;
    using Microsoft.AspNetCore.Mvc.Testing;
    using EnduroStore.Test.Mocks;
    using EnduroStore.Models.Products;
    using Microsoft.AspNetCore.Mvc;
    using EnduroStore.Services.Products;
    using Microsoft.EntityFrameworkCore;
    using EnduroStore.Data;
    using EnduroStore.Data.Models;
    using MongoDB.Driver;

    public class ProductsControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public ProductsControllerTest(WebApplicationFactory<Startup> factory)
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
