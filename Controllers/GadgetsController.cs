using System.Linq;
using System.Threading.Tasks;
using Crud_tuto2.Data;
using Crud_tuto2.Models;
using Crud_tuto2.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_tuto2.Controllers
{
    public class GadgetsController: Controller
    {
        private readonly TutoDBContext _tutoDBContext;
        public GadgetsController(TutoDBContext tutoDBContext)
        {
             _tutoDBContext = tutoDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allGadgets = await _tutoDBContext.Gadgets.OrderByDescending(_ => _.Id).ToListAsync();
            var model = new GadgetsContainerVm
            {
                AllGadgets = allGadgets
            };
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gadgets model)
        {
            _tutoDBContext.Gadgets.Add(model);
            await _tutoDBContext.SaveChangesAsync();
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var gadget = await _tutoDBContext.Gadgets.Where(_ => _.Id == id).FirstOrDefaultAsync();

            if(gadget == null)
            {
                return NotFound();
            }
            return View("Edit", gadget);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (Gadgets modelToUpdate)
        {
            _tutoDBContext.Update(modelToUpdate);
            await _tutoDBContext.SaveChangesAsync();
            return RedirectToAction("All");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var gadgetToDelete = await _tutoDBContext.Gadgets.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if(gadgetToDelete != null)
            {
                _tutoDBContext.Gadgets.Remove(gadgetToDelete);
                await _tutoDBContext.SaveChangesAsync();
            }
            return RedirectToAction("All");

        }
        
    }
}