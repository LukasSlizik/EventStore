using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Library.Entities
{
    public class Person : RestorableObject<Person>
    {
        string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public Person() {}
    }
}
