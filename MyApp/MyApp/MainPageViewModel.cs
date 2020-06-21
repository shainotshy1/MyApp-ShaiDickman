
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;

namespace MyAppMainPage

{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            EraseCommand = new Command(() => { TheNote = string.Empty; });
            SaveCommand = new Command(() =>
            {
                AllNotes.Add(new Notes { Note=TheNote });
                SavedNotes.Add(new Notes { Note = TheNote });

                TheNote = string.Empty;
            });
            EraseNoteCommand = new Command(() => { AllNotes.Clear(); });
            UndoClearCommand = new Command(() => { AllNotes = SavedNotes; });
        }
        ObservableCollection<Notes> allNotes = new ObservableCollection<Notes>();
        ObservableCollection<Notes> savedNotes = new ObservableCollection<Notes>();
        public ObservableCollection<Notes> AllNotes
        {
            get { return allNotes; }
            set { allNotes = value; }
        }
        public ObservableCollection<Notes> SavedNotes
        {
            get { return savedNotes; }
            set { savedNotes = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        string theNote;
        public string TheNote
        {
            //Makes theNote change in both the view model and in the code!
            get => theNote;
            set
            {
                theNote = value;

                var args = new PropertyChangedEventArgs(nameof(TheNote));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }
        public Command EraseNoteCommand { get; }

        public Command UndoClearCommand { get; }

        public class Notes
        {
            public string Note { get; set; }
        }
        
       

    }
}
