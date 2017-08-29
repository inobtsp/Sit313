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
            //create toolbaritem
     var Item1 = new ToolbarItem  
            {  
               Text = "Item 1",
               Icon = "person.png"
               
             };  
             this.ToolbarItems.Add(Item1);
            Item1.Activated += gotologin;
            async void gotologin(object a, EventArgs b)
            {
                Console.WriteLine("success got login");
                await Navigation.PushAsync(new login());
            }
            //create grid  set column and row definition to the grid
            
            Grid grid = new Grid{
                BackgroundColor = Color.FromHex("#5882FA"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
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
            //adding element to grid
            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",
                
            }, 0, 0);
            grid.Children.Add(new Label
            {
                Text = "Dota2",
                TextColor = Color.White,
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
                Text = "League of Legend",
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 0, 1);

            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 0, 2);
            grid.Children.Add(new Label
            {
                Text = "Zelda",
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 0, 2);

            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 1, 0);
            grid.Children.Add(new Label
            {
                Text = "Super Mario",
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 1, 0);

            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 1, 1);
            grid.Children.Add(new Label
            {
                Text = "World of Warcraft",
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 1, 1);


            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 1, 2);
            grid.Children.Add(new Label
            {
                Text = "HeartStone",
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 1, 2);

            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 2, 0);
            grid.Children.Add(new Label
            {
                Text = "Witches 3",
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 2, 0);


            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 2, 1);
            grid.Children.Add(new Label
            {
                Text = "GTA 5",
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 2, 1);
            grid.Children.Add(new Image
            {
                Source = "monkey.jpg",

            }, 2, 2);
            grid.Children.Add(new Label
            {
                Text = "More",
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.End
            }, 2, 2);
       //event handler for the grid
            var tgr = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
            tgr.TappedCallback = async (sender, args) =>
            {
                await Navigation.PushAsync(new MainPage());
            };
            grid.GestureRecognizers.Add(tgr);
            // Accomodate Phone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = grid;
        }
    }
}