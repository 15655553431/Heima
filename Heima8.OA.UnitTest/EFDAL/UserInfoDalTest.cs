using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Heima8.OA.DAL;
using Heima8.OA.Model;
using System.Linq;
using Heima8.OA.DALFactory;

namespace Heima8.OA.UnitTest.EFDAL
{
    [TestClass]
    public class UserInfoDalTest
    {
        [TestMethod]
        public void TestGetUsers()
        {
            //测试获取数据
            UserInfoDal dal = new UserInfoDal(); 


            //单元测试必须自己处理数据，不能依赖第三方数据，如果依赖数据，那么先自己创建数据
            //然后用完之后，再清除数据

            //创建测试的数据
            for (var i = 0; i < 10; i++)
            {
                dal.Add(new UserInfo()
                {
                    UName = i + "sssss"
                });
            }

            IQueryable<UserInfo> temp = dal.GetEntities(u => u.UName.Contains("ssss"));

            //断言
            Assert.AreEqual(true, temp.Count() > 10);

            //删除数据,没有id，没法删除
            //for (var i = 0; i < 10; i++)
            //{
            //    dal.Delete(new UserInfo()
            //    {
            //        UName = i + "sssss"
            //    });
            //}
            

        }
    }
}
