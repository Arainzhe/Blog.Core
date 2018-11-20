using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Blog.Core.Repository.sugar
{
    public class BaseDBConfig
    {
        public static string ConnectionString = File.ReadAllLines(@"I:\Myproject\NotCore\Blog.Core.Repository\Db.txt").ToString().Trim();
    }
}
