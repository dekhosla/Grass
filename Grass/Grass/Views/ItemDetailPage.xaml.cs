using Grass.ViewModels;
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
    }
}