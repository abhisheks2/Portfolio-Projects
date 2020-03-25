using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCMSDataAccessLayer
{
    public class UsersDTO
    {
        private string user = "";
        private string pass = "";
        private string role = "";
        private int doctorID;

        public string USER
        {
            get { return user; }
            set { user = value; }
        }

        public string PASS
        {
            get { return pass; }
            set { pass = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public int DoctorID
        {
            get { return doctorID; }
            set { doctorID = value; }
        }

        public UsersDTO(string user, string pass, string role, int doctorID)
        {
            this.user = user;
            this.pass = pass;
            this.role = role;
            this.doctorID = doctorID;
        }
    }
}