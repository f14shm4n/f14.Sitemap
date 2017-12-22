using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace f14.NetCore.Sitemap.Entries
{
    /// <summary>
    /// Represents the sitemap entry for the sitemapindex.
    /// </summary>
    public sealed class IndexEntry : BaseEntry
    {
        /// <summary>
        /// Create default entry.
        /// </summary>
        public IndexEntry() { }
        /// <summary>
        /// Create entry with url.
        /// </summary>
        /// <param name="url">The specified resource url.</param>
        public IndexEntry(string url) { Url = url; }

        public override XName RootElementName => Constants.NS + "sitemap";

        public override void BuildXElement(XElement root)
        {
            // Stub
        }
    }
}
