using System;
using System.Collections;
using System.Collections.Generic;
using Assets.MicroWarcraft.Models.Capabilities;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Assets.MicroWarcraft.Utils
{
    public delegate void CollectionChangedEventHandler(object sender, NotifyCollectionChangedEventArgs arg);
    public class ObservableCollection<T> : Collection<T>, IEnumerable<T>, INotifyPropertyChanged
    {
        public event CollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private List<T> items;

        public object Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public new void Add(T element)
        {
            base.Add(element);
            if (CollectionChanged!=null)
            {
               var addedItems = new List<object>();
                addedItems.Add(element);
                var arg = new NotifyCollectionChangedEventArgs(addedItems);
                CollectionChanged(this, arg);
            }
        }
    }
}
