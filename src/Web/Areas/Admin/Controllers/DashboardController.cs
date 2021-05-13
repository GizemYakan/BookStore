using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class DashboardController : Controller
    {
        private readonly IOrderViewModelService _orderViewModelService;

        public DashboardController(IOrderViewModelService orderViewModelService)
        {
            _orderViewModelService = orderViewModelService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _orderViewModelService.ListOrderAllAsync());
        }
    }
}