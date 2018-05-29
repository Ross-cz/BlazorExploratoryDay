using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExploratoryDay.Shared.Interfaces
{
	public interface IBlogPostsController
	{
		Task<IEnumerable<BlogPost>> GetBlogPosts();
	}
}
