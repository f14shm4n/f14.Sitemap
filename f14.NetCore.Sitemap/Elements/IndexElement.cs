using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace f14.Sitemap
{
    /// <summary>
    /// Represents the sitemap entry for the sitemapindex.
    /// </summary>
    public sealed class IndexElement : SitemapElement
    {
        /// <summary>
        /// Create default entry.
        /// </summary>
        public IndexElement() { }
        /// <summary>
        /// Create entry with url.
        /// </summary>
        /// <param name="url">The specified resource url.</param>
        public IndexElement(string url) { Url = url; }

        public override XName RootElementName => SitemapConstants.NS + "sitemap";

        public override void BuildXElement(XElement root)
        {
            // Stub
        }
    }
}
