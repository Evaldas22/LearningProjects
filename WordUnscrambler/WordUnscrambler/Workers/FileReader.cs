using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordUnscrambler.Workers
{
    class FileReader // generic file reader
    {
        public string[] Read(string wordListFileName)
        {
            string[] fileContents;
            try // what if file doesn't exist
            {
                fileContents = File.ReadAllLines(wordListFileName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); //rethrow exeption
            }
            return fileContents;

        }
    }
}
