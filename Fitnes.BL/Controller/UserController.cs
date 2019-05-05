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
        public List<User> Users{ get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User name cant be empty",nameof(userName));
            }

            Users = new List<User>();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser==null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }
        /// <summary>
        /// resive saved users list
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length>0 && formatter.Deserialize(fs) is List<User> users)
                {
                   return users;
                }
                else
                {
                    return new List<User>();
                }

            }
            return null;
        }
        /// <summary>
        /// Save User
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }

        public void SetUserData(string genderName, DateTime birthDate,double weight=1, double height=1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
       
    }
}