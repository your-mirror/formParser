using System;
using HtmlAgilityPack;

namespace FormParser
{
	public class Crawler
	{
		private HtmlDocument _htmlDocument;
		public HtmlDocument HtmlDocument { get { return _htmlDocument; } set { _htmlDocument = value; } }

		public Crawler() {}

		public Crawler(string url) : base() {
			Load(url);
		}
		
		public void Load(string url)
		{
			HtmlWeb web = new HtmlWeb();
			_htmlDocument = web.Load(url);
		}

		public HtmlNodeCollection GetSelectCollection(string regex="//select[contains(@name, 'ctl00')]") 
		{
			return _htmlDocument.DocumentNode.SelectNodes(regex);
		}

		public HtmlNodeCollection GetSelectOptionCollection(HtmlNode select, string regex = ".//option", bool removeOption = true) 
		{
			if (removeOption) {
				HtmlNode.ElementsFlags.Remove ("option");
			}
			return select.SelectNodes(regex);
		}
	}
}

