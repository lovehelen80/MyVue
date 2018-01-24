using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyVue.Web.Bills.Dto
{
    [AutoMapTo(typeof(Bill))]
    public class CreateBillDto
    {
        /// <summary>
        /// 创建者
        /// </summary>
        public string CreatorUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 记账类型
        /// </summary>
        [Required]
        public int BillTypeId { get; set; }
        /// <summary>
        /// 记账金额
        /// </summary>
        [Required]
        public decimal Money { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; }

        public CreateBillDto()
        {
            this.CreationTime = DateTime.Now;
        }
    }
}
