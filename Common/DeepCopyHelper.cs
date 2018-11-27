using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common
{
    /// <summary>
    /// 对象的深度拷贝（序列化的方式）
    /// </summary>
    public class DeepCopyHelper
    {
        /// <summary>
        /// xml序列化的方式实现深拷贝
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T XmlDeepCopy<T>(T t)
        {
            //创建Xml序列化对象
            XmlSerializer xml = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())//创建内存流
            {
                //将对象序列化到内存中
                xml.Serialize(ms, t);
                ms.Position = default;//将内存流的位置设为0
                return (T)xml.Deserialize(ms);//继续反序列化
            }
        }

        /// <summary>
        /// 二进制序列化的方式进行深拷贝
        /// 确保需要拷贝的类里的所有成员已经标记为 [Serializable] 如果没有加该特性特报错
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T BinaryDeepCopy<T>(T t)
        {
            //创建二进制序列化对象
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())//创建内存流
            {
                //将对象序列化到内存中
                bf.Serialize(ms, t);
                ms.Position = default;//将内存流的位置设为0
                return (T)bf.Deserialize(ms);//继续反序列化
            }
        }
    }
}
