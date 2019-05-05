using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Userd
    /// </summary>
[Serializable]
   public class User
   {
       #region User Properties
       /// <summary>
       /// Name
       /// </summary>
       /// <param name="name">User Name</param>
       public string Name { get;  }
       /// <summary>
       /// Gender
       /// </summary>
       /// <param name="gender">User Gender</param>
        public Gender Gender { get; set; }
       /// <summary>
       /// Birth date
       /// </summary>
        /// <param name="birthdate">User BirthDate</param>
        public DateTime BirthDate { get; set; }
       /// <summary>
       /// User Weight
       /// </summary>
        /// <param name="weight">User Weight</param>
        public double Weight { get; set; }
       /// <summary>
       /// User Height
       /// </summary>
        /// <param name="height">User Height</param>
        public double Height { get; set; }
       #endregion

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height )
        {
            #region Checked exeption
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cant be empty or Null",nameof(name)); 
            }
            if (gender==null)
            {
                throw new ArgumentNullException("Gender cant be Null",nameof(gender));
            }
            if (birthDate< DateTime.Parse("01.01.1900") || birthDate>=DateTime.Now)
            {
                throw new ArgumentException("wrong Birth Date",nameof(birthDate));
            }
            if (weight<=0)
            {
                throw new ArgumentException("Wrong Weight",nameof(weight)); 
            }

            if (height<=0)
            {
                throw new ArgumentException("Wrong Height", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }



        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cant be empty or Null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name+ " "+ Age;
        }

    }
}
