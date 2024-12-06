using CSharpStudentCamp301.DataAccessLayer.Abstract;
using CSharpStudentCamp301.DataAccessLayer.Respositories;
using CSharpStudentCamp301.EntityLayer.Concrete;
using System;


namespace CSharpStudentCamp301.DataAccessLayer.EntityFramework
{
    public class EfProductDal: GenericRepository<Product>, IProductDal
    {
    }
}
