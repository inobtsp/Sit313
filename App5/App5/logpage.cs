using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App5
{
	public class logpage : ContentPage
	{
        //Define list of products
        public logpage()
        {
          var  ItemsSource = new List<Custom>
            {
                new Custom
                {

                    Topic="LGD is the best team！",
                    time="post at: 2017-8-04",
                    author= "inobts"
                },
                   new Custom
                {

                    Topic="Dota2 is the best game ever",
                      time="post at: 2017-8-04",
                    author= "inobtsp"
                },

            };
            var scl = new ScrollView() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var list = new ListView() { VerticalOptions = LayoutOptions.StartAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, RowHeight = 65 };
            var itm = new DataTemplate(typeof(CustomCell));
            list.ItemTemplate = itm;
            var topiclist = new Custom();
            list.ItemsSource = ItemsSource;
            Content = scl.Content = list;
           
        }
    }

    //Define the custom cell of list
    public class CustomCell : ViewCell
    {
        public CustomCell()
        {
            var image = new Image() { HeightRequest = 70, WidthRequest = 90 };
            StackLayout cell = new StackLayout() { Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 3) };
            StackLayout horizontalLayout = new StackLayout() { Orientation = StackOrientation.Vertical };

            Label title = new Label() { FontSize = 18, TextColor = Color.FromHex("333333").MultiplyAlpha(.7f), HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            Label discount = new Label() { FontSize = 12, TextColor = Color.Red.MultiplyAlpha(.8f), FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand, YAlign = TextAlignment.Center };

            //set bindings
            title.SetBinding(Label.TextProperty, "topic");
            discount.SetBinding(Label.TextProperty, "name");
            image.SetBinding(Image.SourceProperty, "author");

            //add views to the view hierarchy 
            horizontalLayout.Children.Add(title);
            horizontalLayout.Children.Add(discount);

            //Add View to cell of list
            cell.Children.Add(image);
            cell.Children.Add(horizontalLayout);
            View = cell;
        }
    }
}