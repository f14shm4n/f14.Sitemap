using f14.NetCore.Sitemap.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace f14.NetCore.Sitemap
{
    /// <summary>
    /// Implements logic to build xml sitemap.
    /// </summary>
    public class XmlSitemapBuilder : ISitemapBuilder<XDocument>
    {
        private XDocument _xDoc;
        private readonly XDeclaration _xDeclaration;
        private readonly XElement _xRoot;
        private readonly IEnumerable<ISitemapEntry> _sitemapEntries;

        /// <summary>
        /// Creates new instance of builder with specific params. This ctor using default xml declaration: version - 1.0; encoding - utf-8; standalone - yes.
        /// </summary>
        /// <param name="xRoot">The sitemap root element. Example: sitemapindex, urlset, etc.</param>
        /// <param name="sitemapEntries">The collection with sitemap entries.</param>
        public XmlSitemapBuilder(XElement xRoot, IEnumerable<ISitemapEntry> sitemapEntries)
            : this(new XDeclaration("1.0", "utf-8", "yes"), xRoot, sitemapEntries)
        {

        }
        /// <summary>
        /// Creates new instance of builder with specific params.
        /// </summary>
        /// <param name="xDeclaration">The xml declaration.</param>
        /// <param name="xRoot">The sitemap root element. Example: sitemapindex, urlset, etc.</param>
        /// <param name="sitemapEntries">The collection with sitemap entries.</param>
        public XmlSitemapBuilder(XDeclaration xDeclaration, XElement xRoot, IEnumerable<ISitemapEntry> sitemapEntries)
        {
            _xDeclaration = xDeclaration;
            _xRoot = xRoot;
            _sitemapEntries = sitemapEntries;
        }

        /// <summary>
        /// Builds xml sitemap.
        /// </summary>
        /// <returns><see cref="XDocument"/> as sitemap.</returns>
        public XDocument Build()
        {
            lock (this)
            {
                if (_xDoc == null)
                {
                    _xRoot.Add(_sitemapEntries.Select(x => x.ToXElement()));
                    _xDoc = new XDocument(_xDeclaration, _xRoot);
                }
            }
            return _xDoc;
        }
    }
}
