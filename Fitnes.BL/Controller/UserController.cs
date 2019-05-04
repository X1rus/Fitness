using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Fitness.BL.Model;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// User controller
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Aplication User
        /// </summary>
        public User User { get; }

        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
            //User=user ?? throw new ArgumentNullException("User cant be Null",nameof(user));
        }
        /// <summary>
        /// Save User
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Resive Users
        /// </summary>
        /// <returns></returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                //else{
                //    throw new FileLoadException("cant load users from file","users.dat");
                //}
            }
        }
    }
}