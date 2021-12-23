using Grass.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Grass.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        public void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            DisplayAlert("Cancel option", "Cancel was selected", "Button 2", "Button 1");

        }
        public void Save_Clicked(object sender, EventArgs eventArgs)
        {
            DisplayAlert("Save option", "Save was Clicked", "Button 2", "Button 1");

        }
    }
}