using f14.NetCore.Sitemap;
using f14.NetCore.Sitemap.Abstractions;
using f14.NetCore.Sitemap.Entries;
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
            var items = new IndexEntry[count];

            for (var i = 0; i < count; i++)
            {
                items[i] = new IndexEntry
                {
                    Url = "http://example.com/page" + (i + 1),
                    Modified = DateTime.Now.Add(TimeSpan.FromMinutes(i + 1))
                };
            }

            var xDoc = SitemapBuilder.Build(new SitemapBuilderData
            {
                RootElement = new XElement(Constants.SitemapIndexName),
                Elements = items
            });

            Assert.Equal(count, xDoc.Root.Descendants(Constants.NS + "sitemap").Count());

            xDoc.Save("sitemap_index.xml");
        }

        [Fact]
        public void Urlset()
        {
            const int count = 10;
            var items = new UrlEntry[count];

            for (var i = 0; i < count; i++)
            {
                var urlEntry = new UrlEntry
                {
                    Url = "http://example.com/page" + (i + 1),
                    Modified = DateTime.Now.Add(TimeSpan.FromMinutes(i + 1)),
                    ChangeFrequency = ChangeFrequency.Always,
                    Priority = 1
                };

                for (var j = 0; j < 5; j++)
                {
                    urlEntry.Images.Add(new ImageEntry
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

            var xDoc = SitemapBuilder.Build(new SitemapBuilderData
            {
                RootElement = new XElement(Constants.UrlsetName, Constants.GoogleImageAttribute),
                Elements = items
            });

            Assert.Equal(count, xDoc.Root.Descendants(Constants.NS + "url").Count());

            xDoc.Save("urlset.xml");
        }
    }
}
