using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduroStore.Test.Controller
{
    using EnduroStore.Areas.Admin.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;
    public class HomeControllerTest
    {

        [Fact]
        public void ErrorShouldReturnView()
        {
            var homeController = new HomeController(null);

            var result = homeController.Error();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
      
    }
}
