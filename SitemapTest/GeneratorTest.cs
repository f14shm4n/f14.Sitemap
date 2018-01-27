using f14.Sitemap;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Xunit;
using Xunit.Abstractions;

namespace SitemapTest
{
    public class GeneratorTest
    {
        private ITestOutputHelper log;

        public GeneratorTest(ITestOutputHelper output)
        {
            log = output;
        }

        private void Print(XElement root)
        {
            foreach (var o in root.Elements())
            {
                log.WriteLine(o.Name.ToString());
            }
        }

        [Fact]
        public void SitemapIndex()
        {
            const int count = 10;
            var items = new IndexElement[count];

            for (var i = 0; i < count; i++)
            {
                items[i] = new IndexElement
                {
                    Url = "http://example.com/page" + (i + 1),
                    Modified = DateTime.Now.Add(TimeSpan.FromMinutes(i + 1))
                };
            }

            var xDoc = SitemapBuilder.BuildIndexMap(items);

            Assert.Equal(count, xDoc.Root.Descendants(SitemapConstants.NS + "sitemap").Count());

            xDoc.Save("sitemap_index.xml");
        }

        [Fact]
        public void Urlset()
        {
            const int count = 10;
            var items = new UrlElement[count];

            for (var i = 0; i < count; i++)
            {
                var urlEntry = new UrlElement
                {
                    Url = "http://example.com/page" + (i + 1),
                    Modified = DateTime.Now.Add(TimeSpan.FromMinutes(i + 1)),
                    ChangeFrequency = ChangeFrequency.Always,
                    Priority = 1
                };

                for (var j = 0; j < 5; j++)
                {
                    urlEntry.Images.Add(new ImageElement
                    {
                        Url = "http://example.com/page" + i + "/image" + j + ".jpg",
                        Caption = "Image caption " + j,
                        Geo = "geo location address",
                        Title = "Image title " + j,
                        License = "License"
                    });
                }

                items[i] = urlEntry;
            }

            var xDoc = SitemapBuilder.BuildUrlset(items);

            Assert.Equal(count, xDoc.Root.Descendants(SitemapConstants.NS + "url").Count());

            xDoc.Save("urlset.xml");
        }
    }
}
