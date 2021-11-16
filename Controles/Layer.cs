using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controles
{
    class Layer
    {

        public string Name { get; private set; }
        public bool Active { get; set; } = true;
        public bool Visible { get; set; } = true;
        public List<Sprite> Sprites { get; private set; }

        public Layer(string name)
        {
            Name = name;

            Sprites = new List<Sprite>();
        }

    }
}
