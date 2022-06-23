using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bsis3a_webapp.Data;
using bsis3a_webapp.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bsis3a_webapp.Models;
using System.IO;

namespace bsis3a_webapp.Controllers
{
    public class InstrumentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;
        
        [BindProperty]
        public InstrumentViewModel InstrumentVM { get; set; }

        public InstrumentController(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;

            InstrumentVM = new InstrumentViewModel()
            {
                Items = _db.Items.ToList(),
                Types = _db.Types.ToList(),
                Instrument = new Models.Instrument()
            };
        }

        [HttpGet]
        public IActionResult Index()
        {
            var instrument = _db.Instruments.Include(m => m.Item).Include(m => m.Type);
            return View(instrument);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(InstrumentVM);
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult CreatePost()
        {
            if(ModelState.IsValid)
            {
                _db.Instruments.Add(InstrumentVM.Instrument); 
                
                _db.SaveChanges();

                

                SaveImage();
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(InstrumentVM);
        }
     public void SaveImage()
        {
                var InstrumentId = InstrumentVM.Instrument.Id;

                string wwwrootPath = _hostingEnvironment.WebRootPath;

                var files = HttpContext.Request.Form.Files;

                var saveInstrument = _db.Instruments.Find(InstrumentId);

                if(files.Count != 0)
                {
                    var ImagePath = @"Images\Instrument\";
                    var Extension = Path.GetExtension(files[0].FileName);
                    var RelativeImagePath = ImagePath + InstrumentId + Extension;
                    var AbsImagePath = Path.Combine(wwwrootPath, RelativeImagePath);

                    using (var fileStream = new FileStream(AbsImagePath, FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    saveInstrument.ImagePath = RelativeImagePath;
                }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            InstrumentVM.Instrument = _db.Instruments.Include(m => m.Item).Include(m => m.Type).SingleOrDefault(m => m.Id == id);
            if(InstrumentVM.Instrument== null)
            {
                return NotFound();
            }
            return View(InstrumentVM);
       }
       
         [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditPost()
       {
            if(ModelState.IsValid)
            {
                _db.Instruments.Update(InstrumentVM.Instrument);
                
               SaveImage();
               _db.SaveChanges();
               return RedirectToAction("Index");
            }
            return View(InstrumentVM);
       }
 
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var instrument = _db.Instruments.Find(id);
            if(instrument == null)
            {
                return NotFound();
            }
            _db.Instruments.Remove(instrument);
            _db.SaveChanges();
            return RedirectToAction("Index");
         } 
    } 
}