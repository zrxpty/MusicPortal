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
using MusicPortal.DAL;

namespace MusicPortal.WEB.Controllers
{
    public class MyMusicsController : Controller
    {

        private readonly MyMusicService _myMusicsService;
        private readonly IMapper _mapper;
        private readonly UserManager<Author> _userManager;
        

        public MyMusicsController(
            IWebHostEnvironment webHostEnvironment, IMyMusicInterface mymusicsService, IMapper mapper, UserManager<Author> userManager)
        {
            _myMusicsService = (MyMusicService)mymusicsService;
            _mapper = mapper;
            _userManager = userManager;

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
