using f14.NetCore.Sitemap.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace f14.NetCore.Sitemap.Abstractions
{
    /// <summary>
    /// Provides the basic interface for creating sitemap.
    /// </summary>
    /// <typeparam name="T">Type of sitemap entry object.</typeparam>
    public interface ISitemapBuilder<out T> where T : ISitemapEntry
    {
        /// <summary>
        /// Build <see cref="XDocument"/> with provided builder data.
        /// </summary>
        /// <param name="data">The specified builder data.</param>
        /// <returns><see cref="XDocument"/> as sitemap.</returns>
        XDocument Build(ISitemapBuilderData data);
    }
}
