
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInfoDal userinfoDal = new UserInfoDal();
            userinfoDal.show();

            //下面走一个容器来，创建UserInfoDal实例
            
            //第一步，初始化容器
            //创建spring容器上下文
            IApplicationContext ctx = ContextRegistry.GetContext();
            //通过容器创建对象
            IUserInfoDal uiDal = ctx.GetObject("UserInfoDal") as IUserInfoDal;
            uiDal.show();




            Console.ReadKey();

            

        }
    }
}
