using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorExploratoryDay.Shared
{
	public class BlogPost
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public DateTime Created { get; set; }
		public string Link { get; set; }
		public string Description { get; set; }
	}
}
