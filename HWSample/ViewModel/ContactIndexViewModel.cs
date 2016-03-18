using HWSample.Models;
using System.ComponentModel.DataAnnotations;

namespace HWSample.ViewModel
{
    public class ContactIndexViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }

        public virtual 客戶資料 Customer { get; set; }
    }
}