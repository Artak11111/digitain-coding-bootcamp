using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class MyList<T>:IEnumerable<T>
    {
        //T[] elements = null;

        //public MyList()
        //{
        //    elements = new T[0];
        //}

        //public void Add(T value)
        //{
        //    var temp = new T[elements.Length+1];
        //    for (int i = 0; i < elements.Length; i++)
        //    {
        //        temp[i] = elements[i];
        //    }
        //    temp[elements.Length] = value;
        //    elements = temp;
        //}

        T[] elements = null;

        public MyList()
        {
            elements = new T[4];
            Capacity = 4;
        }

        public MyList(int Capacity)
        {
            this.Capacity = Capacity;
            elements = new T[Capacity];
        }

        public int Count { get; private set; } = 0;
        public int Capacity { get; private set; }

        public void Add(T value)
        {
            if (Count == Capacity)
            {
                ReSize();
            }
            elements[Count] = value;
            Count++;
        }

        private void ReSize()
        {
            var temp = new T[elements.Length * 2];
            for (int i = 0; i < elements.Length; i++)
            {
                temp[i] = elements[i];
            }
            elements = temp;
            Capacity = temp.Length;
        }

        public T this[int i]
        {
            get
            {
                return elements[i];
            }

            set
            {
                elements[i] = value;
            }
        }

        public void Clear()
        {
            elements = new T[0];
        }

        public bool Contains(T value,out int index)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i].Equals(value))
                {
                    index = 1;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        public void Remove()
        {
            var temp = new T[elements.Length - 1];
            Array.ConstrainedCopy(elements, 0, temp, 0,temp.Length);
        }

        public bool Remove(T value)
        {
            int index = 0;
            if (Contains(value,out index))
            {
                var temp = new T[elements.Length - 1];
                Array.ConstrainedCopy(elements, 0, temp, 0, index);
                Array.ConstrainedCopy(elements, index+1, temp, index, elements.Length - index-1);
                elements = temp;
                Count--;
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return elements.GetEnumerator();
        }
    }
}