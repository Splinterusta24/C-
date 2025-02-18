using Project.Data.Abstract;
using Project.Data.Repository;
using Project.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.EntityFramework
{
    public class EFProductDal:GenericRepository<Product>,IProductDal
    {
    }
}
