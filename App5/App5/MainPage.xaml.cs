using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Xamarin.Forms;

namespace App5
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            InitializeComponent();
            listView.ItemsSource = new List<Custom>
            {
                new Custom
                {
                    Topic="215454",
                    detail="skaodkaokda",
                    author= "inobts"
                },
                   new Custom
                {
                    Topic="215352554",
                    detail="skaodkaokda",
                    author= "inobtsp"
                },

            };
        }
    }
	}

