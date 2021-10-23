using System.ComponentModel.DataAnnotations;

namespace WebUI.Data
{
    public class Medium
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }

        public Medium()
        {

        }

        public Medium(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}