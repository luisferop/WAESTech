﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAES.Domain.Entities;
using WAES.Domain.Interfaces.Repositories;
using WAES.Domain.Interfaces.Services;

namespace WAES.Domain.Services
{
    public class WAESImageService : ServiceBase<WAESImage>, IWAESImageService
    {
        private readonly IWAESImageRepository _waesImageRepository;
       
        public WAESImageService(IRepositoryBase<WAESImage> repository,
                                IWAESImageRepository waesImageRepository) : base(repository)
        {
            _waesImageRepository = waesImageRepository;
        }

        public IEnumerable<WAESImage> GetAllBySenderId(int idCompare)
        {
            throw new NotImplementedException();
        }

        public WAESImage GetBySenderIdAndSide(int idCompare, int side)
        {
            return _waesImageRepository.Find(x => x.IdCompare.Equals(idCompare) && x.Side.Equals(side)).FirstOrDefault();
        }
    }
}
