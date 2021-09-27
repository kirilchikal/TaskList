using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;


namespace ToDoApp.Services
{
    class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }

        public BindingList<ToDoModel> LoadData()
        {
            var fileExcist = File.Exists(PATH);
            if (!fileExcist)
            {
                // create a new file and return an empty list
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModel>();
            }

            using (var reader = File.OpenText(PATH))
            {
                string input = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(input);
            }
        }

        public void SaveData(object toDoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(toDoDataList);
                writer.Write(output);
            }
        }
    }
}
