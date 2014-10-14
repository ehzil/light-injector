using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightInjector.Core
{
    /// <summary>
    /// Object Container
    /// </summary>
    internal class ObjectContainer
    {
        public static Dictionary<string, object> Objects { get; set; }

        static ObjectContainer()
        {
            Objects = new Dictionary<string, object>();
        }
    }
}
