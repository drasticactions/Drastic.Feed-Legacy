// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Drastic.Feed.UI.WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private Page page;

        public MainWindow(Page page)
        {
            this.InitializeComponent();

            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(this.AppTitleBar);

            this.MainFrame.Content = this.page = page;
            page.DataContextChanged += this.Page_DataContextChanged;
            var manager = WindowManager.Get(this);
            manager.Backdrop = new MicaSystemBackdrop();
        }

        private void Page_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            this.MainGrid.DataContext = args.NewValue;
        }
    }
}
