using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVue.Web.Bills
{
   public  class BillDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 记账金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// font图标 样式名称
        /// </summary>
        public string FontStyle { get; set; }
    }
}
