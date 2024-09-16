namespace CALINQ24091603
{
    internal class Pet
    {
        public string Name { get; set; }
        public string Speaces { get; set; }
        public bool Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age => 
            (int)(DateTime.Now - BirthDate).TotalDays / 365;

        public override string ToString()
        {
            return $"{Name} ({Age} years old {Speaces})";
        }
    }
}
