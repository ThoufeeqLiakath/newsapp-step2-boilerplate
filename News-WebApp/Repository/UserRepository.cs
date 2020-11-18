using News_WebApp.Models;
using System.Linq;
namespace News_WebApp.Repository
{
    //Inherit IUserRepository and implement the function declared in the interface
    public class UserRepository : IUserRepository

    {
        /* use 'IsAuthenticated function which accepts two agruments i.e userId and password to reuturn 
         * true or false value depending on the user credentials are correct or not
        */
        private readonly NewsDbContext _context;
        public UserRepository(NewsDbContext context)
        {
            _context = context;
        }
        public bool IsAuthenticated(string userId, string password)
        {
            var password1 = "password@123";
            if ((userId=="Jack"||userId=="John")&&password==password1)
            {
                return true;
            }
            return false;
            
        }
    }
}
