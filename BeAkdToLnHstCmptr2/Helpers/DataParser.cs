using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeAkdToLnHstCmptr2.Helpers 
{
    public class DataParser
    {
        // 这个方法专门负责解析温度数据
        // 假设协议是：01 03 02 [高位] [低位] (后面两位是温度值)
        public static int ParseTemperature(byte[] data)
        {
            // 1. 简单判断长度：至少要有5个字节
            if (data == null || data.Length < 5)
            {
                return -1; // 数据不完整，返回-1代表错误
            }

            // 2. 核心位运算：把第4个字节(索引3)左移8位，加上第5个字节(索引4)
            // 比如收到 0x01 0x2A => 十进制的 298
            int high = data[3]; // 高位
            int low = data[4];  // 低位
            int result = (high << 8) + low; // 左移8位相当于乘以256

            return result;
        }
    }
}