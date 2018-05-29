using BlazorExploratoryDay.Client.ClientServices;
using BlazorExploratoryDay.Shared.Interfaces;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlazorExploratoryDay.Client
{
	public class Program
	{
		static void Main(string[] args)
		{
			var serviceProvider = new BrowserServiceProvider(services =>
			{
				services.AddTransient<IBlogPostsController, DataAccess>();
			});

			new BrowserRenderer(serviceProvider).AddComponent<App>("app");
		}
	}
}
