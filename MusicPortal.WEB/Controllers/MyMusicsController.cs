using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.Services;
using MusicPortal.DAL.Models;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Localization;
using System.Linq;
using MusicPortal.WEB.Models.ViewModels;
using System.Collections.Generic;

namespace MusicPortal.WEB.Controllers
{
    public class MyMusicsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyMusicService _myMusicsService;
        private readonly IMapper _mapper;
        private readonly UserManager<Author> _userManager;
        private readonly SignInManager<Author> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
         private readonly IAuthorService _authorService;

        public MyMusicsController(IWebHostEnvironment webHostEnvironment, IMyMusicInterface mymusicsService, IMapper mapper, UserManager<Author> userManager,
            SignInManager<Author> signInManager, IAuthorService authorService)
        {
            _webHostEnvironment = webHostEnvironment;
            _myMusicsService = (MyMusicService)mymusicsService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _authorService = authorService;
        }

        [Authorize]
        public async Task<IActionResult> AddMymusic(Guid id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            await _myMusicsService.AddAsync(id, Guid.Parse(currentUser.Id));
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public async Task<IActionResult> DeleteMyMusic(Guid id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            await _myMusicsService.DeleteAsync(id, Guid.Parse(currentUser.Id));
            return RedirectToAction("Index", "MyMusics");
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var myMusic = _myMusicsService.GetAll(Guid.Parse(currentUser.Id));
            var myMusicVM = _mapper.Map<ICollection<MyMusicVM>>(myMusic);
            return View(myMusicVM);
        }


    }
}
