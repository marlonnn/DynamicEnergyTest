using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoboldCom
{
    /// <summary>
    /// Provides a resource type to use for localized enumeration.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
    public sealed class LocalizedResourceAttribute : Attribute
    {
        #region Class members

        /// <summary>
        /// The resource type.
        /// </summary>
        private Type m_type;

        #endregion

        #region Class constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedResourceAttribute"/> class.
        /// </summary>
        /// <param name="type">The description to store in this attribute.
        /// </param>
        public LocalizedResourceAttribute(Type type)
            : base()
        {
            this.m_type = type;
        }

        #endregion

        #region Class properties

        /// <summary>
        /// Gets the resource type stored in this attribute.
        /// </summary>
        /// <value>The resource type stored in the attribute.</value>
        public Type Type
        {
            get
            {
                return this.m_type;
            }
        }

        #endregion
    }
}
