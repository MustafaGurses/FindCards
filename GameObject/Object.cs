using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObject
{
    public class Object
    {
        private string FileName;
        public Object(string fileName)
        {
            FileName1 = fileName;
        }
        public string FileName1 
        { 
            get => FileName; 
            set => FileName = value; 
        }
    }
}
