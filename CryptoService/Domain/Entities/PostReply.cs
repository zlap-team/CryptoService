namespace Domain.Entities;

public class PostReply
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid UserId { get; set; }
    public virtual AppUser User { get; set; }

    public Guid PostId { get; set; }
}