using System.ComponentModel.DataAnnotations;

namespace NinetyOne.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string SecondName { get; set; }
        public int Score { get; set; }
    }
}
