using CharacterConfigurator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Controller
{
    class Controller<TItem> where TItem : Item<TItem>
    {
        public List<TItem> Items { get; private set; }

        public Controller() 
        {
            Load();
        }

        public void AddItem(TItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(int index)
        {
            Items.RemoveAt(index);
        }

        public void UpdateItem(int index, TItem item)
        {
            Items[index] = item;
        }

        public void Save()
        {

        }

        private void Load()
        {
            //Only placeholder code
            string tableName = Item<TItem>.DbTableName;
            Items = new List<TItem>();
        }
    }
}
