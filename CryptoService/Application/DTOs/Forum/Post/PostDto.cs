using Application.DTOs.Account;
using Application.DTOs.Forum.PostReply;
using Domain.Entities;

namespace Application.DTOs.Forum.Post;

public class PostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual BaseUserDto Creator { get; set; }
    public virtual ICollection<PostReplyDto> PostReplies { get; set; }
}