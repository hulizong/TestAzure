using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;
using Web.Common;
using Web.Common.LogHelper;

namespace Web.RedisHelper
{
    public class RedisHelp
    {
        private ConnectionMultiplexer redis { get; set; }
        private IDatabase db { get; set; }
        public RedisHelp(string connection)
        {
            redis = ConnectionMultiplexer.Connect(connection);//AppConfigurtaionServices.connectionStrings.Redis); 
        }

        #region Key(String)
        /// <summary>
        /// 增加/修改string  字符串类型
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetValue(string key, string value,int timeSpan=0,int indexDb = 0)
        {
            var db = redis.GetDatabase(indexDb);
            //var a = TimeSpan.Parse(timeSpan.ToString());
            var result= db.StringSet(key, value);
            if (timeSpan>0)
            {
                db.KeyExpire(key, DateTime.Now.AddSeconds(timeSpan));
            }
            return result;
        }

        /// <summary>
        /// 增加/修改   单个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeSpan"></param>
        /// <param name="indexDb"></param>
        /// <returns></returns>
        public bool SetT<T>(string key, T value, int timeSpan = 0, int indexDb = 0)
        {
            var db = redis.GetDatabase(indexDb);
            //var a = TimeSpan.Parse(timeSpan.ToString());
            var item = JsonConvert.SerializeObject(value);
            var result = db.StringSet(key, item);
            if (timeSpan > 0)
            {
                db.KeyExpire(key, DateTime.Now.AddSeconds(timeSpan));
            }
            return result;
        }

        /// <summary>
        ///  查询  字符串类型
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key, int indexDb = 0)
        {
            var db = redis.GetDatabase(indexDb);
            return db.StringGet(key);
        }

        /// <summary>
        /// 查询  单个值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="indexDb"></param>
        /// <returns></returns>
        public T GetT<T>(string key, int indexDb = 0)
        {
            try
            {
                var db = redis.GetDatabase(indexDb);
                RedisValue result= db.StringGet(key);
                if (string.IsNullOrWhiteSpace(result))
                {
                    return default(T);
                }
                return JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception ex)
            {
                LogHelp.Error(ex);
                return default(T);
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DeleteKey(string key, int indexDb = 0)
        {
            var db = redis.GetDatabase(indexDb);
            return db.KeyDelete(key); 
        }

        /// <summary>
        /// 键是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <param name="indexDb"></param>
        /// <returns></returns>
        public bool KeyExist(string key,int indexDb=0)
        {
            var db = redis.GetDatabase(indexDb);
            var result = db.KeyExists(key);
            return result;
        }
        /// <summary>
        /// 修改键名字
        /// </summary>
        /// <param name="oldKey"></param>
        /// <param name="key"></param>
        /// <param name="indexDb"></param>
        /// <returns></returns>
        public bool RmName(string oldKey,string key, int indexDb = 0)
        {
            var db = redis.GetDatabase(indexDb);
            var result = db.KeyRename(oldKey,key);
            return result; 
        }

        /// <summary>
        /// 自增  double类型
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="indexDb"></param>
        /// <returns></returns>
        public double Increment(string key,double value, int indexDb = 0,int timeSpan=0)
        {
            var db = redis.GetDatabase(indexDb);
            var result = db.StringIncrement(key, value);
            if (timeSpan > 0)
            {
                db.KeyExpire(key, DateTime.Now.AddSeconds(timeSpan));
            }
            return result;
        }

        /// <summary>
        /// 在键的值得末尾增加value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="indexDb"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public long Append(string key, string value, int indexDb = 0, int timeSpan = 0)
        {
            var db = redis.GetDatabase(indexDb);
            var result = db.StringAppend(key, value);
            if (timeSpan > 0)
            {
                db.KeyExpire(key, DateTime.Now.AddSeconds(timeSpan));
            }
            return result;
        }
        #endregion

        #region   Hash数据结构
        /// <summary>
        /// 哈希写入字符串
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="timeSpan"></param>
        /// <param name="indexDb"></param>
        public void HashSetString(string key, string field, string value, int timeSpan = 0, int indexDb = 0)
        {
            var db = redis.GetDatabase(indexDb);

            db.HashSet(key, field, value);
            if (timeSpan>0)
            {
                db.KeyExpire(key,DateTime.Now.AddSeconds(timeSpan));
            }
        }

        /// <summary>
        /// 哈希写入集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="items"></param>
        /// <param name="getId"></param>
        /// <param name="timeSpan"></param>
        /// <param name="indexDb"></param>
        public void HashSet<T>(string key, List<T> items,  Func<T, string> getId, int timeSpan = 0, int indexDb = 0)
        {
            var db = redis.GetDatabase(indexDb);
            List<HashEntry> list = new List<HashEntry>(); 
            foreach (var item in items)
            {
                var json = JsonConvert.SerializeObject(item);
                list.Add(new HashEntry(getId(item), json));
            }
            db.HashSet(key, list.ToArray());
            if (timeSpan > 0)
            {
                db.KeyExpire(key, DateTime.Now.AddSeconds(timeSpan));
            }
        }

        /// <summary>
        /// 获取哈希值（单个字符串类型）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="indexDb"></param>
        /// <returns></returns>
        public string HashGetString(string key, string field, int indexDb = 0)
        {
            var db = redis.GetDatabase(indexDb);
            if (!string.IsNullOrWhiteSpace(key)&&!string.IsNullOrWhiteSpace(field))
            {
                RedisValue result = db.HashGet(key, field);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    return result;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取哈希集合中单个值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="indexDb"></param>
        /// <returns></returns>
        public T HashGetT<T>(string key, string field, int indexDb = 0)
        {
            var db = redis.GetDatabase(indexDb);
            if (!string.IsNullOrWhiteSpace(key)&&!string.IsNullOrWhiteSpace(field))
            {
                RedisValue result = db.HashGet(key, field);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
            return default (T);
        }
        /// <summary>
        /// 获取哈希集合中多个值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <param name="indexDb"></param>
        /// <returns></returns>
        public List<T> HashGetTs<T>(string key, List<RedisValue> fields, int indexDb = 0)
        {
            var db = redis.GetDatabase(indexDb);
            List<T> list = new List<T>();
            if (!string.IsNullOrWhiteSpace(key) && fields.Count()>0)
            {
                RedisValue[] result = db.HashGet(key, fields.ToArray());
                foreach (var item in result)
                {
                    list.Add(JsonConvert.DeserializeObject<T>(item));
                }
            }
            return list;
        }

        /// <summary>
        /// 删除哈希
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="indexDb"></param>
        /// <returns></returns>
        public bool DeleteHash(string key, string field, int indexDb = 0)
        {
            var db = redis.GetDatabase(indexDb);

            return db.HashDelete(key,field);
        }
        #endregion

       
    }
}
