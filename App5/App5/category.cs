using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App5
{
	public class category : ContentPage
	{
      public category()
        {
            //create toolbaritem
            var Item1 = new ToolbarItem
            {
                Text = "Item 1",
                Icon = "person.png"

            };
            this.ToolbarItems.Add(Item1);
            Item1.Clicked += gotologin;
            //set click event to navigate page
            async void gotologin(object a, EventArgs b)
            {
                //append user footer
                string datasigniture = DependencyService.Get<ISaveAndLoad>().LoadText("temp.json");
                Jsonconverter jsonconverter = new Jsonconverter();
                string usersfooter = jsonconverter.ToObjectstring(datasigniture);
                if (usersfooter != null)
                {
                    await Navigation.PushAsync(new profile());
                }
                else
                {
                    await Navigation.PushAsync(new login());
                }
            }
           

            //Set the title for topic page
            Title = "Topics";
            //set the background of not use space
            BackgroundColor = Color.Gray;

            // hot topic label
            Label hot = new Label
            {
                Text = "What's hot",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("#8181F7"),
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold
            };

            // other topic label
            Label other = new Label
            {


                Text = "Others",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("#8181F7"),
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold
            };


            // Create frames 
            var dota2 = new Frame
            {
                OutlineColor = Color.Accent,
                BackgroundColor = Color.FromHex("#5858FA"),
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "Dota2",
                    FontSize = 12

                }
               
            };


            var wow = new Frame
            {
                OutlineColor = Color.Accent,
                BackgroundColor = Color.FromHex("#5858FA"),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "World of Warcraft",
                    FontSize =13
                }

            };

            var lol = new Frame
            {
                OutlineColor = Color.Accent,
                BackgroundColor = Color.FromHex("#5858FA"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "Legend of league",
                    FontSize = 13
                }

            };

            var heartstone = new Frame
            {
                OutlineColor = Color.Accent,
                BackgroundColor = Color.FromHex("#5858FA"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "HeartStone",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                }

            };

            //add frames in to the hot topic header
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

            //add frames into other topic header
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

        }

        //frame clicked 
		void dota2hasTapped(object sender, EventArgs args)
		{
            
            Navigation.PushAsync(new MainPage("Dota2"));
		}
        void wowhasTapped(object sender, EventArgs args)
        {
           
            Navigation.PushAsync(new MainPage("World Of Warcraft"));
        }
        void hshasTapped(object sender, EventArgs args)
        {
            
            Navigation.PushAsync(new MainPage("HeartStone"));
        }
        void lolhasTapped(object sender, EventArgs args)
        {
            
            Navigation.PushAsync(new MainPage("Legend of League"));
        }
       
    }
    }  
