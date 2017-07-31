using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App5
{
	public class category : ContentPage
	{
		public category ()
		{
            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                     
               
                     new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                      new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                       new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                     
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",
                
            }, 0, 0);
            grid.Children.Add(new Label
            {
                Text = "Dota2",
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 0, 0);

            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

                HeightRequest = 0
            }, 0, 1);
            grid.Children.Add(new Label
            {
                Text = "Dota2",
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 0, 1);

            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 0, 2);
            grid.Children.Add(new Label
            {
                Text = "Dota2",
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 0, 2);

            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 1, 0);
            grid.Children.Add(new Label
            {
                Text = "Dota2",
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 1, 0);

            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 1, 1);
            grid.Children.Add(new Label
            {
                Text = "Dota2",
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 1, 1);


            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 1, 2);
            grid.Children.Add(new Label
            {
                Text = "Dota2",
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 1, 2);

            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 2, 0);
            grid.Children.Add(new Label
            {
                Text = "Dota2",
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 2, 0);


            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 2, 1);
            grid.Children.Add(new Label
            {
                Text = "Dota2",
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 2, 1);
            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 2, 2);
            grid.Children.Add(new Label
            {
                Text = "Dota2",
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 2, 2);
       
            var tgr = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
            tgr.TappedCallback = async (sender, args) =>
            {
                await Navigation.PushAsync(new MainPage());
            };
            grid.GestureRecognizers.Add(tgr);
            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = grid;
        }
    }
}