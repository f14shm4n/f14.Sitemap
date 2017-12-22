using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace f14.NetCore.Sitemap.Abstractions
{
    /// <summary>
    /// Represents the sitemap builder data.
    /// </summary>
    public interface ISitemapBuilderData
    {
        /// <summary>
        /// Xml declaration.
        /// </summary>
        XDeclaration XmlDeclaration { get; }
        /// <summary>
        /// The document root element.
        /// </summary>
        XElement RootElement { get; }
        /// <summary>
        /// The sitemap entry collection.
        /// </summary>
        IEnumerable<ISitemapEntry> Elements { get; }
    }
}
