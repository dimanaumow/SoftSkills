namespace UserLibrary
{
    public class Person
    {
        public string Name { get; set; }
        
        public int Age { get; set; }

        public override string ToString()
        {
            return Name; 
        }

        public override int GetHashCode() 
            => Name.Length + Age + (int) Name[0]; 
    }
}