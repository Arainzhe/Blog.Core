using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Repository.sugar
{
    public class DbContext
    {
        private static string _connectionString;
        private static DbType _dbType;
        private SqlSugar.SqlSugarClient _db;

        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public static DbType dbType
        {
            get { return _dbType; }
            set { _dbType = value; }
        }
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public SqlSugar.SqlSugarClient Db
        {
            get { return _db; }
            set { _db=value; }
        }
        public static DbContext Context
        {
            get { return new DbContext(); }
        }
        /// <summary>
        /// 功能函数：构造函数
        /// </summary>
        private DbContext()
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new ArgumentNullException("数据库连接字符串为空");
            _db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = _connectionString,
                DbType = _dbType,
                IsAutoCloseConnection = true,
                IsShardSameThread = true,
                ConfigureExternalServices = new ConfigureExternalServices()
                {
                    //DataInfoCacheService = new HttpRuntimeCache()
                },
                MoreSettings = new ConnMoreSettings()
                {
                    IsAutoRemoveDataCache = true
                },
            });
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="blnIsAutoCloseConnection">是否自动关闭连接</param>
        private DbContext(bool blnIsAutoCloseConnection)
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new ArgumentNullException("数据库连接字符串为空");
            _db = new SqlSugarClient(new ConnectionConfig()
            {
               ConnectionString = _connectionString,
               DbType=_dbType,
               IsAutoCloseConnection=blnIsAutoCloseConnection,
               IsShardSameThread=true,
               ConfigureExternalServices=new ConfigureExternalServices()
               {
                   //DataInfoCacheService = new HttpRuntimeCache()
               },
               MoreSettings=new ConnMoreSettings()
               {
                   IsAutoRemoveDataCache=true,
               }
            });
        }

        #region 实例方法
        /// <summary>
        /// 功能描述：获取数据库处理对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public SimpleClient<T> GetEntityDB<T>() where T : class,new()
        {
            return new SimpleClient<T>(_db);
        }
        #endregion

        #region 获取数据库处理对象
        /// <summary>
        /// 获取数据库处理对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <returns></returns>
        public SimpleClient<T> GetEntityDB<T>(SqlSugarClient db) where T : class, new()
        {
            return new SimpleClient<T>(db);
        }
        #endregion
    }
}
