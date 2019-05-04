using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Gender
    /// </summary>

    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Gender Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create new Gender
        /// </summary>
        /// <param name="name">Gender Name</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("gander name cant be empty");
            }
            Name = name;

        }
        public override string ToString()
        {
            return Name;

        }

    }
}