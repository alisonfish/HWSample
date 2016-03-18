using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HWSample.Models
{   
	public  class vwCustomerListRepository : EFRepository<vwCustomerList>, IvwCustomerListRepository
	{

	}

	public  interface IvwCustomerListRepository : IRepository<vwCustomerList>
	{

	}
}