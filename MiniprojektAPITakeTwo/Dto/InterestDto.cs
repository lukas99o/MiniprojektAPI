using System.ComponentModel.DataAnnotations;

namespace MiniprojektAPITakeTwo.Dto
{
    public class AssignInterestDto
    {
        [Required]
        public int PersonID { get; set; }

        [Required]
        public int InterestID { get; set; }
    }
}
