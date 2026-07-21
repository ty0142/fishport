namespace FishPort.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string NickName { get; set; } = string.Empty;

        public string CommentText { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
