using Microsoft.AspNetCore.Mvc;
using Msit147Site.Models;

namespace Msit147Site.Controllers
{
    public class ApiController : Controller
    {   //依賴注入
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;

        public ApiController (DemoContext context,IWebHostEnvironment host) 
        { 
            _host = host;
            _context = context;
        }
        public IActionResult Index()
        {
            return Content("Hello Ajax!!");
            // return Content("<h2>Hello World!!</h2>","text/html");
            //return Content("<h2>Ajax 您好!!</h2>", "text/html", System.Text.Encoding.UTF8);

            //return Content("Hello World!!", "application/msword");
        }
        public IActionResult AjaxEvent(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                userName = "Guest";
            }
            Thread.Sleep(5000);
            return Content("Hello " + userName);
        }

        [HttpPost]
        public IActionResult Register(Members member,IFormFile Photo)
        {
            //Path.Combine 後面全部串起來
            string rootPath = Path.Combine(_host.WebRootPath, "uploads", Photo.FileName);
            //return Content($"Hello {member.Name}")
            using (var fileStream=new FileStream(rootPath,FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
            member.FileName = Photo.FileName;
            byte[]? photoByte = null;
            using(var memoryStream =new MemoryStream()) 
            {
                Photo.CopyTo(memoryStream);
                photoByte = memoryStream.ToArray();
            }
            member.FileData= photoByte;

            _context.Members.Add(member);
            _context.SaveChanges();

            return Content(rootPath);

        }



    }
}
