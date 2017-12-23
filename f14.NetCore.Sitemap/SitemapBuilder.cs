using f14.NetCore.Sitemap.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace f14.NetCore.Sitemap
{
    /// <summary>
    /// Provides methods for create a sitemap.
    /// </summary>
    public class SitemapBuilder
    {
        /// <summary>
        /// Builds <see cref="XDocument"/> with a provided data.
        /// </summary>
        /// <param name="data">The specified data.</param>
        /// <returns><see cref="XDocument"/> as sitemap.</returns>
        public static XDocument Build(ISitemapBuilderData data)
        {
            var rootElement = data.RootElement;
            rootElement.Add(data.Elements.Select(x => x.ToXElement()));

            var sitemap = new XDocument(data.XmlDeclaration, rootElement);
            return sitemap;
        }
    }
}
