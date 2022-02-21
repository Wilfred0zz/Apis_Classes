using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi
{
    public interface IProfile
    {
        string Name { get; set; }
        int Age { get; set; }
        char Gender { get; set; }
        string Email { get; set; }

        void ShowInfoEntered();

        void CreateUser();

        event EventHandler UserAdded;

        int this[int profileId]
        {
            get;
            set;
        }

    }

}
