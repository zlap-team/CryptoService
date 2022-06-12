namespace Domain.Entities;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    // stworzone przez
    public Guid CreatorId { get; set; }
    public virtual AppUser Creator { get; set; }
    
    // odpowiedzi
    public virtual IList<PostReply> PostReplies { get; set; }

    public void AddReplyToPost(PostReply reply)
    {
        PostReplies.Add(reply);
    }
}