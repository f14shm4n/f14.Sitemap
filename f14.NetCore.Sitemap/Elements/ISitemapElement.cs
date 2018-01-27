using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace f14.Sitemap
{
    /// <summary>
    /// Represents the base sitemap enty interface.
    /// </summary>
    public interface ISitemapElement
    {
        /// <summary>
        /// Create new <see cref="XElement"/> from current entry.
        /// </summary>
        /// <returns>The specified <see cref="XElement"/>.</returns>
        XElement ToXElement();
    }
}
