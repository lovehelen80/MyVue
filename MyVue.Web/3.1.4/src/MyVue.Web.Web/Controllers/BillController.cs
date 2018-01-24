using Abp.Web.Security.AntiForgery;
using MyVue.Web.Bills;
using MyVue.Web.Bills.Dto;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyVue.Web.Web.Controllers
{
    public class BillController : WebControllerBase
    {
        private readonly IBillAppServer _billAppService;

        public BillController(IBillAppServer billAppService)
        {
            _billAppService = billAppService;
        }
        [DisableAbpAntiForgeryTokenValidation]
        public ActionResult GetBillType()
        {
            try
            {
                var result = _billAppService.GetBillType();
                return Json(new { result = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = false, data = e.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [DisableAbpAntiForgeryTokenValidation]
        public ActionResult GetBills(GetBillDto input)
        {
            input.MaxResultCount = 10;
            try
            {
                var result = _billAppService.GetBills(input);
                return Json(new { result = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = false, data = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [DisableAbpAntiForgeryTokenValidation]
        public ActionResult GetCount(GetBillDto input)
        {
            try
            {
                var result = _billAppService.GetCount(input);
                return Json(new { result = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = false, data = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [DisableAbpAntiForgeryTokenValidation]
        public async Task<JsonResult> AddBills(CreateBillDto bill)
        {
            try
            {
                if (string.IsNullOrEmpty(bill.CreatorUser)) bill.CreatorUser = "1";
                await _billAppService.CreatBill(bill);
                return Json(new { result = true, data = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = false, data = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [DisableAbpAntiForgeryTokenValidation]
        public ActionResult GetTotallCount(GetBillDto input)
        {
            try
            {
                var result = _billAppService.GetTotallCount(input);
                return Json(new { result = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = false, data = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [DisableAbpAntiForgeryTokenValidation]
        public async Task<ActionResult> DeleteBill(int key)
        {
            try
            {
                await _billAppService.DeleteBill(key);
                return Json(new { result = true, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = false, data = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}