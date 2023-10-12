namespace HW1.Models.Exeption
{
    public class PersonBirthDayException : Exception
    {
        public PersonBirthDayException(string message)
        : base(message) { }
    }
}
