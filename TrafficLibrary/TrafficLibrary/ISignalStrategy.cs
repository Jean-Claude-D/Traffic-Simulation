using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    public interface ISignalStrategy
    {
        void Update();
        Colour GetColour(Direction dir);
    }
}