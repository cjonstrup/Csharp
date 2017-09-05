using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace TimeLocker
{
    public class StorageHandler
    {
        public StorageHandler()
        {
        }

        public List<Job> Items { get; set; }
        public string FileName { get; set; }

        public bool Save()
        {

            var f = new Storage()
            {
                MachineName = Environment.MachineName,
                Date = DateTime.Now,
                Items = Items
            };

            var json = new JavaScriptSerializer().Serialize(f);
            File.WriteAllText(FileName, json);

            return File.Exists(FileName);
        }


        public Storage Restore(string fileName)
        {
            var json = File.ReadAllText(fileName);
            var f = new JavaScriptSerializer().Deserialize<Storage>(json);
            return f;
        }
    }
}