using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_WebApp.Models;
using News_WebApp.Repository;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
namespace News_WebApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;
        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        /*
         * From the problem statement, we can understand that the application
         * requires us to implement the following functionalities.
         * 
         * 1. Display the list of existing news from the collection. Each news 
         *    should contain NewsId, title, content,PublishedAt and UrlToImage.
         * 2. Add a new news which should contain the Newsid, title, content and PublishedAt
         *    and UrlToImage(to upload an Image).
         *    Note:uploaded image strore it in wwwroot/images folder
         *    
         * 3. Delete an existing News.
     */
        [HttpGet]
        public async Task<ViewResult> Index()
        {
            var news = new News();
            ViewData["newslist"]= await _newsRepository.GetAllNews(TempData.Peek("uId").ToString());            
            return View("Index", news);
        }

        
        [HttpPost]
        public async Task<IActionResult> Index(News news)
        {
            //if(ModelState.IsValid)
            //{
            var newsId = news.NewsId;
            if(newsId==0)
            {
                var newsList = await _newsRepository.GetAllNews(null);
                for (int x = 101; x < 10000; x++)
                {
                    var find = newsList?.Find(c => c.NewsId == x);
                    if (find == null)
                    {
                        newsId = x;
                        break;
                    }
                }
            }
            
            if (news != null)
            {
                if (System.IO.File.Exists(news.UrlToImage))
                {
                    FileInfo fi = new FileInfo(news.UrlToImage);
                    var fileContent = System.IO.File.ReadAllBytes(news.UrlToImage);
                    var path = Path.GetFullPath("wwwroot/images");

                    news.UrlToImage = $"/images/{newsId + 1}{fi.Extension}";
                    System.IO.File.WriteAllBytes($"{path}\\{newsId + 1}{fi.Extension}", fileContent);

                }
                else
                {
                    news.UrlToImage = "dummy";
                }
                news.NewsId = newsId;
                news.UserId = TempData.Peek("uId").ToString();
                await _newsRepository.AddNews(news);
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        [Route("news/details/{newsId}")]
        public async Task<IActionResult> Details(int newsId)
        {
            var currentNews = await _newsRepository.GetNewsById(newsId);
            return View(currentNews);
        }

        [Route("news/delete/{newsId}")]
        public async Task<IActionResult> Delete(int newsId)
        {
            var newsToBeDeleted = await _newsRepository.RemoveNews(newsId);
            return RedirectToAction("Index");
        }
        /* 
         * Retrieve the NewsRepository object from the dependency Container through constructor Injection.
         */


        /*Define a handler method to read the existing News by calling the GetNews() method 
         * of the NewsRepository class and pass to view. it should map to the default URL i.e. "/" */


        /*Define a handler method which will accept newsid as a parameter 
         * and return the available news details of the newsid by calling the GetNewsById() of News
         * Repository class
        */


        /* Define a handler method to delete an existing News by calling the RemoveNews() method 
         * of the NewsRepository class
        */
    }
}
