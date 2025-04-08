namespace Example.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set;}
        public int Age { get; set; }
        public int Dept { get; set; }
        public Department Department { get; set; }

    }
}
