﻿using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void OpenMenu()
        {
            MenuGrid.IsVisible = true;

            Action<double> callback = input => MenuView.TranslationX = input;
            MenuView.Animate("anim", callback, -260, 0, 16, 300, Easing.CubicInOut);
        }

        private void CloseMenu()
        {
            Action<double> callback = input => MenuView.TranslationX = input;
            MenuView.Animate("anim", callback, 0, -260, 16, 300, Easing.CubicInOut);

            MenuGrid.IsVisible = false;
        }

        private void OverlayTapped(object sender, EventArgs e)
        {
            CloseMenu();
        }

        private void MenuTapped(object sender, EventArgs e)
        {
            OpenMenu();
        }
        private void ProductSelected(object sender, SelectionChangedEventArgs e)
        {
            SharedTransitionNavigationPage.SetTransitionSelectedGroup(this, vm.SelectedProduct.Name);
            vm.ShowDetails();
        }
    }
}
