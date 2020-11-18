using Microsoft.EntityFrameworkCore;
using News_WebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace News_WebApp.Repository
{
    /*
     This class contains the code for data storage interactions and methods 
     of this class will be used by other parts of the applications such
     as Controllers and Test Cases
     */
    public class NewsRepository : INewsRepository
    {
        /* Declare a variable of NewsDbContext type to store 
         * all the news
        */

        /*
	        This method should accept News object as argument and add the new news object in
            NewsDbContext Object
	    */

        /*
        Use Async and await calls for AddNews(),GetAllNews(),GetNewsById() and RemoveNews()
        */


        /* Implement all the methods of respective interface asynchronously*/
        /* Implement AddNews method should accept News object as argument and add the new news object into 
              NewsDbContext Object*/

        /* Implement GetAllNews method should return all the news available in the the NewsDbContext Object*/

        /* Implement GetNewsById method should return the matching newsid details present in the 
         * the NewsDbContext Object*/

        /* Implement IsNewsExist method to check the news deatils exist or not*/

        /* Implement RemoveNews method should delete a specified news from the NewsDbContext Object*/
        private readonly NewsDbContext _context;
        public NewsRepository(NewsDbContext context)
        {
            _context = context;
        }

        public Task<News> AddNews(News news)
        {
            if(news.NewsId==0)
            {
                for (int x = 101; x < 10000; x++)
                {
                    var find = _context.NewsList?.ToList().Find(c => c.NewsId == x);
                    if (find == null)
                    {
                        news.NewsId = x;
                        break;
                    }
                }
            }
            
            _context.NewsList.Add(news);
            _context.SaveChanges();
            return Task.FromResult(news);
        }

        public Task<List<News>> GetAllNews(string userId=null)
        {
            if(userId==null)
            {
                return Task.FromResult(_context.NewsList.ToList());
            }
            return Task.FromResult(_context.NewsList.Where(x=>x.UserId==userId).ToList());
        }

        public Task<News> GetNewsById(int newsId)
        {
            return Task.FromResult(_context.NewsList.Where(x => x.NewsId == newsId).FirstOrDefault());
        }

        public Task<bool> RemoveNews(int newsId)
        {
            _context.NewsList.Remove(GetNewsById(newsId).Result);
            var result = _context.SaveChanges();
            return Task.FromResult(result > 0 ? true : false);
        }
    }
}
