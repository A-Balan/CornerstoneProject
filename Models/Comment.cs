using System.ComponentModel.DataAnnotations;

namespace CornerstoneChecklist.Models
{
    public class Comment
    {
        private DateTime _created;
        private DateTime? _updated;

        //primary key
        public int Id { get; set; }

        //created and updated
        public DateTime Created
        {
            get => _created;
            set => _created = value.ToUniversalTime();
        }

        public DateTime? Updated
        {
            get => _updated;
            set => _updated = value.HasValue ? value.Value.ToUniversalTime() : null;
        }

        [Display(Name = "Update Reason")]
        [StringLength(200, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string? UpdateReason { get; set; }

        [Required]
        [Display(Name = "Comment")]
        [StringLength(5000, ErrorMessage = "The {0} must be at most {1} characters long.", MinimumLength = 2)]
        public string? Body { get; set; }
    }

}