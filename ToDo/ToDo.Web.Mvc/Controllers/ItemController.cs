using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;
using ToDo.Web.Mvc.Extensions;
using ToDo.Web.Mvc.Models;

namespace ToDo.Web.Mvc.Controllers
{
    public class ItemController : Controller
    {
        protected IItemRepository repository;

        public ItemController(IItemRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await repository.GetAllAsync();

            return View(items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemModel createItemModel)
        {
            if (ModelState.IsValid)
            {
                await repository.AddAsync(createItemModel.ConvertToItem());
                return RedirectToAction(nameof(Index));
            }

            return View(createItemModel);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid Id)
        {
            Item item = await repository.getAsync(Id);
            return View(item.ConvertToUpdateItemModel());
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateItemModel updateItemModel)
        {
            if (ModelState.IsValid)
            {
                await repository.UpdateAsync(updateItemModel.ConvertToItem());
                return RedirectToAction(nameof(Index));
            }

            return View(updateItemModel);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            await repository.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
