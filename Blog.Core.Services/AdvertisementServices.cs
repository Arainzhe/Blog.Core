using Blog.Core.IServices;
using Blog.Core.Repository;
using Blog.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Services
{
    public class AdvertisementServices : IAdvertisementServices
    {
        IAdvertisementRepository dal = new AdvertisementRepository();
        public int Sum(int i, int j)
        {
            return dal.Sum(i, j);
        }
    }
}
