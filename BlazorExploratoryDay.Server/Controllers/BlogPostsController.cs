using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using BlazorExploratoryDay.Shared.Interfaces;
using BlazorExploratoryDay.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;

namespace BlazorWebApplication.Server.Controllers
{
	public class BlogPostsController : Controller, IBlogPostsController
	{
		[Route("api/blogposts")]
		public async Task<IEnumerable<BlogPost>> GetBlogPosts()
		{
			var xmlReader = Task.Run(() => XmlReader.Create("https://knowledge-base.havit.cz/feed/"));
			var rssReader = new RssFeedReader(await xmlReader);

			var blogPosts = new List<BlogPost>();
			while (await rssReader.Read())
			{
				if (rssReader.ElementType == SyndicationElementType.Item)
				{
					var item = await rssReader.ReadItem();

					blogPosts.Add(new BlogPost()
					{
						Title = item.Title,
						Author = item.Contributors.FirstOrDefault()?.Name,
						Created = item.Published.LocalDateTime,
						Description = item.Description,
						Link = item.Links.FirstOrDefault()?.Uri.AbsoluteUri
					});
				}
			}

			return blogPosts;
		}

	}
}
