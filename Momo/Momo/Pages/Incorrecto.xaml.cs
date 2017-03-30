﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Momo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Incorrecto : ContentPage
    {
        public Incorrecto()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        public void OnTapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
