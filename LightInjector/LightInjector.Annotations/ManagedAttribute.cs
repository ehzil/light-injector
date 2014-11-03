using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightInjector.Annotations
{
    /// <summary>
    /// Specify the classes been managed by LightInjector
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ManagedAttribute : Attribute
    {
        /// <summary>
        /// Managed name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ManagedAttribute() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Managed name. If this value is not been set, a default value will be generate.</param>
        public ManagedAttribute(string name)
        {
            this.Name = name;
        }
    }
}
