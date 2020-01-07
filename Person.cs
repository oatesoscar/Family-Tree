
namespace Family_Tree
{
    class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }
        public string FamilyName { get; set; }
        public string FatherFirstName { get; set; } 
        public string FatherLastName { get; set; } 
        public string MotherFirstName { get; set; } 
        public string MotherLastName { get; set; } 
        public bool IsAlive { get; set; } = false;
        public bool HasFamily { get; set; } = false;
        public bool IsAFamilyMember { get; set; } = false;
        public bool HasParents { get; set; } = false;
        public bool HasSiblings { get; set; } = false;
        public bool HasChildren { get; set; } = false;

        public byte convertToInt(bool test)
        {
            byte result;
            if (test == true)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }
    }
}
