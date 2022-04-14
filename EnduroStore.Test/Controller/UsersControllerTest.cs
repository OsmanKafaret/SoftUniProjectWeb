using EnduroStore.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EnduroStore.Test.Controller
{
    using Xunit;
    public class UsersControllerTest
    {

        [Fact]
        public void Index_ShoudBeAccesseibleByAdmin()
        {
            var controller = new UsersController(null, null, null)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Role,"Admin")
                        }))
                    }
                }
            };

            Assert.True(controller.User.IsInRole("Admin"));
        }
   
    }
}
