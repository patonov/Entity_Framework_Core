using System;
using System.Collections.Generic;
using System.Text;

namespace ORMtests
{
    class Villains
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EvilnessFactor factor { get; set; }

        public Minions minion { get; set; }
    }
}
