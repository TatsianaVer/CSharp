using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTeachers
{
    public class Teacher
    {
        private readonly string _lastName;
        private readonly string _department;
        private readonly int[] _mounthlyWorkload;

        public Teacher(string lastName, string department, int[] mounthlyWorkload)
        {
            if (mounthlyWorkload.Length != 10)
            {
                throw new ArgumentException("Workload must contain exactly 10 months data");
            }

            _lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            _department = department ?? throw new ArgumentNullException(nameof(department));
            _mounthlyWorkload = mounthlyWorkload;
        }

        public string LastName => _lastName;
        public string Department => _department;
        public int AnnualWorkLoad => _mounthlyWorkload.Sum();

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= 10)
                {
                    throw new IndexOutOfRangeException("Month index must be between 0 and 9");
                }

                return _mounthlyWorkload[index];
            }
        }

        public IEnumerable<int> MounthlyWorkload => _mounthlyWorkload;
    }
}
