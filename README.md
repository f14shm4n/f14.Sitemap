# Intro

This lib contains a common classes for building sitemap.

**This lib does not provide any automation methods for creating a sitemap for specific websites.**

# Install

[Nuget](https://www.nuget.org/packages/f14.NetCore.Sitemap): `Install-Package f14.NetCore.Sitemap -Version 1.0.0`

# Usage

For now you can create two types of sitemaps:

* [Sitemap index](#sitemap-index)

* [Urlset](#urlset)

## Sitemap index

Example:

```
<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<sitemapindex xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
  <sitemap>
    <loc>http://example.com/sitemap_categories.xml</loc>
  </sitemap>
  <sitemap>
    <loc>http://example.com/sitemap_posts.xml</loc>
  </sitemap>
  ...
</sitemapindex>
```

How to build:

```            
  // Create collection for indexes
  var items = new List<IndexEntry>();
  // Create index item
  var categoriesIndex = new IndexEntry
  {
      Url = "http://example.com/sitemap_categories.xml"    
  }
  // Create another one index item
  var postsIndex = new IndexEntry
  {
      Url = "http://example.com/sitemap_posts.xml"    
  }
  // And so on
  ...
  
  items.Add(categoriesIndex);
  items.Add(postsIndex);
  
  // Create builder data and build sitemap
  var xDoc = SitemapBuilder.Build(new SitemapBuilderData
  {
      RootElement = new XElement(Constants.SitemapIndexName), // Create root xml element = sitemapindex
      Elements = items // Add our indexes
  });
  // Save sitemap to the file
  xDoc.Save("sitemap_index.xml");

```

## Urlset

Example:

```
<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<urlset xmlns:image="http://www.google.com/schemas/sitemap-image/1.1" xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
  <url>
    <loc>http://example.com/posts/example-post</loc>
    <lastmod>2017-12-22T21:09:32.2+00:00</lastmod>
    <changefreq>always</changefreq>
    <priority>1,0</priority>
    <image:image>
      <image:loc>http://example.com/images/post-1231/preview.jpg</image:loc>
      <image:caption>Image caption</image:caption>
      <image:title>Image title</image:title>
      <image:geo_location>geo location address</image:geo_location>
      <image:license>License</image:license>
    </image:image>
  </url>
  ...
</urlset>
```

How to build:

```
  // Create urlset collection
  var items = new List<UrlEntry>();
  // Create url item
  var urlEntry = new UrlEntry
  {
      Url = "http://example.com/posts/example-post",
      Modified = DateTime.Now.Add(TimeSpan.FromMinutes(i + 1)),
      ChangeFrequency = ChangeFrequency.Always,
      Priority = 1
  };
  // Add images if needed
  urlEntry.Images.Add(new ImageEntry
  {
      Url = "http://example.com/images/post-1231/preview.jpg",
      Caption = "Image caption",
      Geo = "geo location address",
      Title = "Image title",
      License = "License"
  });

  items.Add(urlEntry);
  // Create builder data and build sitemap
  var xDoc = SitemapBuilder.Build(new SitemapBuilderData
  {
      RootElement = new XElement(Constants.UrlsetName, Constants.GoogleImageAttribute), // Create root xml element for urlset
      Elements = items // Set entry collection
  });
  
  xDoc.Save("sitemap_urlset.xml");
```

# Authors

* [f14shm4n](https://github.com/f14shm4n)

# License

[MIT](https://opensource.org/licenses/MIT)
