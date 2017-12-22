using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace f14.NetCore.Sitemap
{
    /// <summary>
    /// Provides some useful values.
    /// </summary>
    public sealed class Constants
    {
        /// <summary>
        /// http://www.sitemaps.org/schemas/sitemap/0.9
        /// </summary>
        public static readonly XNamespace NS = "http://www.sitemaps.org/schemas/sitemap/0.9";
        /// <summary>
        /// http://www.google.com/schemas/sitemap-image/1.1
        /// </summary>
        public static readonly XNamespace NSGoogleImage = "http://www.google.com/schemas/sitemap-image/1.1";

        /// <summary>
        /// The sitemapindex name. Name include the root namespace.
        /// </summary>
        public static readonly XName SitemapIndexName = NS + "sitemapindex";
        /// <summary>
        /// The urlset name. Name include the root namespace.
        /// </summary>
        public static readonly XName UrlsetName = NS + "urlset";

        /// <summary>
        /// The google image namespace.
        /// </summary>
        public static readonly XAttribute GoogleImageAttribute = new XAttribute(XNamespace.Xmlns + "image", NSGoogleImage);
    }
}
