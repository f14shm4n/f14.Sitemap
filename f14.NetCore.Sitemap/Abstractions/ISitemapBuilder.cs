using System;
using System.Collections.Generic;
using System.Text;

namespace f14.NetCore.Sitemap.Abstractions
{
    /// <summary>
    /// Provides base interface for building sitemaps.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISitemapBuilder<out T>
    {
        /// <summary>
        /// Builds sitemap and return this in the specified type.
        /// </summary>
        /// <returns>The sitemap in the specified type.</returns>
        T Build();
    }
}
