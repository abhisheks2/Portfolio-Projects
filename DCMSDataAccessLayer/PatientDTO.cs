using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCMSDataAccessLayer
{
    public class PatientDTO
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string contactNo;

        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private string sex;

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string maritalStatus;

        public string MaritalStatus
        {
            get { return maritalStatus; }
            set { maritalStatus = value; }
        }
        private string occupation;

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }
        private string medInfo;

        public string MedInfo
        {
            get { return medInfo; }
            set { medInfo = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string dob;
        public string DOB
        {
            get { return dob; }
            set { dob = value; }
        }

        public PatientDTO(string name, string address, string contactNo, int age, string sex, string maritalStatus, string occupation, string medInfo, string email, string dob)
        {
            this.name = name;
            this.address = address;
            this.contactNo = contactNo;
            this.age = age;
            this.sex = sex;
            this.dob = dob;
            this.maritalStatus = maritalStatus;
            this.occupation = occupation;
            this.email = email;
            this.medInfo = medInfo;
        }

    }
}