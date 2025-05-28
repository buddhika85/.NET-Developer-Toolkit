using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Tests.SourceCode
{
    class BaseClass
    {
        public virtual void Show()
        {
            Console.WriteLine("BaseClass Show method");
        }
    }

    class DerivedClass : BaseClass
    {
        public new void Show() 
        {
            Console.WriteLine("DerivedClass Show method");
        }
    }

}
