### v1.0.10 (20-Dec-2022)
- More API changes
 - Created `Drastic.Feed.App`. This is a new base library for handling services that could be used by end-user applications. They are not required for just reading feeds, so I moved them out of the base `Drastic.Feed` library.
 - With this, I have also moved `Drastic.Feed.Database.LiteDB` to `Drastic.Feed.App.Database.LiteDB` and adjusted the underlying namespace to `Drastic.Feed.App.Services.Database`. The package id remains the same.

### v1.0.9 (18-Dec-2022)
- Clean up more API references to condence them. 

### v1.0.7 (17-Dec-2022)
- Removed UI specific fields from the `FeedListItem` and `FeedItem` objects.
- This should not break the actual parsing of objects. They were originally used when the library was used within an application, and those fields are only ever set in that context. If you want to use them, you can wire that in yourself.

### v1.0.0 (12-Dec-2022)
- Initial Release
    - Drastic.Feed.Rss, Drastic.Feed.Parser.SmartReader, Drastic.Feed.Database.LiteDB, Drastic.Feed.Rss.FeedReader, Drastic.Feed.Service.GoogleNews, Drastic.Feed.Templates.Handlebars
- Setup CI/CD Pipeline

