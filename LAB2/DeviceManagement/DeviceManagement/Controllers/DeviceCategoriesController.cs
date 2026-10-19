
using DeviceManagement.Data;
using DeviceManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Controllers
{
    public class DeviceCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display category list
        public async Task<IActionResult> Index()
        {
            var categories = await _context.DeviceCategories.AsNoTracking().ToListAsync(); 
            return View(categories);
        }

        // Display create form
        public IActionResult Create()
        {
            return View();
        }

        // Save new category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeviceCategory category)
        {
            if (ModelState.IsValid)
            {
                _context.DeviceCategories.Add(category);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // Display edit form
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.DeviceCategories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // Save edited category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DeviceCategory category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.DeviceCategories.Update(category);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // Delete category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.DeviceCategories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            // Prevent deleting a category that is being used by devices
            bool hasDevices = await _context.Devices
                .AnyAsync(d => d.DeviceCategoryId == id);

            if (hasDevices)
            {
                TempData["Error"] = "Cannot delete a category that is being used by devices.";
                return RedirectToAction(nameof(Index));
            }

            _context.DeviceCategories.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}


/*Tại sao cần tạo Controller?
- DeviceCategoriesController: tiếp nhận yêu cầu từ người dùng.
- DeviceCategory: Model chứa dữ liệu danh mục thiết bị.
- View: giao diện hiển thị cho người dùng.*/
