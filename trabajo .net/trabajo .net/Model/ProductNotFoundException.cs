using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class ProductNotFoundException: Exception
    {
        public ProductNotFoundException() 
        {

        }

        public ProductNotFoundException(string msg) : base(msg) 
        {

        }

        public ProductNotFoundException(string msg,Exception inner): base (msg) 
        {

        }
    }
}
