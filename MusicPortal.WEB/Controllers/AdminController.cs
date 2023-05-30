using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.Services;
using MusicPortal.DAL.Models;
using MusicPortal.WEB.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicPortal.WEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<Author> _userManager; 
        private readonly IAuthorService _authorService;
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;

        public AdminController(
            IMapper mapper,
            UserManager<Author> userManager, IAuthorService authorService,
            IMusicService musicService)
        { 
            _musicService= musicService;
            _mapper = mapper;
            _userManager= userManager;
            _authorService= authorService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllMusic()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var crnt = _mapper.Map<AuthorVM>(await _authorService.GetAsync(x => x.Id == currentUser.Id));
            if (crnt.Role.Name != "Admin") {
                RedirectToAction("Home", "Index"); 
            }
            
            return View(_mapper.Map<ICollection<MusicVM>>(_musicService.GetAll()));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var crnt = _mapper.Map<AuthorVM>(await _authorService.GetAsync(x => x.Id == currentUser.Id));
            if (crnt.Role.Name != "Admin")
            {
                RedirectToAction("Home", "Index");
            }
            return View();
        }
    }
}
