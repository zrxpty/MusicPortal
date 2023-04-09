using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.Models;
using MusicPortal.WEB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace MusicPortal.WEB.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        private readonly UserManager<Author> _userManager;
        private readonly SignInManager<Author> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AuthorController(IAuthorService authorService, IMapper mapper, UserManager<Author> userManager,
            SignInManager<Author> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            _authorService = authorService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;

        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Authors = _mapper.Map<ICollection<AuthorVM>>(_authorService.GetAll());
            return View();
        }

       

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            ViewBag.MusicsAuthor = _mapper.Map<ICollection<MusicVM>>((await _authorService.GetAsync(x => x.Id == id.ToString()))?.Musics);
            AuthorVM authorVM = _mapper.Map<AuthorVM>(await _authorService.GetAsync(x => x.Id == id.ToString()));
            return View(authorVM);
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var idSign = _userManager.GetUserId(User);
            AuthorVM authorVM = _mapper.Map<AuthorVM>(await _authorService.GetAsync(x => x.Id == idSign));
            return View(authorVM);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(AuthorVM authorVM)
        {
            var author = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                author.NickName = authorVM.NickName;
                author.Age = authorVM.Age;
                author.Biography = authorVM.Biography;
                author.mainGenre = authorVM.mainGenre;
                author.linkInstagram = authorVM.linkInstagram;
                author.linkYouTube = authorVM.linkYouTube;
                author.linkVK = authorVM.linkVK;
                author.linkOther = authorVM.linkOther;


                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                if (files.Count > 0)
                {
                    string upload = webRootPath + wc.AuthorPath;
                    string fileName = author.Id.ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    if (author.imagePath != null && author.imagePath.Length > 2)
                    {
                        System.IO.File.Delete(webRootPath + wc.AuthorPath + author.imagePath);
                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                    }
                    else
                    {
                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                    }

                    author.imagePath = fileName + extension;
                }


            }


            await _authorService.UpdateAsync(_mapper.Map<AuthorDTO>(author));
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> SubscribeToAuthor(Guid id)
        {
            var author = await _userManager.GetUserAsync(User);
            var authorToSub = await _authorService.GetAsync(x => x.Id == id.ToString());
            await _authorService.AddAuthorAsync(Guid.Parse(author.Id), Guid.Parse(authorToSub.Id));
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<IActionResult> UnsubscribeFromAuthor(Guid id)
        {
            var author = await _userManager.GetUserAsync(User);
            var authorToUnSub = await _authorService.GetAsync(x => x.Id == id.ToString());
            await _authorService.RemoveSubAuthorAsync(Guid.Parse(author.Id), Guid.Parse(authorToUnSub.Id));
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UnsubscribeFromAuthorPost(Guid id)
        {
            var author = await _userManager.GetUserAsync(User);
            var authorToUnSub = await _authorService.GetAsync(x => x.Id == id.ToString());
            await _authorService.RemoveSubAuthorAsync(Guid.Parse(author.Id), Guid.Parse(authorToUnSub.Id));
            return RedirectToAction("Index");
        }
       


    }
}
