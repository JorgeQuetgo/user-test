using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace user_test.Data
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            :base(options)
        {

        }

        public DbSet<User> User { get; set; }
    }
}
