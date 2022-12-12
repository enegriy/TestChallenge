using System;
using System.Collections.Generic;

namespace ConsoleApp9
{
    //Найти сколько раз встречается самый частый элемент в объединении двух отсортированных по возрастанию массивах.
    //Элементы могут повторяться. Алгоритм должен работать за линейное время.
    //И дополнительные массивы в целях экономии памяти создавать нельзя.
    //findMaxCount([1, 2, 9, 10], [2, 2, 10]) => 3

    internal class OftenItemArray
    {
        public KeyValuePair<int, int> FindNotSorted(int[] array1, int[] array2)

        {
            var itemsCount = new Dictionary<int, int>();

            int ind = 0;

            while (ind < array1.Length || ind < array2.Length)
            {
                if (ind < array1.Length)
                {
                    AddItem(itemsCount, array1[ind]);
                }

                if (ind < array2.Length)
                {
                    AddItem(itemsCount, array2[ind]);
                }

                ind++;
            }

            var result = new KeyValuePair<int, int>(0, 0);
            foreach (var item in itemsCount)
            {
                if (item.Value > result.Value)
                {
                    result = item;
                }
            }

            return result;
        }

        public int FindSorted(int[] array1, int[] array2)
        {
            var ind1 = 0;
            var ind2 = 0;
            var itemStore = new KeyValuePair<int, int>(0, 0);

            while (ind1 < array1.Length || ind2 < array2.Length)
            {
                int item = GetMin(array1, array2, ind1, ind2);
                int count = 0;

                while (array1.Length > ind1 && array1[ind1] == item)
                {
                    count++;
                    ind1++;
                }

                while (array2.Length > ind2 && array2[ind2] == item)
                {
                    count++;
                    ind2++;
                }

                if (count > itemStore.Value)
                {
                    itemStore = new KeyValuePair<int, int>(item, count);
                }
            }
            return itemStore.Value;
        }

        private void AddItem(Dictionary<int, int> itemsCount, int item)
        {
            if (itemsCount.ContainsKey(item))
                itemsCount[item] = itemsCount[item] + 1;
            else
                itemsCount[item] = 1;
        }

        private int GetMin(int[] array1, int[] array2, int ind1, int ind2)
        {
            var item1 = GetItem(array1, ind1);
            var item2 = GetItem(array2, ind2);

            return Math.Min(item1, item2);
        }

        private int GetItem(int[] array, int ind)
        {
            var item = int.MaxValue;

            if (array.Length > ind)
                item = array[ind];

            return item;
        }
    }
}
