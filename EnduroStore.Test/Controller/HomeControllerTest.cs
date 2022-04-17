using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EnduroStore.Test.Controller
{
    using MyTested.AspNetCore.Mvc;
    using static Data.Products;
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

      //  [Fact]
      //  public void IndexShouldReturnCorrectViewWithModel()
      //     => MyController<HomeController>
      //         .Instance(controller => controller
      //             .WithData(TenUnfinishedProducts))
      //         .Calling(c => c.Index())
      //        
      //         .AndAlso()
      //         .ShouldReturn()
      //         .View(view => view
      //             .WithModelOfType<List<LatestCarServiceModel>>()
      //             .Passing(model => model.Should().HaveCount(3)));
      //
        

      
        
    }
}
