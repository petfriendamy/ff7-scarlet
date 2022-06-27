using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public class Attack
    {
        public int ID { get; }
        public FFText Name { get; }

        public Attack(int id, FFText name)
        {
            ID = id;
            Name = name;
        }
    }
}
