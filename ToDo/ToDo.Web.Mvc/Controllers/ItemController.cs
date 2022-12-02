using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Dtos.Item;
using ToDo.Application.Interfaces;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;
using ToDo.Web.Mvc.Models;

namespace ToDo.Web.Mvc.Controllers
{
    public class ItemController : Controller
    {
        protected IItemAppService itemAppService;

        public ItemController(IItemAppService itemAppService)
        {
            this.itemAppService = itemAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await itemAppService.GetAllAsync();

            return View(items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemRequestDto createItemRequestDto)
        {
            if (ModelState.IsValid)
            {
                await itemAppService.AddAsync(createItemRequestDto);
                return RedirectToAction(nameof(Index));
            }

            return View(createItemRequestDto);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid Id)
        {
            var itemResponseDto = await itemAppService.GetAsync(Id);
            return View(itemResponseDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateItemRequestDto updateItemRequestDto)
        {
            if (ModelState.IsValid)
            {
                await itemAppService.UpdateAsync(updateItemRequestDto);
                return RedirectToAction(nameof(Index));
            }

            return View(updateItemRequestDto);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            await itemAppService.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
