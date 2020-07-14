using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NewsReader.Views
{
    public partial class NewsDetails : ContentPage
    {
        public NewsDetails(string link)
        {
            InitializeComponent();
            DetailWebView.Source = link;
        }
    }
}
