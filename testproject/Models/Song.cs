using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testproject.Models
{
    public class Song
    {
        public required string Name { get; set; }
        public required int Duration { get; set; }
        public required string Artist { get; set; }
        public required string Icon { get; set; }
        public required List<Genre> Genres { get; set; }
    }
}
