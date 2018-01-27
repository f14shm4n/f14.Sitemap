using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace f14.Sitemap
{
    /// <summary>
    /// Represents the url entry for the urlset.
    /// </summary>
    public sealed class UrlElement : SitemapElement
    {
        /// <summary>
        /// The resource change frequency.
        /// </summary>
        public ChangeFrequency? ChangeFrequency { get; set; }
        /// <summary>
        /// The update priority.
        /// </summary>
        public double? Priority { get; set; }
        /// <summary>
        /// The images collection.
        /// </summary>
        public List<ImageElement> Images { get; set; } = new List<ImageElement>();
        /// <summary>
        /// Create default url entry.
        /// </summary>
        public UrlElement() { }
        /// <summary>
        /// Create url entry wit specified url.
        /// </summary>
        /// <param name="url">The specified resource url.</param>
        public UrlElement(string url)
        {
            Url = url;
        }

        public override XName RootElementName => SitemapConstants.NS + "url";

        public override void BuildXElement(XElement root)
        {
            if (ChangeFrequency.HasValue)
            {
                root.Add(new XElement(SitemapConstants.NS + "changefreq", ChangeFrequency.Value.ToString().ToLower()));
            }

            if (Priority.HasValue)
            {
                root.Add(new XElement(SitemapConstants.NS + "priority", Priority.Value.ToString("N1")));
            }

            if (Images.Count > 0)
            {
                foreach (var i in Images.Take(1000))
                {
                    root.Add(i.ToXElement());
                }
            }
        }
    }
}
