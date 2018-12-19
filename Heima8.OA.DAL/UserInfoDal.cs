using Heima8.OA.IDAL;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.DAL
{
    public partial class UserInfoDal : BaseDal<UserInfo>, IUserInfoDal
    {
        ////curd
        //DataModelContainer db = new DataModelContainer();

        //public IQueryable<UserInfo> GetUsers(Expression<Func<UserInfo,bool>> whereLambda)
        //{
        //    return db.UserInfo.Where(whereLambda).AsQueryable();
        //}

        ////分页
        //public IQueryable<UserInfo> GetPageUsers<S>(int pageSize, int pageIndex, out int total,Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, S>> orderLambda, bool isAsc)
        //{
        //    total = db.UserInfo.Where(whereLambda).Count();
        //    if (isAsc)
        //    {
        //        var temp = db.UserInfo.Where(whereLambda)
        //            .OrderBy<UserInfo, S>(orderLambda)
        //            .Skip(pageSize * (pageIndex - 1))
        //            .Take(pageSize).AsQueryable();
        //        return temp;
        //    }
        //    else
        //    {
        //        var temp = db.UserInfo.Where(whereLambda)
        //            .OrderByDescending<UserInfo, S>(orderLambda)
        //            .Skip(pageSize * (pageIndex - 1))
        //            .Take(pageSize).AsQueryable();
        //        return temp;
        //    }
        //}
        //public UserInfo Add(UserInfo userinfo)
        //{
        //    db.UserInfo.Add(userinfo);
        //    db.SaveChanges();
        //    return userinfo;
        //}

        //public bool Update(UserInfo userinfo)
        //{
        //    db.Entry(userinfo).State = EntityState.Modified;
        //    return db.SaveChanges() > 0;
        //}

        //public bool Delete(UserInfo userinfo)
        //{
        //    db.Entry(userinfo).State = EntityState.Deleted;
        //    return db.SaveChanges() > 0;
        //}
        
        
    }
}
