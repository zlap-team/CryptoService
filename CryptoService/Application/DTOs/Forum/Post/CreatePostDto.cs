namespace Application.DTOs.Forum.Post;

public class CreatePostDto
{
    public string Title { get; set; }
    public string Description { get; set; }

    public Guid CreatorId { get; set; }
}