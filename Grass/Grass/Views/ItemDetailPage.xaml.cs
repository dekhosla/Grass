
using Xamarin.Forms.Xaml;
using Grass.Models;
using Grass.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.Generic;
using Grass.Services;

namespace Grass.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public Note Note { get; set; }
        public IList<String> CourseList { get; set; }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            InitializeData();
            //BindingContext = new ItemDetailViewModel();

            BindingContext = Note;
            NoteCourse.BindingContext = this;
        }

        public ItemDetailPage()
        {
            InitializeComponent();
            InitializeData();
            //BindingContext = new ItemDetailViewModel();
            BindingContext = Note;
            NoteCourse.BindingContext = this;
        }

        async void InitializeData()
        {
            var pluralsightDataStore = new MockPluralsightDataStore();
            CourseList = await pluralsightDataStore.GetCoursesAsync();

            Note =new Note { Heading = "Test Note", Text = "Text for a test note",
            Course=CourseList[0]};
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