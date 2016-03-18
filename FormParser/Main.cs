using System;
using HtmlAgilityPack;
using System.Collections;
using System.Text;

namespace FormParser
{
	class MainClass
	{
		public static void Main (string[] args)
		{			
			Crawler crawler = new Crawler("http://www.a101.com.tr/tr/Kariyer.aspx");

			HtmlNodeCollection selectCollection =  crawler.GetSelectCollection();

			if (selectCollection != null) {
				int i = 1;
				foreach (HtmlNode select in crawler.GetSelectCollection()) {
					StringBuilder text = new StringBuilder(String.Format("\n\r{0}. Select with id={1}", i++, select.Id));
					HtmlNodeCollection options = crawler.GetSelectOptionCollection(select);

					if (options != null) {
						foreach(HtmlNode option in options) {
							text.Append(String.Format(
								"\n\r\t option with value={0} and text={1}", 
								option.Attributes["value"].Value, 
								option.NextSibling.InnerText
							));
						}
					}
					Console.WriteLine(text);
				}
			}
		}
	}
}
