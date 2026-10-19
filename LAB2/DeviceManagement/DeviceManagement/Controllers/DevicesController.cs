using DeviceManagement.Data;
using DeviceManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Controllers
{
    public class DevicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            string searchString, DeviceStatus? status, int? categoryId)
        {
            var devices = _context.Devices
                .AsNoTracking()
                .Include(d => d.DeviceCategory)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                devices = devices.Where(d =>
                    d.Name.Contains(searchString) ||
                    d.Code.Contains(searchString));
            }

            if (status.HasValue)
            {
                devices = devices.Where(d => d.Status == status.Value);
            }

            if (categoryId.HasValue)
            {
                devices = devices.Where(d => d.DeviceCategoryId == categoryId.Value);
            }

            ViewBag.SearchString = searchString;
            ViewBag.Status = new SelectList(Enum.GetValues<DeviceStatus>(), status);
            ViewBag.Categories = await GetCategorySelectListAsync(categoryId);

            return View(await devices.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.DeviceCategoryId = await GetCategorySelectListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Device device)
        {
            await ValidateCategoryAsync(device);

            if (ModelState.IsValid)
            {
                _context.Devices.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DeviceCategoryId = await GetCategorySelectListAsync(device.DeviceCategoryId);
            return View(device);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            ViewBag.DeviceCategoryId = await GetCategorySelectListAsync(device.DeviceCategoryId);
            return View(device);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Device device)
        {
            if (id != device.Id)
            {
                return NotFound();
            }

            await ValidateCategoryAsync(device);

            if (ModelState.IsValid)
            {
                _context.Devices.Update(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DeviceCategoryId = await GetCategorySelectListAsync(device.DeviceCategoryId);
            return View(device);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<SelectList> GetCategorySelectListAsync(int? selectedId = null)
        {
            var categories = await _context.DeviceCategories
                .AsNoTracking()
                .ToListAsync();

            return new SelectList(
                categories,
                nameof(DeviceCategory.Id),
                nameof(DeviceCategory.Name),
                selectedId);
        }

        private async Task ValidateCategoryAsync(Device device)
        {
            bool exists = await _context.DeviceCategories
                .AnyAsync(c => c.Id == device.DeviceCategoryId);

            if (!exists)
            {
                ModelState.AddModelError(
                    nameof(Device.DeviceCategoryId),
                    "Please select a valid category.");
            }
        }
    }
}