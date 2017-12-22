using f14.NetCore.Sitemap.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace f14.NetCore.Sitemap
{
    /// <summary>
    /// This is the implementation of the <see cref="ISitemapBuilder{T}"/>.
    /// </summary>
    public sealed class SitemapBuilder
    {
        /// <summary>
        /// Build <see cref="XDocument"/> with provided builder data.
        /// </summary>
        /// <param name="data">The specified builder data.</param>
        /// <returns><see cref="XDocument"/> as sitemap.</returns>
        public XDocument Build(ISitemapBuilderData data)
        {
            var rootElement = data.RootElement;
            rootElement.Add(data.Elements.Select(x => x.ToXElement()));

            var sitemap = new XDocument(data.XmlDeclaration, rootElement);
            return sitemap;
        }
    }
}
