using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
namespace App5
{
    public class CustomCell : ContentPage
    {
        //public ObservableCollection<Custom> veggies { get; set; }
        public CustomCell()
        {
            List<Custom> people = new List<Custom>();
            ListView lstView = new ListView();
            lstView.RowHeight = 60;
            this.Title = "ListView Code Sample";
            lstView.ItemTemplate = new DataTemplate(typeof(CustomCells));
           people.Add(new Custom { Topic = "Tomato", detail = "Fruit", image = "monkey.jpg" });
            people.Add(new Custom { Topic = "Romaine Lettuce", detail = "Vegetable", image = "lettuce.png" });
            people.Add(new Custom { Topic = "Zucchini", detail = "Vegetable", image = "zucchini.png" });
            lstView.ItemsSource = people;
            Content = lstView;
        }
        public class CustomCells : ViewCell
        {
            public CustomCells()
            {
                //instantiate each of our views
                var image = new Image();
                StackLayout cellWrapper = new StackLayout();
                StackLayout horizontalLayout = new StackLayout();
                Label left = new Label();
                Label right = new Label();

                //set bindings
                left.SetBinding(Label.TextProperty, "Topic");
                right.SetBinding(Label.TextProperty, "detail");
                //image.SetBinding(Image.SourceProperty, "image");

                //Set properties for desired design
                cellWrapper.BackgroundColor = Color.FromHex("#eee");
                horizontalLayout.Orientation = StackOrientation.Horizontal;
                right.HorizontalOptions = LayoutOptions.EndAndExpand;
                left.TextColor = Color.FromHex("#f35e20");
                right.TextColor = Color.FromHex("503026");

                //add views to the view hierarchy
                horizontalLayout.Children.Add(image);
                horizontalLayout.Children.Add(left);
                horizontalLayout.Children.Add(right);
                cellWrapper.Children.Add(horizontalLayout);
                View = cellWrapper;
            }
        }
    }
}
