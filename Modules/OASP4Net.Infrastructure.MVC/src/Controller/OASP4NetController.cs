﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OASP4Net.Infrastructure.MVC.Dto;
using System.Collections.Generic;

namespace OASP4Net.Infrastructure.MVC.Controller
{
    public class OASP4NetController: Microsoft.AspNetCore.Mvc.Controller, IOASP4NetController
    {
        protected IMapper Mapper { get; set; }
        protected ILogger Logger;
        private const int PageNumber = 1;
        private const int PageSize = 500;


        public OASP4NetController(ILogger logger)
        {
            Logger = logger;
        }

        public OASP4NetController(ILogger logger, IMapper mapper)  
        {
            Logger = logger;
            Mapper = mapper;
        }

        public ResultObjectDto<T> GenerateResultDto<T>(int? page = null,int? size = null, int? total = null)
        {
            return new ResultObjectDto<T> { Pagination = { Page = page!=null? page.Value : PageNumber,
                    Size = size!=null? size.Value : PageSize, Total = total }} ;
        }
        public ResultObjectDto<T> GenerateResultDto<T>(List<T> result, int? page = null, int? size = null)
        {
            return new ResultObjectDto<T>
            {
                Pagination = { Page = page!=null? page.Value : PageNumber,
                    Size = size!=null? size.Value : PageSize, Total = result?.Count ?? 0 },
                Result = result               
            };

        }

        public string GetJsonFromObject(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
