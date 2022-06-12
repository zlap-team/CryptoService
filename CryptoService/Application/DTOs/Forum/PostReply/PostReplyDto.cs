using Application.DTOs.Account;

namespace Application.DTOs.Forum.PostReply;

public class PostReplyDto
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid UserId { get; set; }
    public virtual BaseUserDto User { get; set; }

    public Guid ParentPostId { get; set; }
}