using CommunityToolkit.Mvvm.DependencyInjection;
using Drastic.Feed.Database.LiteDB;
using Drastic.Feed.Rss.FeedReader;
using Drastic.Feed.Services;
using Drastic.Feed.Templates.Handlebars;
using Drastic.Feed.UI.Services;
using Drastic.Feed.UI.UIKit;
using Drastic.Feed.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Drastic.Feed.UI.IOS;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow? Window
    {
        get;
        set;
    }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        Ioc.Default.ConfigureServices(
                        new ServiceCollection()
                        .AddSingleton<IAppDispatcher>(new Drastic.Feed.UI.Mac.AppDispatcher())
                        .AddSingleton<IDatabaseService>(new LiteDBDatabaseContext(System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "DotnetRss")))
                        .AddSingleton<IErrorHandlerService, LoggerErrorHandlerService>()
                        .AddSingleton<ITemplateService, HandlebarsTemplateService>()
                        .AddSingleton<IFeedService, FeedReaderService>()
                        .AddSingleton<IPlatformService, Drastic.Feed.UI.Mac.MacPlatformServices>()
                        .AddTransient<FeedArticleViewModel>()
                        .AddTransient<FeedItemListViewModel>()
                        .AddTransient<FeedListViewModel>()
                        .BuildServiceProvider());

        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        // create a UIViewController with a single UILabel
        var vc = new RootSplitViewController(Ioc.Default);
        Window.RootViewController = vc;

        // make the window visible
        Window.MakeKeyAndVisible();

        return true;
    }
}
