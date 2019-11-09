using System.Collections.Generic;

namespace HashTable
{
    public class Item<T> 
    {
        public int Key { get; set; }
        
        public List<T> Nodes { get; set; }

        public Item(int key)
        {
            Key = Key; 
            Nodes = new List<T>();
        }
    }
}