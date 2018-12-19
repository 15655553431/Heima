using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Heima8.OA.Common
{
    //方法一：执行委托方法，把异常信息写到委托里面
    //public delegate void WriteLogDel(string str);


    public class LogHelper
    {
        //定义一个存储异常信息的队列
        public static Queue<string> ExceptionStringQueue = new Queue<string>();


        //方法一：执行委托方法，把异常信息写到委托里面
        //public static WriteLogDel WriteLogDelFunc;

        //方法二 使用接口集合
        public static List<ILogWriter> LogWriterList = new List<ILogWriter>();

        //静态构造方法，在调用结束之后，执行
        static LogHelper()
        {
            //方法一：执行委托方法，把异常信息写到委托里面
            //WriteLogDelFunc = new WriteLogDel(WriteLogToFile);
            //WriteLogDelFunc += WriteLogToMongoDb;


            //方法二 使用接口集合
            LogWriterList.Add(new TextFileWriter());
            LogWriterList.Add(new SqlServerWriter());


            //把从队列中获取的错误信息，写到日志文件里面去
            ThreadPool.QueueUserWorkItem(o => 
                    {
                        lock (ExceptionStringQueue)
                        {
                            string str = ExceptionStringQueue.Dequeue();
                            //把异常信息写到 日志文件里面去
                            //实际问题：有可能写入日志文件，有可能写到数据库，也有可能都写入
                            //使用观察者模式

                            //方法一：执行委托方法，把异常信息写到委托里面
                            //直接调用
                            //WriteLogDelFunc(str);

                            //方法二 使用接口集合

                            //只写到一个地方
                            //ILogWriter writer = new TextFileWriter();
                            //writer.WriteLogInfo(str);

                            //遍历集合
                            foreach (var logWriter in LogWriterList)
                            {
                                logWriter.WriteLogInfo(str);
                            }
                       
                        }
                    });
        }


        //方法一：执行委托方法，把异常信息写到委托里面
        //假设这个是写入文件日志的方法
        //public static void WriteLogToFile(string txt)
        //{

        //}

        //方法一：执行委托方法，把异常信息写到委托里面
        //假设这个是写入数据库日志的方法
        //public static void WriteLogToMongoDb(string txt)
        //{

        //}

        public static void WriteLog(string exceptionText)
        {
            //锁住这个队列
            lock (ExceptionStringQueue)
            {
                //这里只是把错误信息加入队列，并没写入日志文件，还没有保存
                ExceptionStringQueue.Enqueue(exceptionText);
            }
        }



    }
}
