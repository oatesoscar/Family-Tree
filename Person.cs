using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;

namespace Family_Tree
{
    class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }
        public string FamilyName { get; set; }
        public string DadFirstName { get; set; }
        public string DadLastName { get; set; }
        public string MumFirstName { get; set; }
        public string MumLastName { get; set; }
        public bool IsAlive  { get; set; }
        public bool HasFamily { get; set; }
        public bool IsAMemberOfAFamily { get; set; }
        public bool HasParents { get; set; }
        public bool HasSiblings { get; set; }
        public bool HasChildren { get; set; }
    }
}
