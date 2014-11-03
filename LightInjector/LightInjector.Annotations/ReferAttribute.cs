using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightInjector.Annotations
{
    /// <summary>
    /// Inject an instance from LightInjector.
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ReferAttribute : Attribute
    {
        /// <summary>
        /// Managed name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether the instance is necessary
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ReferAttribute() : this(string.Empty) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Managed name. If this value is not been set, a default value will be generate.</param>
        public ReferAttribute(string name) : this(name, true) { }

        public ReferAttribute(string name, bool required)
        {
            this.Name = name;
            this.Required = required;
        }
    }
}
