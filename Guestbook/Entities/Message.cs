namespace Guestbook.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string? MessageBody { get; set; }
        public int IsReplay { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
