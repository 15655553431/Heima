
 using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heima8.OA.DALFactory;
using Heima8.OA.IBLL;

namespace Heima8.OA.BLL
{


	public partial class OrderInfoService : BaseService<OrderInfo>, IOrderInfoService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.OrderInfoDal;
        }
    }


	public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.UserInfoDal;
        }
    }


}