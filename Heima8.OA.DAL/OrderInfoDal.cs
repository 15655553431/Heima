﻿using Heima8.OA.IDAL;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.DAL
{
    public partial class OrderInfoDal : BaseDal<OrderInfo>, IOrderInfoDal
    {
        //dry原则，不要重复代码
    }
}
