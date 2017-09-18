using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App5
{
	public class category : ContentPage
	{
        string[] topictext;
        public category()
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

            //Set the title for topic page
            Title = "Topics";
            //Background colour
            BackgroundColor = Color.FromHex("#fcf0cd");

            // Head for hot topic label
            Label hot = new Label
            {
                Text = "What's hot",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("#fc7865"),
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold
            };

            // Head for other topic label
            Label other = new Label
            {


                Text = "Otherss",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("#a6fe73"),
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold
            };


            // Zelda button
            var dota2 = new Frame
            {
                OutlineColor = Color.Accent,
                BackgroundColor = Color.FromHex("#6efa8e"),
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "dota2",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))

                }
               
            };


            //LOL button
            var wow = new Frame
            {
                OutlineColor = Color.Accent,
                BackgroundColor = Color.FromHex("#6efa8e"),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "World of Warcraft",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                }

            };

            // WOW button 
            var lol = new Frame
            {
                OutlineColor = Color.Accent,
                BackgroundColor = Color.FromHex("#6efa8e"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "Legend of league",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                }

            };

            // Others topic button
            var heartstone = new Frame
            {
                OutlineColor = Color.Accent,
                BackgroundColor = Color.FromHex("#6efa8e"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "HeartStone",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                }

            };

            //Create frame for hot topics
            Frame containerhot = new Frame
            {
                BackgroundColor = Color.FromHex("#f8f8f8"),
                HasShadow = false,

                //Create view for container
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 10,

                    //Append input text to container
                    Children = { dota2, lol, wow }
                }
            };

            //Create frame for other topics
            Frame containerother = new Frame
            {
                BackgroundColor = Color.FromHex("#f8f8f8"),
                HasShadow = false,

                //Create view for container
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 10,

                    //Append input text to container
                    Children = { heartstone }
                }
            };

            //Add all components to view
            Content = new StackLayout
            {
                Spacing = 0,
                Children = { hot, containerhot, other, containerother }
            };

            //Add event Handler
            var dota2tap = new TapGestureRecognizer();
             dota2.GestureRecognizers.Add(dota2tap);
			dota2tap.Tapped += dota2hasTapped;

            var wowtap = new TapGestureRecognizer();
           wow.GestureRecognizers.Add(wowtap);
            wowtap.Tapped += wowhasTapped;

            var loltap = new TapGestureRecognizer();
           lol.GestureRecognizers.Add(loltap);
            loltap.Tapped += lolhasTapped;

            var hstap = new TapGestureRecognizer();
            heartstone.GestureRecognizers.Add(hstap);
           hstap.Tapped += hshasTapped;


            /* //Click lol
             lol.GestureRecognizers.Add(tapGestureRecognizer);
             //Click wow
             wow.GestureRecognizers.Add(tapGestureRecognizer);
             //Click others
             heartstone.GestureRecognizers.Add(tapGestureRecognizer);*/


        }

        //frame clicked 
		void dota2hasTapped(object sender, EventArgs args)
		{
            // Navigate to forum page
            Navigation.PushAsync(new MainPage("Dota2"));
		}
        void wowhasTapped(object sender, EventArgs args)
        {
            // Navigate to forum page
            Navigation.PushAsync(new MainPage("World Of Warcraft"));
        }
        void hshasTapped(object sender, EventArgs args)
        {
            // Navigate to forum page
            Navigation.PushAsync(new MainPage("HeartStone"));
        }
        void lolhasTapped(object sender, EventArgs args)
        {
            // Navigate to forum page
            Navigation.PushAsync(new MainPage("Legend of League"));
        }
        //event handler for the grid
        /* var tgr = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
         tgr.TappedCallback = async (sender, args) =>
         {

                 //Label thebutton = (Label)sender;

                 await Navigation.PushAsync(new MainPage());
         };
         grid.GestureRecognizers.Add(tgr);
         // Accomodate Phone status bar.
         this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

         // Build the page.
         this.Content = grid;*/
    }
    }  
