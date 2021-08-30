using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetwork.Web.Areas.Admin.Models;
using SocialNetwork.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;
        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetMembers()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new MemberListModel();
            var data = model.GetMembers(dataTablesModel);
            return Json(data);
        }
        public IActionResult Create()
        {
            var model = new AddMemberModel();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(AddMemberModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddMember();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    _logger.LogError(ex, "Add member failed");
                }
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = new EditMemberModel();
            model.LoadModelData(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditMemberModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    _logger.LogError(ex, "Edit member failed");
                }

            }
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new DeleteMemberModel();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
