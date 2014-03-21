using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ORBITA.Common
{
    /// <summary>
    /// Common类通用方法
    /// </summary>
    public static class BaseCommon
    {
        /// <summary>
        /// 判断这符串是否为整数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>返回<c>true</c>是正整数，或<c>false</c>非正整数.</returns>
        public static bool IsInt(string str)
        {
            Regex regex = new Regex("^[0-9]*[1-9][0-9]*$");
            return regex.IsMatch(str.Trim());
        }

        public static bool ValidQueryString(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length > 9 || !IsInt(str))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
