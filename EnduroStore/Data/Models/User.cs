using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Data.Models
{
    public class User : IdentityUser
    {

      
        public string FullName { get; set; }

       
    }
}
