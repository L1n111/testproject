using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testproject.Models
{
    public class Genre
    {
        public required string Name { get; set; }
        public required string Icon { get; set; }
        public required Color Color { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
