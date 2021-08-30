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
    public class PhotoController : Controller
    {
        private readonly ILogger<PhotoController> _logger;
        public PhotoController(ILogger<PhotoController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetPhotos()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new PhotoListModel();
            var data = model.GetPhotos(dataTablesModel);
            return Json(data);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new DeletePhotoModel();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add()
        {
            var model = new AddPhotoModel();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(AddPhotoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddPhoto();
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
            var model = new EditPhotoModel();
            model.LoadModelData(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditPhotoModel model)
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
    }
}
