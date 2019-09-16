using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Model;
using Web.DBHelper;

namespace Share.Admin.Controllers
{
    public class BaseController : Controller
    {
        //默认密钥向量
        private static byte[] _key1 = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// AES加密算法
        /// </summary>
        /// <param name="plainText">明文字符串</param>
        /// <param name="strKey">密钥</param>
        /// <returns>返回加密后的密文字节数组</returns>
        public static byte[] AESEncrypt(string plainText)//, string strKey
        {
            //分组加密算法
            SymmetricAlgorithm des = Rijndael.Create();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(plainText);//得到需要加密的字节数组
            //设置密钥及密钥向量
            des.Key = Encoding.UTF8.GetBytes("dongbinhuiasxiny");
            des.IV = _key1;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            byte[] cipherBytes = ms.ToArray();//得到加密后的字节数组
            cs.Close();
            ms.Close();
            return cipherBytes;
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="cipherText">密文字节数组</param>
        /// <param name="strKey">密钥</param>
        /// <returns>返回解密后的字符串</returns>
        public static byte[] AESDecrypt(byte[] cipherText)
        {
            SymmetricAlgorithm des = Rijndael.Create();
            des.Key = Encoding.UTF8.GetBytes("dongbinhuiasxiny");
            des.IV = _key1;
            byte[] decryptBytes = new byte[cipherText.Length];
            MemoryStream ms = new MemoryStream(cipherText);
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read);
            cs.Read(decryptBytes, 0, decryptBytes.Length);
            cs.Close();
            ms.Close();
            return decryptBytes;
        }

        /// <summary>
        /// 获取后台管理员信息
        /// </summary>
        /// <returns></returns>
        public static Manager GetAdminInfo()
        {
            if (IsLogin())
            {
                Manager adminModel = CacheHelper.Get<Manager>("admin");
                if (adminModel.Id > 0)
                {
                    return adminModel;
                }
            }
            return null;
        }
        public int Id { get
            {
                if (IsLogin())
                {
                    Manager adminModel = CacheHelper.Get<Manager>("admin");
                    if (adminModel.Id > 0)
                    {
                        return adminModel.Id;
                    }
                }
                return 0;
            }  }
        /// <summary>
        /// 判断管理员是否登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            Manager adminModel = CacheHelper.Get<Manager>("admin");
            if (adminModel!=null&& adminModel.Id>0)
            {
                return true;
            }
            return false;
        }
        //权限检查

        /// <summary>
        /// @ming记录操作日志
        /// </summary>
        /// <param name="action_type">操作类型</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public static bool AddManagerLog(string action_type, string remark)
        {
            //获取当前登录管理员信息
            Manager managerMode = GetAdminInfo();
            if (managerMode != null)
            {
                ManagerLog log = new ManagerLog()
                {
                    Name = managerMode.Name,
                    UserId = managerMode.UserId,
                    ActionType = action_type,
                    UserIp = "127.0.0.1",
                    AddTime = DateTime.Now,
                    Remark = remark
                };
                if (SqlDapperHelper.Insert(log) > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
