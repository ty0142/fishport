using FishPort.Models;
using System.ComponentModel.DataAnnotations;

namespace FishPort.ViewModels
{
    public class PortDetailsViewModel
    {
        public Port Port { get; set; } =　null!;
        public string PrefectureName { get; set; } = string.Empty;
        public string AreaName { get; set; } = string.Empty;
        public List<CommentViewModel> Comments { get; set; } = new();

        // コメント投稿用
        public Comment NewComment { get; set; } = new();
    }
}
