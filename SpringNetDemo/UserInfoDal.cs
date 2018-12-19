using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringNetDemo
{
    public class UserInfoDal:IUserInfoDal
    {
        public void show()
        {
            Console.WriteLine("我是 AdoNet UserInfoDal " + Name);
        }

        public string Name { get; set; }
    }
}
