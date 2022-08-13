namespace Guestbook.Dto.Message
{
    public class MessageForCreationDto
    {
        public string Message { get; set; }
        public int IsReplay { get; set; }
        public int UserId { get; set; }
        public int MainMessageId { get; set; } = 0;
    }
}
