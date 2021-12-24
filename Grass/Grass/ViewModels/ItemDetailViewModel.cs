using Grass.Models;
using Grass.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Grass.ViewModels
{
    //QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
       public Note Note { get; set; }
        public IList<String> CourseList { get; set; }

        public bool IsNewNote { get; set; }
        public String NoteHeading
        {
            get { return Note.Heading; }
            set
            {
                Note.Heading = value;
                OnPropertyChanged();
            }
        }
        public String NoteText
        {
            get { return Note.Text; }
            set
            {
                Note.Text = value;
                OnPropertyChanged();
            }
        }

        public String NoteCourse
        {
            get { return Note.Course; }
            set
            {
                Note.Course = value;
                OnPropertyChanged();
            }
        }


        public ItemDetailViewModel(Note item = null)
        {
           // Title = item?.Text;
            IsNewNote = item == null;
            Title = IsNewNote ? "Add note" : "Edit note";
            InitializeCourseList();
            Note = item ?? new Note();
            //Note = new Note
            //{
            //    Heading = "Test Note",
            //    Text = "Text for a test note",
            //    Course = CourseList[0]
            //};        
        }
               
        async void InitializeCourseList()
        {         
            CourseList = await PluralsightDataStore.GetCoursesAsync();
            //Note = new Note { Heading = "Test Note", Text = "Text for a test note", 
            //Course=CourseList[0]};
        }


        //private string itemId;
        //private string text;
        //private string description;
        //public string Id { get; set; }

        //public string Text
        //{
        //    get => text;
        //    set => SetProperty(ref text, value);
        //}

        //public string Description
        //{
        //    get => description;
        //    set => SetProperty(ref description, value);
        //}

        //public string ItemId
        //{
        //    get
        //    {
        //        return itemId;
        //    }
        //    set
        //    {
        //        itemId = value;
        //        LoadItemId(value);
        //    }
        //}

        //public async void LoadItemId(string itemId)
        //{
        //    try
        //    {
        //        var item = await DataStore.GetItemAsync(itemId);
        //        Id = item.Id;
        //        Text = item.Text;
        //        Description = item.Description;
        //    }
        //    catch (Exception)
        //    {
        //        Debug.WriteLine("Failed to Load Item");
        //    }
        //}
    }
}
