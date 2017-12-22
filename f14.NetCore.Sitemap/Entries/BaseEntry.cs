using f14.NetCore.Sitemap.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace f14.NetCore.Sitemap.Entries
{
    /// <summary>
    /// Represents the base sitemap entry implementation.
    /// </summary>
    public abstract class BaseEntry : ISitemapEntry
    {
        /// <summary>
        /// The resource url.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// The modification date.
        /// </summary>
        public DateTime? Modified { get; set; }
        /// <summary>
        /// Provides root xml element name for current entry.
        /// </summary>
        public abstract XName RootElementName { get; }
        /// <summary>
        /// Build default data.
        /// </summary>
        /// <param name="root">The root element.</param>
        public virtual void BuildDefault(XElement root)
        {
            root.Add(new XElement(Constants.NS + "loc", Url));
            if (Modified.HasValue)
            {
                root.Add(new XElement(Constants.NS + "lastmod", Modified.Value.ToString("yyyy-MM-ddTHH:mm:ss.f") + "+00:00"));
            }
        }
        /// <summary>
        /// Build specified element contents.
        /// </summary>
        /// <param name="root">The root element.</param>
        public abstract void BuildXElement(XElement root);

        public XElement ToXElement()
        {
            var root = new XElement(RootElementName);

            BuildDefault(root);
            BuildXElement(root);

            return root;
        }
    }
}
