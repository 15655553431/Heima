
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.IDAL
{
    public interface IDbSession
    {
    	IOrderInfoDal OrderInfoDal { get;}
    
    	IUserInfoDal UserInfoDal { get;}
    
	    int SaveChanges();
    }
}