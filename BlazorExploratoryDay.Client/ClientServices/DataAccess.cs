using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using BlazorExploratoryDay.Shared;
using BlazorExploratoryDay.Shared.Interfaces;

namespace BlazorExploratoryDay.Client.ClientServices
{
	public class DataAccess : IBlogPostsController
	{
		private readonly HttpClient client;

		public DataAccess(HttpClient httpClient)
		{
			client = httpClient;
		}

		public async Task<IEnumerable<BlogPost>> GetBlogPosts()
		{
			return await client.GetJsonAsync<IEnumerable<BlogPost>>("/api/BlogPosts");
		}
	}
}
