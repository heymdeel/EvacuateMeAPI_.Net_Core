using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EvacuateMe.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using EvacuateMe.BLL.DTO.CompanyDTO;

namespace EvacuateMe.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        // GET: companies
        [HttpGet, Route("companies")]
        public async Task<IActionResult> Index()
        {
            var companies = companyService.GetCompanies();

            return await Task.Run(() =>
            {
                return View(companies);
            });
        }

        [HttpGet, Route("companies/add")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CompanyRegisterDTO company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            companyService.AddCommpany(company);

            return RedirectToAction("Index", "Home");
        }
    }
}