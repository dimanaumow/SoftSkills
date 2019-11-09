using System; 

namespace WorkToArray
{
   public static class ArrayExtention
    {
        #region StandartBubbleSort
        public static void BubbleSort(int[] array)
        {

            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} cannot be mull");
            }

            if (array.Length == 0)
            {
                return;
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] - array[j + 1] > 0)
                    {
                        Helper.Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
        #endregion

        #region ModernBubbleSort
        public static void BubbleSort(int[] array, IComparer comparer)
        {

            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} cannot be mull");
            }

            if (array.Length == 0)
            {
                return;
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        Helper.Swap(ref array[j], ref array[j + 1]); 
                    }
                }
            }
        }
        #endregion

        #region StandartQuickSort
        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can not be null!");
            }

            SortQuick(array, 0, array.Length - 1);
        }


        static public int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];

            while (true)

            {

                while (numbers[left] < pivot)
                {
                    left++;
                }


                while (numbers[right] > pivot)
                {
                    right--;
                }


                if (left < right)
                {
                    int temp = numbers[right];

                    numbers[right] = numbers[left];

                    numbers[left] = temp;

                }

                else
                {

                    return right;
                }
            }
        }


        static public void SortQuick(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    SortQuick(arr, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    SortQuick(arr, pivot + 1, right);
                }
            }

        }
        #endregion

        #region ModernQuickSort
        public static void QuickSort(int[] array, IComparer comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can not be null!");
            }

            QuickSort(array, 0, array.Length - 1, comparer);
        }

        private static void QuickSort(int[] array, int left, int right,
            IComparer comparer)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right, comparer);
                QuickSort(array, left, pivot - 1, comparer);
                QuickSort(array, pivot + 1, right, comparer);
            }
        }

        private static int Partition(int[] array, int low, int high,
            IComparer comparer)
        {
            int pivot = array[high];

            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (comparer.Compare(array[j], pivot) < 0)
                {
                    i++;
                    Helper.Swap(ref array[i], ref array[j]);
                }
            }

            Helper.Swap(ref array[i + 1], ref array[high]);

            return i + 1;
        }

        #endregion

        #region StandartMergeSort
        private static void MergeSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSort(array, low, middle);
                MergeSort(array, middle + 1, high);
                Merge(array, low, middle, high);
            }
        }

        public static void MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can not be null!");
            }

            if (array.Length == 0)
            {
                return;
            }

            MergeSort(array, 0, array.Length - 1);
        }

        private static void Merge(int[] input, int low, int middle, int high)
        {

            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left] < input[right])
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                }
                tmpIndex = tmpIndex + 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }

        }
        #endregion

        #region ModernMergeSort
        private static void MergeSort(int[] array, int low, int high, 
            IComparer comparer)
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSort(array, low, middle, comparer);
                MergeSort(array, middle + 1, high, comparer);
                Merge(array, low, middle, high, comparer);
            }
        }

        public static void MergeSort(int[] array, IComparer comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can not be null!");
            }

            if (array.Length == 0)
            {
                return;
            }

            MergeSort(array, 0, array.Length - 1, comparer);
        }

        private static void Merge(int[] input, int low, int middle, int high, 
            IComparer comparer)
        {

            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left] < input[right])
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                }
                tmpIndex = tmpIndex + 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }

        }

        #endregion
    }
}