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
using System.IO;
using System.Threading.Tasks;

namespace MusicPortal.WEB.Controllers
{
    [Authorize]
    public class MyMusicController : Controller
    {


        private readonly ILogger<HomeController> _logger;
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;
        private readonly UserManager<Author> _userManager;
        private readonly SignInManager<Author> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MyMusicController(IWebHostEnvironment webHostEnvironment, IMusicService musicService, IMapper mapper, UserManager<Author> userManager,
            SignInManager<Author> signInManager)
        {
            _webHostEnvironment = webHostEnvironment;
            _musicService = musicService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.MyMusic = _mapper.Map<ICollection<MusicVM>>(_musicService.GetAllMyMusic(await _userManager.GetUserAsync(User))); ;
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {

            return View(new MusicVM());
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(MusicVM musicVM, string AuthorId)
        {

            if (musicVM.Id == default)
            {
                try
                {
                    musicVM.Id = Guid.NewGuid();
                    musicVM.Author = await _userManager.FindByNameAsync(AuthorId);

                    musicVM.Date = DateTime.Today;

                    var files = HttpContext.Request.Form.Files;
                    string webRootPath = _webHostEnvironment.WebRootPath;

                    string upload = webRootPath + wc.MusicPath;
                    string fileName = Guid.NewGuid().ToString();
                    string ext = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + ext), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    if (ext == ".mp3" || ext == ".ogg" || ext == ".wav")
                    {
                        musicVM.filesMusic = fileName + ext;
                        await _musicService.AddAsync(_mapper.Map<MusicDTO>(musicVM));
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index");
                }

            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var authorId = _userManager.GetUserId(User);
            var music = _mapper.Map<MusicVM>(await _musicService.GetAsync(x => x.Id == id));
            if (music.Author.Id == authorId)
            {
                await _musicService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
