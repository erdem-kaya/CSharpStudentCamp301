using CSharpStudentCamp301.DataAccessLayer.Abstract;
using CSharpStudentCamp301.DataAccessLayer.Respositories;
using CSharpStudentCamp301.EntityLayer.Concrete;



namespace CSharpStudentCamp301.DataAccessLayer.EntityFramework
{
    public class EfAdminDal:GenericRepository<Admin>, IAdminDal
    {
    }
}
