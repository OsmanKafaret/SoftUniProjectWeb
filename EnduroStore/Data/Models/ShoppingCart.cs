﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Data.Models
{
    public class ShoppingCart
    {
    
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
    }
}
