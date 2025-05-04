using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace Fitness_Tracking_App.Database
{
    public class DatabaseService 
    {        
        public void AddOrUpdateDataToJsonFile(TblUser user)
        {
            var users = ReadDataFromJsonFile();

            var record = users.SingleOrDefault(x => x.Id == user.Id);

            if (record == null) users.Add(user);

            else record = user;

            SaveDataToJsonFile(users);
        }
        
        public List<TblUser> ReadDataFromJsonFile()
        {
            string appPath = Application.ExecutablePath;

            string appDirectory = Path.GetDirectoryName(appPath);

            var path = Path.Combine(appDirectory, "database.json");

            if (File.Exists(path) == false) File.Create(path).Dispose();

            string jsonString = File.ReadAllText(path);

            var data = JsonConvert.DeserializeObject<List<TblUser>>(jsonString);

            return data ?? new List<TblUser>();
        }

        private void SaveDataToJsonFile(List<TblUser> users)
        {
            string appPath = Application.ExecutablePath;

            string appDirectory = Path.GetDirectoryName(appPath);

            var path = Path.Combine(appDirectory, "database.json");

            string jsonString = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(path, jsonString);
        }
    }

    public class TblUser
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }

}
