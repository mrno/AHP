using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.Common
{
    public class SorteableObservableCollection<T> : ObservableCollection<T>
    {
        #region Constructors

        public SorteableObservableCollection() : base() { }
        public SorteableObservableCollection(IEnumerable<T> collection) : base(collection) { }
        
        #endregion

        #region Methods

        public void Sort<TKey>(Func<T, TKey> keySelector, ListSortDirection direction)
        {
            switch (direction)
            {
                case ListSortDirection.Ascending:
                    {
                        ApplySort(Items.OrderBy(keySelector));
                        break;
                    }
                case ListSortDirection.Descending:
                    {
                        ApplySort(Items.OrderByDescending(keySelector));
                        break;
                    }
            }
        }

        public void Sort<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer)
        {
            ApplySort(Items.OrderBy(keySelector, comparer));
        }

        private void ApplySort(IEnumerable<T> sortedItems)
        {
            var sortedItemsList = sortedItems.ToList();
            foreach (var item in sortedItemsList)
            {
                MoveItem(IndexOf(item), sortedItemsList.IndexOf(item));
            }
        }

        #endregion

    }
}
