using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class Anime
    {
        public Anime(string name, string description, int seasonCount)
        {
            this.Name = name;
            this.Description = description;
            this.SeasonCount = seasonCount;
        }

        public string Name { private set; get; }
        public string Description { private set; get; }
        public int SeasonCount { private set; get; }
    }
}
