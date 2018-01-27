using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace f14.Sitemap
{
    /// <summary>
    /// Provides a static creators for sitemap builders.
    /// </summary>
    public static class SitemapBuilder
    {
        /// <summary>
        /// Creates new <see cref="ISitemapBuilder{T}"/> for build index map.
        /// </summary>
        /// <param name="indexMap">The index list.</param>
        /// <returns>New instance of <see cref="ISitemapBuilder{T}"/>.</returns>
        public static ISitemapBuilder<XDocument> CreateIndexBuilder(IEnumerable<IndexElement> indexMap)
            => new XmlSitemapBuilder(new XElement(SitemapConstants.SitemapIndexName), indexMap);
        /// <summary>
        /// Creates new <see cref="ISitemapBuilder{T}"/> for build url set.
        /// </summary>
        /// <param name="urlSet">The urls list.</param>
        /// <returns>New instance of <see cref="ISitemapBuilder{T}"/>.</returns>
        public static ISitemapBuilder<XDocument> CreateUrlSetBuilder(IEnumerable<UrlElement> urlSet)
            => new XmlSitemapBuilder(new XElement(SitemapConstants.UrlsetName, SitemapConstants.GoogleImageAttribute), urlSet);
        /// <summary>
        /// Builds new index sitemap.
        /// </summary>
        /// <param name="indexMap">The index list.</param>
        /// <returns>Generated xml document.</returns>
        public static XDocument BuildIndexMap(IEnumerable<IndexElement> indexMap) => CreateIndexBuilder(indexMap).Build();
        /// <summary>
        /// Builds new url set sitemap.
        /// </summary>
        /// <param name="urlSet">The url set.</param>
        /// <returns>Generated xml document.</returns>
        public static XDocument BuildUrlset(IEnumerable<UrlElement> urlSet) => CreateUrlSetBuilder(urlSet).Build();
    }
}
