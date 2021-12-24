using Grass.Models;
using Grass.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Grass.Models;
using Grass.Views;

namespace Grass.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
       // private Item _selectedItem;

        public ObservableCollection<Note> Notes { get; set; }
        public Command LoadItemsCommand { get; }
        //public Command AddItemCommand { get; }
      //  public Command<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Notes = new ObservableCollection<Note>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            // Handle "SaveNote" message 
            MessagingCenter.Subscribe<ItemDetailPage, Note>(this, "SaveNote",
                async (sender, note) => {
                    // Add note to collection - will automatically refresh data binding
                    Notes.Add(note);
                    // Add to data store
                    await PluralsightDataStore.AddNoteAsync(note);
                });

            // Handle "UpdateNote" message 
            MessagingCenter.Subscribe<ItemDetailPage, Note>(this, "UpdateNote",
                async (sender, note) => {
                    // Update note in data store
                    await PluralsightDataStore.UpdateNoteAsync(note);
                    // Modifying a member (our note) within an ObservableCollection
                    //  does not automatically refresh data binding .. so explicitly
                    //  repopulate the collection
                    await ExecuteLoadItemsCommand();
                });

            // ItemTapped = new Command<Item>(OnItemSelected);

            //AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                Notes.Clear();
                var notes = await PluralsightDataStore.GetNotesAsync();
                foreach (var item in notes)
                {
                    Notes.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        //public void OnAppearing()
        //{
        //    IsBusy = true;
        //    SelectedItem = null;
        //}

        //public Item SelectedItem
        //{
        //    get => _selectedItem;
        //    set
        //    {
        //        SetProperty(ref _selectedItem, value);
        //        OnItemSelected(value);
        //    }
        //}

        //private async void OnAddItem(object obj)
        //{
        //    await Shell.Current.GoToAsync(nameof(ItemDetailPage));
        //}

        //async void OnItemSelected(Item item)
        //{
        //    if (item == null)
        //        return;

        //    // This will push the ItemDetailPage onto the navigation stack
        //  //  await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        //}
    }
}