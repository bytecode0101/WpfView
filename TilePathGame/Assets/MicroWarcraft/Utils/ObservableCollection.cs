using System;
using System.Collections;
using System.Collections.Generic;
using Assets.MicroWarcraft.Models.Capabilities;

namespace Assets.MicroWarcraft.Utils
{
    public class ObservableCollection<T>: IEnumerable<T>
    {
        public Action<object, NotifyCollectionChangedEventArgs> CollectionChanged { get; internal set; }

        public object Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        internal void Add(T element)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
