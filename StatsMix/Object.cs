using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsMix
{
    abstract class Object
    {
        protected string Scope;
        public int id { get; set; }
        public int profile_id { get; set; }
        private DateTime created_at { get; set; }
        private DateTime updated_at { get; set; }
        
        public Object() { }

        public void create() {}
        public void update() {}
        public void get() {}
        public void delete() {}
        public void all() {}
    }
}
