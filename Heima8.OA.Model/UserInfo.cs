//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Heima8.OA.Model
{
    using System;
    using System.Collections.Generic;
    
    [Serializable]
    public partial class UserInfo
    {
        public UserInfo()
        {
            this.DelFlag = 0;
            this.OrderInfo = new HashSet<OrderInfo>();
        }
    
        public int ID { get; set; }
        public string UName { get; set; }
        public string Pwd { get; set; }
        public string ShowName { get; set; }
        public short DelFlag { get; set; }
    
        public virtual ICollection<OrderInfo> OrderInfo { get; set; }
    }
}
