using API.Controllers.Base;
using Application.DTOs.Forum.Post;
using Application.DTOs.Forum.PostReply;
using Application.Features.Forum.Post.Command;
using Application.Features.Forum.Post.Query;
using Application.Features.Forum.PostReply.Command;
using Application.Features.Forum.PostReply.Query;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ForumController : BaseApiController
{
    /// <summary>
    /// Get all posts with Creator and Post replies
    /// </summary>
    [HttpGet("posts")]
    public async Task<ActionResult<List<PostDto>>> GetAllPosts()
    {
        var results = await Mediator.Send(new GetAllPosts.Query());

        return HandleResult(results);
    }
    
    /// <summary>
    /// Get single Post based on ID with Creator and Replies
    /// </summary>
    [HttpGet("posts/{postId}")]
    public async Task<ActionResult<PostDto>> GetPost(string postId)
    {
        var results = await Mediator.Send(new GetPost.Query {PostId = postId});

        return HandleResult(results);
    }
    
    /// <summary>
    /// Get all post Replies
    /// </summary>
    [HttpGet("post-replies/{postId}")]
    public async Task<ActionResult<List<PostReplyDto>>> GetAllPostReplies(string postId)
    {
        var results = await Mediator.Send(new GetAllPostReplies.Query {PostId = postId});

        return HandleResult(results);
    }

    /// <summary>
    /// Create new post with Creator info
    /// </summary>
    [HttpPost("create-post")]
    public async Task<ActionResult> CreatePost([FromBody] CreatePostDto createPostDto)
    {
        var result = await Mediator.Send(new CreatePost.Command {PostModel = createPostDto});

        return HandleResult(result);
    }
    
    /// <summary>
    /// Add reply to existing Post
    /// </summary>
    [HttpPut("{postId}/add-reply")]
    public async Task<ActionResult> CreatePost(string postId, [FromBody] CreatePostReplyDto createPostReplyDto)
    {
        var result = await Mediator.Send(new CreatePostReply.Command
        {
            ParentPostId = postId,
            PostReplyModel = createPostReplyDto
        });

        return HandleResult(result);
    }
}