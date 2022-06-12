using API.Controllers.Base;
using Application.DTOs.Forum.Post;
using Application.DTOs.Forum.PostReply;
using Application.Features.Forum.Post.Query;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ForumController : BaseApiController
{
    /// <summary>
    /// Get all posts with Creator and Post replies
    /// </summary>
    /// <returns></returns>
    [HttpGet("posts")]
    public async Task<ActionResult<List<PostDto>>> GetAllPosts()
    {
        var results = await Mediator.Send(new GetAllPosts.Query());

        return HandleResult(results);
    }
    
    /// <summary>
    /// Get all posts with Creator and Post replies
    /// </summary>
    /// <returns></returns>
    [HttpGet("post-replies/{postId}")]
    public async Task<ActionResult<List<PostReplyDto>>> GetAllPostReplies(string postId)
    {
        var results = await Mediator.Send(new GetAllPosts.Query());

        return HandleResult(results);
    }
}