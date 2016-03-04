using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace CSVReaderWriter
{
    class Program
    {
       static void Main()
        {
            try
            {
                ChooseOptions cp = new ChooseOptions();
                cp.Cases();
            }
            catch(Exception e)
            {
                Console.WriteLine("Something unexpected happened here .....\n{0}",e);
            }
        }
    }
}
