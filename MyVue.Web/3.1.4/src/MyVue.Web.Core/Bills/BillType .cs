using Abp.Domain.Entities;

namespace MyVue.Web.Bills
{
    /// <summary>
    /// 记账类型
    /// </summary>
    public class BillType : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// font图标 样式名称
        /// </summary>
        public string FontStyle { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 是否是收入
        /// </summary>
        public bool IsCountIn { get; set; }
    }
}
