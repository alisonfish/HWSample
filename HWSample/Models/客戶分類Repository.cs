using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HWSample.Models
{   
	public  class 客戶分類Repository : EFRepository<客戶分類>, I客戶分類Repository
	{
        public List<string> GetList()
        {

            return this.All().Select(p => p.分類名稱).ToList();
        }
    }

	public  interface I客戶分類Repository : IRepository<客戶分類>
	{

	}
}