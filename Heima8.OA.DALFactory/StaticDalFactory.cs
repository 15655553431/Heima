
 using Heima8.OA.DAL;
using Heima8.OA.IDAL;
using Heima8.OA.NHDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.DALFactory
{
    public class StaticDalFactory
    {
		public static string assemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];
		public static IOrderInfoDal GetOrderInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName+".OrderInfoDal") as IOrderInfoDal;
        }
	

		public static IUserInfoDal GetUserInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName+".UserInfoDal") as IUserInfoDal;
        }
	

	}
}


