using System.ComponentModel.DataAnnotations;

namespace MiniprojektAPITakeTwo.Dto
{
    public class CreateInterestLinkDto
    {
        [Required]
        public int PersonID { get; set; }

        [Required]
        public int InterestID { get; set; }

        [Required]
        public string Link {  get; set; }
    }
}
