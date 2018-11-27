using System;
using System.Collections.Generic;
using System.Text;

namespace FastSchool.Common
{
    public class RandomNumber
    {
        private static Random Random { get; }
        static RandomNumber()
        {
            Random = new Random(Guid.NewGuid().GetHashCode());
        }

        /// <summary>
        /// 随机数产生
        /// </summary>
        /// <param name="forNumber">最大传入11</param>
        /// <returns></returns>
        public static int GetRandomNumber(int forNumber = 1)
        {
            string result = default;
            if (forNumber > 11)
                return default;

            for (int i = 0; i < forNumber; i++)
            {
                result += Random.Next(0, 10);
            }
            return int.Parse(result);
        }
    }
}
