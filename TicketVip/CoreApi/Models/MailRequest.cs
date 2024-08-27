namespace CoreApi.Models
{
    public class MailContent
    {
        public string To { get; set; }              // Địa chỉ gửi đến
        public string Subject { get; set; }         // Chủ đề (tiêu đề email)
        public string Body { get; set; }
        //  public virtual List<IFormFile>? Attachments { get; set; }
    }
}
