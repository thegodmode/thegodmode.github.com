using System;

namespace Student.Common
{
    public class Students : ICloneable,
        IComparable<Students>
    {
        private string fName;
        private string sName;
        private string tName;
        private int SSN;
        private string address;
        private string mobile;
        private string email;
        private Specialties specialty;
        private University university;
        private Faculty faculty;

        public Students(string fName, string sName, string tName, int ssn, string address, string mobile, string email, Specialties specialty, University university, Faculty faculty)
        {
            this.FName = fName;
            this.SName = sName;
            this.TName = tName;
            this.Ssn = ssn;
            this.address = address;
            this.Mobile = mobile;
            this.Email = email;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + ((fName != null) ? fName.GetHashCode() : 0);
                result = result * 23 + ((sName != null) ? sName.GetHashCode() : 0);
                result = result * 23 + ((tName != null) ? tName.GetHashCode() : 0);
                result = result * 23 + ((SSN != 0) ? SSN.GetHashCode() : 0);
                result = result * 23 + ((address != null) ? address.GetHashCode() : 0);
                result = result * 23 + ((mobile != null) ? mobile.GetHashCode() : 0);
                result = result * 23 + ((email != null) ? email.GetHashCode() : 0);
                result = result * 23 + specialty.GetHashCode();
                result = result * 23 + university.GetHashCode();
                result = result * 23 + faculty.GetHashCode();
                return result;
            }
        }

        public bool Equals(Students value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }
            if (ReferenceEquals(this, value))
            {
                return true;
            }
            return Equals(fName, value.fName) &&
                Equals(sName, value.sName) &&
                Equals(tName, value.tName) &&
                Equals(SSN, value.SSN) &&
                Equals(address, value.address) &&
                Equals(mobile, value.mobile) &&
                Equals(email, value.email) &&
                specialty.Equals(value.specialty) &&
                university.Equals(value.university) &&
                faculty.Equals(value.faculty);
        }

        public override bool Equals(object obj)
        {
            Students temp = obj as Students;
            if (temp == null)
            {
                return false;
            }
            return Equals(temp);
        }

        public static bool operator ==(Students std1, Students std2)
        {
            return Object.Equals(std1, std2);
        }

        public static bool operator !=(Students std1, Students std2)
        {
            return !Object.Equals(std1, std2);
        }

        public override string ToString()
        {
            return string.Format("FName: {1}, SName: {2}, TName: {3}, Ssn: {4}, Address: {5}, Mobile: {6}, Email: {7},University: {9},Faculty:{0},Specialty:{8}", Faculty, FName, SName, TName, Ssn, Address, Mobile, Email, Specialty, University);
        }

        public Faculty Faculty
        {
            get
            {
                return faculty;
            }
            set
            {
                faculty = value;
            }
        }

        public string FName
        {
            get
            {
                return fName;
            }
            set
            {
                fName = value;
            }
        }

        public string SName
        {
            get
            {
                return sName;
            }
            set
            {
                sName = value;
            }
        }

        public string TName
        {
            get
            {
                return tName;
            }
            set
            {
                tName = value;
            }
        }

        public int Ssn
        {
            get
            {
                return SSN;
            }
            set
            {
                SSN = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public Specialties Specialty
        {
            get
            {
                return specialty;
            }
            set
            {
                specialty = value;
            }
        }

        public University University
        {
            get
            {
                return university;
            }
            set
            {
                university = value;
            }
        }

        public Object Clone()
        {
            Students current = this;
            Students newStudent = new Students(current.FName, current.SName, current.TName, current.Ssn, current.address, current.Mobile, current.Email, current.Specialty, current.University, current.Faculty);
            return newStudent;
        }

        public int CompareTo(Students other)
        {
            if (this.fName.CompareTo(other.fName) != 0)
            {
                return this.fName.CompareTo(other.fName);
            }
            else if (this.sName.CompareTo(other.sName) != 0)
            {
                return this.sName.CompareTo(other.sName);
            }
            else if (this.tName.CompareTo(other.tName) != 0)
            {
                return this.tName.CompareTo(other.tName);
            }
            else if (this.SSN != other.SSN)
            {
                return this.SSN - other.SSN;
            }
            return 0;
        }
    }
}