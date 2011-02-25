using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poll
{
    
    public class Criterion
    {
        private string _id;
        private string _name;
        private int _value;
        private int _importance;
        public string Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int Importance { get; set; }

    }
}
