using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Cryptonit.Models
{
    public class DbUserContext: DbContext
    {
        public DbSet<User> users { get; set; }
    }
}