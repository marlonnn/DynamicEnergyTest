using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoboldCom
{
    /// <summary>
    /// Provides enum's value localized resource description key.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class LocalizedDescriptionAttribute : Attribute
    {
        #region Class members

        /// <summary>
        /// The localized description key.
        /// </summary>
        private String m_description;

        #endregion

        #region Class constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedDescriptionAttribute"/> class.
        /// </summary>
        /// <param name="description">The localized description key to store in this attribute.
        /// </param>
        public LocalizedDescriptionAttribute(String description)
            : base()
        {
            this.m_description = description;
        }

        #endregion

        #region Class properties

        /// <summary>
        /// Gets the localized desciption key stored in this attribute.
        /// </summary>
        /// <value>The localized description key stored in the attribute.</value>
        public String Description
        {
            get
            {
                return this.m_description;
            }
        }

        #endregion
    }
}
