using EnduroStore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduroStore.Test.Mocks
{
    public static class DatabaseMock
    {
        public static EnduroStoreDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<EnduroStoreDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

                return new EnduroStoreDbContext(dbContextOptions);
            }
        }
    }
}
