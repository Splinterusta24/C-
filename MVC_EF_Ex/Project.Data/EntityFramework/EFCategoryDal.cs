using Project.Data.Abstract;
using Project.Data.Repository;
using Project.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.EntityFramewor
{
    public class EFCategoryDal : GenericRepository<Category>,ICategoryDal
    {
    }
}
