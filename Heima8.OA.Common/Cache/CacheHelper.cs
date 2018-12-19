using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.Common.Cache
{
    public class CacheHelper
    {
        //使用spring.net直接注入一个cache的实现.(实现：改一个webconfig配置就能做到切换缓存服务)
        //第一种方法，就是使用抽象工厂去实现，比较麻烦，效果是一样的，而且效率差不多
        //第二种方法，使用spring.net就很棒


        //正常来说，使用那种缓存就new某个具体实现方法就ok，但这样一旦需要更换一下缓存，就要改代码，重新编译，很麻烦。
        //ICacheWriter cacheWriter = new MemcacheWriter();
        //ICacheWriter cacheWriter = new HttpRuntimeCacheWriter();

        /// <summary>
        /// 注意：静态属性不需要实例，就可以直接拿来就用。
        /// spring.net一般在实例化的时候才会去注入，必须保证在下面的具体方法执行之前必须注入
        /// 方案一：在Global里，项目启动的时候直接通过容器创建一个CacheHelper对象，
        /// 方案二：在CacheHelper构造函数里面，通过容器创建对象
        /// 使用spring.net注入
        /// </summary>
        public static ICacheWriter CacheWriter { get; set; }// = new HttpRuntimeCacheWriter();//
        //这里使用spring.net属性注入方式


        static CacheHelper()
        {
            //方案二：在CacheHelper构造函数里面，通过容器创建对象
            //第一步，初始化容器
            //创建spring容器上下文

            IApplicationContext ctx = ContextRegistry.GetContext();

            //通过容器创建对象,给静态属性注入
            ctx.GetObject("CacheHelper");

            //或者直接赋值,通过容器获取( 这种方案行不通，还不清楚原因)
            //CacheHelper.CacheWriter = ctx.GetObject("CacheHelper") as ICacheWriter;

        }

        public static void AddCache(string key, object value, DateTime expDate)
        {
            CacheWriter.AddCache(key, value, expDate);
        }

        public static void AddCache(string key, object value)
        {
            CacheWriter.AddCache(key, value);
        }

        public static T GetCache<T>(string key)
        {
            return (T)CacheWriter.GetCache(key);
        }

        public static object GetCache(string key)
        {
            return CacheWriter.GetCache(key);
        }


        public static void SetCache(string key, object value, DateTime expDate)
        {
            CacheWriter.SetCache(key, value, expDate);
        }

        public static void SetCache(string key, object value)
        {
            CacheWriter.SetCache(key, value);
        }

    }
}
