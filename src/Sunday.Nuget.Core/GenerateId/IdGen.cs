using System;
using Sunday.Nuget.Core.GenerateId;

namespace Sunday.Nuget.Core.GenerateId
{
    /// <summary>
    /// 静态调用方法，获取Id
    /// </summary>
    public class IdGen
    {
        /// <summary>
        /// 返回生成的24位长度Id
        /// </summary>
        /// <returns>返回生成的24位长度Id</returns>
        public static string GenerateNewId()
        {
            return ObjectId.GenerateNewId().ToString();
        }

        /// <summary>
        /// 返回生成的24位长度Id
        /// </summary>
        /// <param name="timestamp">时间戳，当前时间</param>
        /// <returns>返回生成的24位长度Id</returns>
        public static string GenerateNewId(DateTime timestamp)
        {
            return ObjectId.GenerateNewId(timestamp).ToString();
        }

        /// <summary>
        /// 返回生成的24位长度Id
        /// </summary>
        /// <param name="timestamp">时间戳，1970年到现在秒数</param>
        /// <returns>返回生成的24位长度Id</returns>
        public static string GenerateNewId(int timestamp)
        {
            return ObjectId.GenerateNewId(timestamp).ToString();
        }

        /// <summary>
        /// 返回 18-19位 长度的数字
        /// </summary>
        /// <param name="workerId">机器编号 0-255</param>
        /// <returns>返回 18-19位 长度的数字</returns>
        public static long GenerateNewLongId(int workerId)
        {
            return new SnowFlake(workerId).NextId();
        }
    }
}