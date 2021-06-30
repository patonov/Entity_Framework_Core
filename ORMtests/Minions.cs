using System;
using System.Collections.Generic;
using System.Text;

namespace ORMtests
{
    class Minions
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Town town { get; set; }

        public Villains villain { get; set; }
    }
}
