using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Hakaton.Data
{
    public class DataContext : DbContext
    {



        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }
        
    }
}
