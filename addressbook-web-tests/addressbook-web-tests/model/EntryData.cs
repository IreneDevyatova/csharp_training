﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class EntryData : IEquatable<EntryData>, IComparable<EntryData>
    {
        private string allPhones;
        private string allEmails;

        public EntryData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(EntryData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Firstname == other.Firstname) && (Lastname == other.Lastname);
        }

        public override int GetHashCode()
        {
            return (Firstname + " " + Lastname).GetHashCode();
        }
        public override string ToString()
        {
            return "Forename = " + Firstname + "\nSurname = " + Lastname;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int CompareTo(EntryData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int result = Lastname.CompareTo(other.Lastname);
            if (result != 0)
            {
                return result;
            }
            else
            {
                return Firstname.CompareTo(other.Firstname);
            }
        }

        public string Middlename { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }
        
        public string Company { get; set; }
        
        public string Address { get; set; }
        
        public string Home { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }
        
        public string Fax { get; set; }

        public string AllPhones
        {
            get
            { 
                if(allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(Phone2)).Trim();
                }
            }

            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if(phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[- ()]", "") + "\r\n";
        }

        public string Email { get; set; }
        
        public string Email2 { get; set; }
         
        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return Clean(Email) + Clean(Email2) + Clean(Email3).Trim();
                }
            }

            set
            {
                allEmails = value;
            }
        }

        public string Clean(string email1)
        {
            if (email1 == null || email1 == "")
            {
                return "";
            }
            return email1.Replace(" ", "") + "\r\n";
        }
    
        public string Homepage { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }
        
        public string Notes { get; set; }

        public string BDay { get; set; }

        public string BMonth { get; set; }

        public string BYear { get; set; }

        public string ADay { get; set; }

        public string AMonth { get; set; }
        
        public string AYear { get; set; }

        public string Id { get; set; }

        //public string EntryGroup { get; set; }
        
    }
}
