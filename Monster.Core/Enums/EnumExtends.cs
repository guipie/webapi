using Monster.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Monster.Core.Enums
{
    public class EnumRemarkAttribute : Attribute
    {
        public EnumRemarkAttribute(string remark, string remarkExtends = "")
        {
            Remark = remark;
            RemarkExtends = remarkExtends;
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        public string RemarkExtends { get; set; }
    }
    /// <summary>
    /// 枚举扩展类
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举的备注信息
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static string GetRemark(this Enum em)
        {
            Type type = em.GetType();
            FieldInfo fd = type.GetField(em.ToString());
            if (fd == null)
                return string.Empty;
            object[] attrs = fd.GetCustomAttributes(typeof(EnumRemarkAttribute), false);
            string name = string.Empty;
            foreach (EnumRemarkAttribute attr in attrs)
            {
                name = attr.Remark;
            }
            return name;
        }
        public static string GetRemarkExtends(this Enum em)
        {
            Type type = em.GetType();
            FieldInfo fd = type.GetField(em.ToString());
            if (fd == null)
                return string.Empty;
            object[] attrs = fd.GetCustomAttributes(typeof(EnumRemarkAttribute), false);
            string name = string.Empty;
            foreach (EnumRemarkAttribute attr in attrs)
            {
                name = attr.RemarkExtends;
            }
            return name;
        }
        /// <summary>
        /// 获取枚举对应的值
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="enumName">枚举对应值的名</param>
        /// <returns>枚举对象对应的值</returns>
        public static int GetEnumValue<T>(this object enumName)
        {

            return (int)enumName.GetEnumObj<T>();
        }
        /// <summary>
        /// 获取枚举对象
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="enumName">枚举对应值的名</param>
        /// <returns>枚举对象</returns>
        private static object GetEnumObj<T>(this object enumName)
        {
            string enumNameValue = enumName.ToString();
            return (T)Enum.Parse(typeof(T), enumNameValue);
        }
    }
}
