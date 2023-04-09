using System.Collections.Generic;

namespace MusicPortal.WEB.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<MusicVM> Musics { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
