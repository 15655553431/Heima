
 using Heima8.OA.DAL;
using Heima8.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.DALFactory
{
    public class DbSession:IDbSession
    {


		public IOrderInfoDal OrderInfoDal
        {
            get { return StaticDalFactory.GetOrderInfoDal(); }
        }


		public IUserInfoDal UserInfoDal
        {
            get { return StaticDalFactory.GetUserInfoDal(); }
        }

		/// <summary>
        /// 拿到当前的EF的上下文，然后进行 把修改的实体进行一个整体提交
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
	}
}