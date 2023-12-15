using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza
{
    public class BazaImpl : IBaza
    {
       public BazaImpl instance { get; set; }=null;

        public BazaImpl() 
        { 
        }


        public BazaImpl getInstance()
        {
            if (instance == null)
            {
                instance = new BazaImpl();
            }
               
            return instance;

        }
    }
}
