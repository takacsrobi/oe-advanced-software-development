using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStorage
{
    public class Storage<T>
    {
        //public delegate void Traverser(T item); // Action<T>
        //public delegate T Transformer(T input); // Func<T,T>

        T[] array;
        int pointer;
        Func<T,T> tranformers;

        public Storage(int size)
        {
            array = new T[size];
        }

        public void AddTransformer(Func<T, T> tr)
        {
            tranformers += tr;
        }

        public void Add(T item)
        {
            if (pointer < array.Length)
            {
                array[pointer++] = item;
            }
            else
            {
                throw new Exception("Storage is full");
            }   
        }

        public void Traverse(Action<T> tr)
        {
            for (int i = 0; i < pointer; i++)
            {
                T result = array[i];
                
                if (tranformers != null)
                {
                    foreach (var item in tranformers.GetInvocationList())
                    {
                        if (item != null)
                        {
                            result = (item as Func<T, T>).Invoke(result);
                        }
                    }
                }
                
                tr?.Invoke(result);
            }
        }
    }
}
