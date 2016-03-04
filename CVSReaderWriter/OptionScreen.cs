using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReaderWriter
{
    class OptionScreen
    {
        public void ScreenOptions()
        {
            Console.WriteLine("*************************************"
                           +"\n         1 - Add New Person          "
                           +"\n         2 - Search for Name         "
                           +"\n         3 - Search by Phone Number  "
                           +"\n         4 - Show all the list       "
                           +"\n         5 - Exit                    "
                           +"\n**************************************");
        }


    }
}
