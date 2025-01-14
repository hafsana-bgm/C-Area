using System.Reflection.Metadata;
using C_Area.Areas.C_Area.Data;
using C_Area.Areas.C_Area.Models;
using C_Area.Areas.C_Area.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace C_Area.Areas.C_Area.Controllers
{
    [Area("C_Area")]
    [Route("C_Area/[Controller]/[Action]")]
    [Route("C_Area/[Controller]")]
    
    public class ShopsController : Controller
    {
        private readonly C_AreaDbContext _context;

        public ShopsController(C_AreaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ShopIndex()
        {

            {
                ViewBag.LabelList = _context.Label.Select(x => new SelectListItem
                {

                    Value = x.LabelId.ToString(),
                    Text = x.LabelName

                }).ToList();

                return View();
            }   
         
        }
        [HttpPost]
        public async Task<IActionResult>ShopCreate(ProductVM product)
        {
            //file upload start
            string uniqueFileName = null;
            if (product.UploadImage !=null)
            {
               
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images");
                uniqueFileName = Guid.NewGuid().ToString()+"_"+product.UploadImage.FileName;

                string filepath = Path.Combine(uploadsFolder, uniqueFileName);

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                using (var filestrem = new FileStream(filepath,FileMode.Create))
                {
                    await product.UploadImage.CopyToAsync(filestrem);
                }

            }
            //file upload end

            var RealDataModel = new Product();

            RealDataModel.Name = product.Name;
            RealDataModel.Price = product.Price;
            RealDataModel.Description = product.Description;
            RealDataModel.Category = product.Category;
            RealDataModel.LabelId = product.LabelId;
            RealDataModel.Image = uniqueFileName;

            _context.Product.Add(RealDataModel);
            _context.SaveChanges();

            return View("ShopIndex");
        }

        public async Task<IActionResult> ShopList()
        {
           var Data = _context.Product.ToList();

            return View(Data);
        }

        public IActionResult ShopInfo(int? id)
        {

            if (id == null)

                return NotFound();

            var Blog = _context.Product.FirstOrDefault(shop => shop.ProductId == id);

            return View("ShopIndex");
        }

        public async Task<IActionResult> ShopEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> ShopEdit(int id, [Bind("ProductId,Name,Description,Image,Price,LableId,IsActive,Category")] Product product)
        //{
        //    if (id != product.ProductId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExist(product.ProductId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("ShopIndex");
        //    }
        //    return View(product);
        //}


     
        

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Labels()
        {
            var LebelList = _context.Label.ToList();

            return View(LebelList);
        }

        public IActionResult LabelCreate(Label model)
        {
            _context.Label.Add(model);

            try
            {
                _context.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }



        }

        public IActionResult LabelEdit(int? id)
        {
            if (id == null)
                return NotFound();

            var Furnituredata = _context.Label.FirstOrDefault(Furniture => Furniture.LabelId == id);
            return View(Furnituredata);
        }

        [HttpPost]
        public IActionResult LabelEdit(Label Furnituredata)
        {
            if (Furnituredata.LabelName != null )
            {
                _context.Update(Furnituredata);
                _context.SaveChanges();
            }
            return RedirectToAction("Labels");
        }

        public IActionResult LabelDelete(int? id)

        {
            if (id == null)
                return NotFound();

            var Furnituredata = _context.Label.FirstOrDefault(Furniture => Furniture.LabelId == id);

            if (Furnituredata == null)
                return NotFound();

            _context.Remove(Furnituredata);
            _context.SaveChanges();

            return RedirectToAction("Labels");


        }
    }
}
