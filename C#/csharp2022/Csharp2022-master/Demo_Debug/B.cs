using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Debug
{
    public class B
    {
        public int a { get; set; }

        public void MethodB()
        {
            C c = new C();
            for (int i = 0; i < 200; i++)
            {
                a += 1;
            }
            c.MethodC(this);

        }
    }
}
