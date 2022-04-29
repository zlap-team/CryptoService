namespace Application.DTOs.Forum.PostReply;

public class CreatePostReplyDto
{
    public string Message { get; set; }
    public Guid UserId { get; set; }
}