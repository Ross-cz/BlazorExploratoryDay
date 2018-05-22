using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using BlazorWebApplication.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;

namespace BlazorWebApplication.Server.Controllers
{
	public class BlogPostsController : Controller
	{
		[Route("api/blogposts")]
		public IEnumerable<BlogPost> GetBlogPosts()
		{
			var xmlReader = XmlReader.Create("https://knowledge-base.havit.cz/feed/");
			var rssReader = new RssFeedReader(xmlReader);

			while (rssReader.Read().Result)
			{
				if (rssReader.ElementType == SyndicationElementType.Item)
				{
					var item = rssReader.ReadItem().Result;
					yield return new BlogPost()
					{
						Title = item.Title,
						Author = item.Contributors.FirstOrDefault()?.Name,
						Created = item.Published.LocalDateTime,
						Description = item.Description,
						Link = item.Links.FirstOrDefault()?.Uri.AbsoluteUri
					};
				}
			}

			yield break;
		}
	}
}
