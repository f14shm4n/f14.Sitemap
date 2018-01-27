using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace f14.Sitemap
{
    /// <summary>
    /// Represents the google image entry.
    /// </summary>
    public sealed class ImageElement : ISitemapElement
    {
        /// <summary>
        /// The resource url.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Image caption.
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// Image title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Image geo location.
        /// </summary>
        public string Geo { get; set; }
        /// <summary>
        /// Image license.
        /// </summary>
        public string License { get; set; }

        public XElement ToXElement()
        {
            var root = new XElement(SitemapConstants.NSGoogleImage + "image");
            root.Add(new XElement(SitemapConstants.NSGoogleImage + "loc", Url));

            if (!string.IsNullOrWhiteSpace(Caption))
            {
                root.Add(new XElement(SitemapConstants.NSGoogleImage + "caption", Caption));
            }
            if (!string.IsNullOrWhiteSpace(Title))
            {
                root.Add(new XElement(SitemapConstants.NSGoogleImage + "title", Title));
            }
            if (!string.IsNullOrWhiteSpace(Geo))
            {
                root.Add(new XElement(SitemapConstants.NSGoogleImage + "geo_location", Geo));
            }
            if (!string.IsNullOrWhiteSpace(License))
            {
                root.Add(new XElement(SitemapConstants.NSGoogleImage + "license", License));
            }
            return root;
        }
    }
}
