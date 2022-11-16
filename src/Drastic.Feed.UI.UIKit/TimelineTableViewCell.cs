using System;
using Drastic.Feed.Models;
using ObjCRuntime;
using System.Runtime.InteropServices;

namespace Drastic.Feed.UI.UIKit
{
	public class TimelineTableViewCell : UITableViewCell
    {
    private UILabel titleView = GenerateMultiLineUILabel();
    private UILabel summaryView = GenerateMultiLineUILabel();
    private UnreadIndicatorView unreadIndicatorView = new UnreadIndicatorView(CGRect.Empty);
    private UILabel dateView = GenerateSingleLineUILabel();
    private UILabel feedNameView = GenerateSingleLineUILabel();

    public TimelineTableViewCell(string reuseIdentifier)
        : base(UITableViewCellStyle.Default, reuseIdentifier)
    {
        this.SetupUI();
    }

    public TimelineTableViewCell()
    {
        this.SetupUI();
    }

    public TimelineTableViewCell(NSCoder coder) : base(coder)
    {
        this.SetupUI();
    }

    public TimelineTableViewCell(CGRect frame) : base(frame)
    {
        this.SetupUI();
    }

    public TimelineTableViewCell(UITableViewCellStyle style, string reuseIdentifier) : base(style, reuseIdentifier)
    {
        this.SetupUI();
    }

    public TimelineTableViewCell(UITableViewCellStyle style, NSString? reuseIdentifier) : base(style, reuseIdentifier)
    {
        this.SetupUI();
    }

    protected TimelineTableViewCell(NSObjectFlag t) : base(t)
    {
        this.SetupUI();
    }

    protected internal TimelineTableViewCell(NativeHandle handle) : base(handle)
    {
        this.SetupUI();
    }

    public void UpdateCell(FeedItem item)
    {
        this.titleView.Text = item.Title;
        this.summaryView.Text = item.Description;
        this.dateView.Text = item.PublishingDateString;
    }

    private void SetupUI()
    {
        this.ClipsToBounds = true;
        this.Frame = new CGRect(0, 44.5, 414, 208);
        this.PreservesSuperviewLayoutMargins = true;
        this.ContentView.ClipsToBounds = true;
        this.ContentView.ContentMode = UIViewContentMode.Center;
        this.ContentView.InsetsLayoutMarginsFromSafeArea = false;
        this.ContentView.MultipleTouchEnabled = true;
        this.ContentView.PreservesSuperviewLayoutMargins = true;

        this.AddSubviewAtInit(this.titleView, false);
        this.AddSubviewAtInit(this.summaryView, true);
        this.AddSubviewAtInit(this.unreadIndicatorView, true);
        this.AddSubviewAtInit(this.dateView, false);
        this.AddSubviewAtInit(this.feedNameView, true);
    }

    private void AddSubviewAtInit(UIView view, bool hidden)
    {
        this.ContentView.AddSubview(view);
        view.TranslatesAutoresizingMaskIntoConstraints = false;
        view.Hidden = hidden;
    }

    private static UILabel GenerateMultiLineUILabel()
    {
        var label = new NonIntrinsicLabel();
        label.Lines = 0;
        label.LineBreakMode = UILineBreakMode.TailTruncation;
        label.AllowsDefaultTighteningForTruncation = false;
        label.AdjustsFontForContentSizeCategory = true;
        return label;
    }

    private static UILabel GenerateSingleLineUILabel()
    {
        var label = new NonIntrinsicLabel();
        label.LineBreakMode = UILineBreakMode.TailTruncation;
        label.AllowsDefaultTighteningForTruncation = false;
        label.AdjustsFontForContentSizeCategory = true;
        return label;
    }

    public override void LayoutSubviews()
    {
        base.LayoutSubviews();
        this.UpdatedLayout(this.Bounds.Width);
    }

    private void UpdatedLayout(NFloat width)
    {

    }
}
}

