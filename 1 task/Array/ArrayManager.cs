using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variant11;

namespace Variant11
{
    public class ArrayManager
    {
        private int[] _data;

        public int[] Data => _data;

        public void ReadFromInput()
        {
            Console.WriteLine("Enter array elements separated by spaces: ");

            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(AppConstants.EmptyArrayError);
            }

            try
            {
                _data = input.Split(' ').Select(s => int.Parse(s)).ToArray();
            }
            catch (FormatException)
            {
                throw new FormatException(AppConstants.InvalidInputMessage);
            }
        }

        public void Display()
        {
            Console.WriteLine($"Array: {string.Join(" ", _data)}");
        }

        public int FindFirstMinIndex()
        {
            ValidateNonEmpty();
            return Array.IndexOf(_data, _data.Min());
        }

        public int FindLastMinIndex()
        {
            ValidateNonEmpty();
            return Array.LastIndexOf(_data, _data.Min());
        }

        private void ValidateNonEmpty()
        {
            if (_data.Length == 0)
            {
                throw new InvalidOperationException(AppConstants.EmptyArrayError);
            }
        }
    }
}
