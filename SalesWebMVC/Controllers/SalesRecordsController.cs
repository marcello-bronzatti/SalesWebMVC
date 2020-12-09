using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? initial, DateTime? final)
        {
            if (!initial.HasValue)
            {
                initial = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!final.HasValue)
            {
                final = DateTime.Now;
            }
            ViewData["initial"] = initial.Value.ToString("yyyy-MM-dd");
            ViewData["final"] = final.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateAsync(initial, final);
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }

    }
}

