using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EvacuateMe.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using EvacuateMe.BLL.DTO;
using AutoMapper;
using EvacuateMe.DAL.Entities;
using EvacuateMe.ViewModels;

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
            var companies = await companyService.GetCompaniesAsync();
            var result = new List<CompanyVM>();

            foreach (var company in companies)
            {
                var companyVM = Mapper.Map<Company, CompanyVM>(company);
                companyVM.Rate = company.CountRate == 0 ? 0 : (double)company.SumRate / company.CountRate;
                result.Add(companyVM);
            }
            
            return View(result);
        }

        [HttpGet, Route("companies/add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add()
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

            await companyService.AddCommpanyAsync(company);

            return RedirectToAction("Index", "Home");
        }
    }
}