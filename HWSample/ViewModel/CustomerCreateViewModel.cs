using HWSample.Models;
using System.Collections.Generic;

namespace HWSample.ViewModel
{
    public class CustomerCreateViewModel
    {
        public int Id { get; set; }
        public string 客戶名稱 { get; set; }
        public string 統一編號 { get; set; }
        public string 電話 { get; set; }
        public string 傳真 { get; set; }
        public string 地址 { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public string 帳號 { get; set; }
        public string 密碼 { get; set; }
        public List<客戶分類> 分類 { get; set; }
    }
}