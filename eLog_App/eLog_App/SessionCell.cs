/*using System;

using Xamarin.Forms;

namespace eLog_App
{
    public class SessionCell : ViewCell
    {

        Label title, label;
        StackLayout layout;

        public SessionCell()
        {
            title = new Label
            {
                YAlign = TextAlignment.Center
            };
            title.SetBinding(Label.TextProperty, "Title");

            label = new Label
            {
                YAlihn = TextAlignment.Center,
                FontSize = Font.SystemFontOfSize(10)
            };
            label.SetBinding(Label.TextProperty, "LocationDisplay");

            var fav = new Image
            {
                Source = FileImageSource.FromFile("favorite.png"),
            };

            var text = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(0, 0, 0, 0),
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { title, label }
            };
        }

        protected override void OnBindingContextChanged() {
            base.OnBindingContextChanged();
            var session = (Session)BindingContext;

            if (session.Title.Length > 75)
                this.Height = 110;
            else if (session.Title.Length > 60)
                this.Height = 80;
            else if (session.Title.Length > 30)
                this.Height = 60;
            else
                this.Height = 40;
        }
    }
}*/

