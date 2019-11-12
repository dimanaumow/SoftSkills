namespace LinkedList.Model
{
    public class LinkedList<T>
    {
        public Item<T> Head { get; private set; }
        
        public Item<T> Teil { get; private set; }
        
        public int Count { get; private set; }

        public LinkedList()
        {
            Head = null;
            Teil = null;
            Count = 0; 
        }

        public LinkedList(T data)
        {
            var item = new Item<T>(data);
            SetHeadAndTeil(item);
        }

        public void Add(T data)
        {
            var item = new Item<T>(data);
            if (Teil != null)
            {
                Teil.Next = item;
                Teil = item;
                Count++; 
            }
            else
            {
                SetHeadAndTeil(item);
            }
        }

        public void Remove(T data)
        {
            if(Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return; 
                }

                var current = Head.Next;
                var previous = Head;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--; 
                    }

                    previous = current;
                    current = current.Next; 
                }
            }
        }
        private void SetHeadAndTeil(Item<T> item)
        {
            Head = item;
            Teil = item;
            Count = 1;
        }
    }
}