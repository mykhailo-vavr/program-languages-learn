using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Hotel
{
    public class LstCollection
    {
        private List<Hotel> lst;

        public LstCollection() => this.lst = new List<Hotel>();

        public LstCollection(List<Hotel> lst) => this.lst = new List<Hotel>(lst);

        public override string ToString()
        {
            string res = "";
            foreach (Hotel item in lst)
                res += item.ToString() + "\n\n";
            return "\n" + res.Substring(0, res.Length - 3);
        }

        public int Length() => lst.Count;

        public Hotel this[int i]
        {
            get => lst[i];
            set => lst[i] = value;
        }

        public LstCollection AddItem(Hotel item)
        {
            lst.Add(item);
            return this;
        }

        public LstCollection Sort(string field)
        {
            try
            {
                this.lst = lst.OrderBy(item => item.GetType().GetProperty(field).GetValue(item, null)).ToList();
            }
            catch (Exception)
            {
                throw new ArgumentException("Wrong Field name!");
            }
            return this;
        }

        public List<Hotel> Search(string subStr)
        {
            bool SearchPredicater(Hotel item)
            {
                foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(item))
                    if (prop.GetValue(item).ToString().Contains(subStr)) return true;
                return false;
            }
            var filtered = lst.FindAll(SearchPredicater);
            return filtered;
        }

        public LstCollection Delete(string id)
        {
            var item = lst.Find(x => x.Id == id);
            if (item != null) lst.Remove(item);
            return this;
        }

        public LstCollection Edit(string id, string atter, string value)
        {
            var item = lst.Find(x => x.Id == id);
            if (item != null)
            {
                PropertyInfo propertyInfo = item.GetType().GetProperty(atter);
                propertyInfo.SetValue(item, Convert.ChangeType(value, propertyInfo.PropertyType), null);
            }
            return this;
        }

        public LstCollection ReadJsonFile(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                var dictionarys = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
                foreach (var child in dictionarys)
                {
                    try
                    {
                        Hotel p = JsonConvert.DeserializeObject<Hotel>(JsonConvert.SerializeObject(child));
                        if (string.IsNullOrEmpty(p.Id)) p.Id = Guid.NewGuid().ToString();
                        this.AddItem(p);
                    }
                    catch (Exception e) { Console.WriteLine($"->{e.InnerException.Message}"); }
                }
            }
            return this;
        }
    }
}