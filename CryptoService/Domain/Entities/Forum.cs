namespace Domain.Entities;

public class Forum
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Post> Posts { get; set; }
}