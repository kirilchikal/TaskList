using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    class ToDoModel : INotifyPropertyChanged
    {
        private string _toDoText;
        private bool _isDone;

        [JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "toDoText")]
        public string ToDoText
        {
            get { return _toDoText; }
            set 
            {
                if (_toDoText == value)
                    return;
                _toDoText = value;
                OnPropertyChanged("Text");
            }
        }

        [JsonProperty(PropertyName = "isDone")]
        public bool IsDone
        {
            get { return _isDone; }
            set 
            {
                if (_isDone == value)
                    return;
                _isDone = value;
                OnPropertyChanged("isDone");
            }
        }

        // Implementation of the interface INotifyPropertyChanged
        // Check if model was modified
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged (string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
