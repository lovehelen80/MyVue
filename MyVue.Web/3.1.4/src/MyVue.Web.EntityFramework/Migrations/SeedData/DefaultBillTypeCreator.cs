using MyVue.Web.Bills;
using MyVue.Web.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace MyVue.Web.Migrations.SeedData
{
    /// <summary>
    /// 初始化数据库中 billType数据
    /// </summary>
    public class DefaultBillTypeCreator
    {
        private readonly WebDbContext _context;
        public DefaultBillTypeCreator(WebDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateBillTypes();
        }

        private void CreateBillTypes()
        {
            List<BillType> list = new List<BillType> {
                new BillType { IsCountIn= false, Name = "食物",FontStyle="fa-cutlery"},
                new BillType { IsCountIn= false, Name = "衣物",FontStyle="fa-columns"},
                new BillType { IsCountIn= false, Name = "生活日用",FontStyle="fa-umbrella"},
                new BillType { IsCountIn= false, Name = "交通出行",FontStyle="fa-car"},
                new BillType { IsCountIn= false, Name = "旅游",FontStyle="fa-fighter-jet"},
                new BillType { IsCountIn= false, Name = "节日礼物",FontStyle="fa-gift"},
                new BillType { IsCountIn= false, Name = "聚会聚餐",FontStyle="fa-users"},
                new BillType { IsCountIn= false, Name = "医疗健康",FontStyle="fa-plus-square"},
                new BillType { IsCountIn= false, Name = "宠物",FontStyle="fa-github-alt"},
                new BillType { IsCountIn= false, Name = "书籍资料",FontStyle="fa-file-excel-o"},
                new BillType { IsCountIn= false, Name = "工具",FontStyle="fa-wrench"},
                new BillType { IsCountIn= false, Name = "运动",FontStyle="fa-frown-o"},
                new BillType { IsCountIn= false, Name = "培训学习",FontStyle="fa-pied-piper-alt"},
                new BillType { IsCountIn= false, Name = "孩子",FontStyle="fa-child"},
                new BillType { IsCountIn= false, Name = "住房居家",FontStyle="fa-home"},
                new BillType { IsCountIn= false, Name = "电影演出",FontStyle="fa-film"},
                new BillType { IsCountIn= false, Name = "休闲娱乐",FontStyle="fa-coffee"},
                new BillType { IsCountIn= false, Name = "红包分子",FontStyle="fa-bomb"},
                new BillType { IsCountIn= false, Name = "借款",FontStyle="fa-skype"},
                new BillType { IsCountIn= false, Name = "其他",FontStyle="fa-globe"},
            };
            foreach (var billType in list)
            {
                AddBillTypesIfNotExists(billType);
            }


        }
        private void AddBillTypesIfNotExists(BillType billType)
        {
            if (_context.BillTypes.Any(l => l.Name == billType.Name))
            {
                return;
            }

            _context.BillTypes.Add(billType);

            _context.SaveChanges();
        }
    }
}