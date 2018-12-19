using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heima8.OA.Common.Cache
{
    /// <summary>
    /// 使用memcahche做缓存
    /// </summary>
    public class MemcacheWriter:ICacheWriter
    {

        private MemcachedClient memcahchedClient;

        /// <summary>
        /// 构造函数
        /// </summary>
        public MemcacheWriter()
        {
            string strAppMemcachedServer = System.Configuration.ConfigurationManager.AppSettings["MemcachedServerList"];
            if (string.IsNullOrWhiteSpace(strAppMemcachedServer))
            {
                return;
            }

            
            //分布式Memcached 服务IP 端口 和权重
            string[] servers = strAppMemcachedServer.Split(';')[0].Split(',');
            List<int> weightslist=new List<int>();
            foreach(string strw in strAppMemcachedServer.Split(';')[1].Split(','))
            {
                weightslist.Add(Convert.ToInt32(strw));
            }

            int[] weights = weightslist.ToArray<int>();


            //初始化池
            // 获取socke连接池的实例对象
            SockIOPool pool = SockIOPool.GetInstance();
            // 设置服务器信息
            pool.SetServers(servers);
            pool.SetWeights(weights);

            // 设置初始连接数、最小和最大连接数以及最大处理时间
            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 200;
            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;

            //设置主线程睡眠时间
            pool.MaintenanceSleep = 30;

            //
            pool.Failover = true;
            pool.Nagle = false;
            pool.Initialize();

            //客户端实例
            MemcachedClient mc = new Memcached.ClientLibrary.MemcachedClient();
            mc.EnableCompression = false;

            memcahchedClient = mc;
        }


        public void AddCache(string key, object value, DateTime expDate)
        {
            memcahchedClient.Add(key,value,expDate);
        }

        public void AddCache(string key, object value)
        {
            memcahchedClient.Add(key, value);
        }

        public object GetCache(string key)
        {
            return memcahchedClient.Get(key);
        }

        public T GetCache<T>(string key)
        {
            return (T)memcahchedClient.Get(key);
        }


        public void SetCache(string key, object value, DateTime expDate)
        {
            memcahchedClient.Set(key, value, expDate);
        }

        public void SetCache(string key, object value)
        {
            memcahchedClient.Set(key, value);
        }
    }
}
