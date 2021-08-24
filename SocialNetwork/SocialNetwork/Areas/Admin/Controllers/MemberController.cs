using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetwork.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SocialNetwork.Models;

namespace SocialNetwork.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class MemberController : Controller
    {
        public ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController>logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            var model = new MemberListModel();

            return View(model);
        }

        public JsonResult GetMemberData()
        {
            var model = new MemberListModel();

           var dataTables = new DataTablesAjaxRequestModel(Request);

          var data=  model.getmembers(dataTables);

            return Json(data);


        }

        public IActionResult Create()
        {
            var model = new CreateMemberModel();

            return View(model);

        }
        [HttpPost ,ValidateAntiForgeryToken]
        public IActionResult Create(CreateMemberModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.createMember();

                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", " Failed to create New Member");
                    _logger.LogError(ex, "failed to create member");

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

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(EditMemberModel model)
        {
            if(ModelState.IsValid)
            {
                model.updateMember();

            }

            return View(model);

        }

        public IActionResult Delete(int id)
        {
            var model = new MemberListModel();
            model.delete(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
