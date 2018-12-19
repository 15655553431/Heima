
using Heima8.OA.DAL;
using Heima8.OA.DALFactory;
using Heima8.OA.IBLL;
using Heima8.OA.IDAL;
using Heima8.OA.Model;
using Heima8.OA.NHDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.BLL
{

    //模块内高内聚  模块间低耦合

   //变化点1、可能跨数据库，有mysql，sqlserver，数据库访问驱动层驱动变化
    public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService//crud
    {
        ////菜鸟级别
        ////UserInfoDal userinfoDal = new UserInfoDal();

        ////通过接口调用,一般开发人员，这是依赖接口编程，或是叫依赖抽象编程
        ////当改变了数据库层，可以将后面具体实现类换个名字就行,但是每个bll层的类都要改成这个新的dal类，还是麻烦
        ////IUserInfoDal userinfoDal = new NHUserInfoDal();
        ////稍微高级点的开发人员也不能这么写
        ////IUserInfoDal userinfoDal = new UserInfoDal();

        ////稍微高级点的开发人员,会这么写,这样换数据库层，只要在简单工厂里面把返回值改了就行，业务逻辑层不受任何影响
        ////这里重点在于抽象工厂里面的写法，只改配置文件就可以改变dal层
        ////private IUserInfoDal userinfoDal = StaticDalFactory.GetUserInfoDal();

        ////更好的方法是，使用DbSession，每次dal操作都是一个会话，并在bll层确定哪些操作是事务
        ////DbSession dbSession = new DbSession();
        ////IDbSession dbSession = new DbSession();

        ////最好给Dbsession方法再来一个抽象工厂，如下所示
        //private IDbSession dbSession = DbSessionFactory.GetCurrentDbSession();

        ////更高级 ：IOC DI 依赖注入的方式   Spring.NET




        //public UserInfo Add(UserInfo userinfo)//UnitWork单元工作模式
        //{
        //    //return userinfoDal.Add(userinfo);
        //    UserInfo u = dbSession.UserInfoDal.Add(userinfo);
        //    dbSession.UserInfoDal.Add(new UserInfo());
        //    dbSession.OrderInfoDal.Delete(new OrderInfo());
        //    dbSession.OrderInfoDal.Update(new OrderInfo());

        //    //数据提交的权利从数据库访问层提到了业务逻辑层
        //    //这里的好处是，业务层可能同时操作很多表，这时候你就可以调用多个方法，最后再保存，完成事务操作
        //    //最重要的是，多个操作批量提交，提升数据库链接性能
        //    dbSession.SaveChanges();
        //    return u;
        //}

        //public override void SetCurrentDal()
        //{
        //    CurrentDal = this.DbSession.UserInfoDal;
        //}
    }
}
