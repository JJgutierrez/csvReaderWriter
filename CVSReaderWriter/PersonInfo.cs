using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReaderWriter
{
    class PersonInfo
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public PersonInfo(string name, string lastName, string address, string phoneNumber)
        {
            Name = name;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }

}
