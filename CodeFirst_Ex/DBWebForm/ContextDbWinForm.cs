using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWebForm
{
    public class ContextDbWinForm:DbContext
    {
        DbSet<Product> Products { get; set; }
    }
}
