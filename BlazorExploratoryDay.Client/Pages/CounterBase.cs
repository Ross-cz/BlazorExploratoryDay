using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace BlazorExploratoryDay.Client.Pages
{
	public class CounterBase : BlazorComponent
	{
		[Inject]
		protected IUriHelper uriHelper { get; set; }
		[Inject]
		protected HttpClient httpClient { get; set; }

		protected int currentCount = 0;

		public string CurrentUri => uriHelper.GetAbsoluteUri();

		protected void IncrementCount()
		{
			currentCount++;
		}
	}
}
