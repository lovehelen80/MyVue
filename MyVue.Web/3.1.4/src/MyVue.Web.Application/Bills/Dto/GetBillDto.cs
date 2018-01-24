using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyVue.Web.Bills.Dto
{
    public class GetBillDto : IPagedResultRequest, ISortedResultRequest
    {
        [Range(0, 1000)]
        public int MaxResultCount { get; set; }

        public int SkipCount { get; set; }

        public string Sorting { get; set; }

        public DateTime? Date { get; set; }
        public string User { get; set; }
        /// <summary>
        /// 数据类型，0 按年，1按月,
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 分组依据 0，消费类型，1 月
        /// </summary>
        public int GroupBy { get; set; }

    }
}
