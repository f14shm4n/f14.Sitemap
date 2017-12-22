using f14.NetCore.Sitemap.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace f14.NetCore.Sitemap
{
    /// <summary>
    /// Represents the sitemap builder data.
    /// </summary>
    public class SitemapBuilderData : ISitemapBuilderData
    {
        private XDeclaration _xmlDeclaration = new XDeclaration("1.0", "utf-8", "yes");
        private XElement _rootElement;
        private IEnumerable<ISitemapEntry> _elements;

        /// <summary>
        /// Xml declaration.
        /// </summary>
        public XDeclaration XmlDeclaration { get => _xmlDeclaration; set => _xmlDeclaration = value; }
        /// <summary>
        /// The document root element.
        /// </summary>
        public XElement RootElement { get => _rootElement; set => _rootElement = value; }
        /// <summary>
        /// The sitemap entry collection.
        /// </summary>
        public IEnumerable<ISitemapEntry> Elements { get => _elements; set => _elements = value; }
    }
}
