using System;

namespace ArraySample.Service
{
    public class ProductService : IProductService
    {
        public int[] ReverseArray(int[] array)
        {
            if (array.Length == 0)
                return array;

            var arrayLastIndex = array.Length - 1;

            //loop through the first half of the list
            for (var i = 0; i < array.Length / 2; i++)
            {
                var tmpValue = array[i];

                //Swap array indexes
                array[i] = array[arrayLastIndex - i];
                array[arrayLastIndex - i] = tmpValue;
            }

            return array;
        }

        public int[] DeleteFromArray(int[] array, int position)
        {
            if (position <= 0 || position > array.Length)
                throw new ArgumentOutOfRangeException();

            //Create new array variable
            var newArray = new int[array.Length - 1];

            //Adjust position for 0 based index
            position -= 1;

            //new array index
            var newArrayIndex = 0;

            for (var i = 0; i < array.Length; i++)
            {
                if (i == position) continue;
                newArray[newArrayIndex] = array[i];
                newArrayIndex++;
            }

            return newArray;
        }
    }
}