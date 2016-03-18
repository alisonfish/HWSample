using HWSample.Models;
using System.ComponentModel.DataAnnotations;

namespace HWSample.ViewModel
{
    public class ContactViewModel
    {
        [Required]
        public int Id { get; set; }

        public string Title { get; set; }

        public string CellPhone { get; set; }

        public string Phone { get; set; }
    }
}