using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsMix
{
    abstract class Object
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        private DateTime CreatedAt { get; set; }
        private DateTime UpdatedAt { get; set; }
        
        public Object() { }
    }
}
