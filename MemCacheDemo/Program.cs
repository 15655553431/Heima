using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemCacheDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //分布式Memcached 服务IP 端口 和权重
            string[] servers = {  "47.100.198.205:11211" };
            int[] weights = {3};

            //初始化池
            //SockIOPool pool =

            // 获取socke连接池的实例对象
            SockIOPool pool = SockIOPool.GetInstance();
            // 设置服务器信息
            pool.SetServers( servers );
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

            
            //mc.Add("keyddd", "这是mm缓存的数据",DateTime.Now.AddDays(1));


            Console.WriteLine(mc.Get("keyddd"));

            Console.ReadKey();
        }
    }
}
