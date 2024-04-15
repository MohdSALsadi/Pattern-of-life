using Microsoft.AspNetCore.Mvc;
using Pattern_of_life.Models;
using Pattern_of_life.Repository;
using Pattern_of_life.Repository.Interface;
using Pattern_of_life.Services;
using System.Diagnostics;

namespace Pattern_of_life.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<ShipActivity> _repository;
        private readonly ShipActivityDensityCalculator _densityCalculator;
        private readonly SettingsRepository _settingsRepository;


        public HomeController(IRepository<ShipActivity> repository, ShipActivityDensityCalculator densityCalculator, SettingsRepository settingsRepository)
        {
            _repository = repository;
            _densityCalculator = densityCalculator;
            _settingsRepository = settingsRepository;

        }
        public async Task<IActionResult> Index()
        {
            var shipActivities = await _repository.GetAll();// استرجاع بيانات الأنشطة من قاعدة البيانات
            var densityMap = _densityCalculator.CalculateDensity(shipActivities, _settingsRepository.GetDistanceThreshold());// استخدام الدالة لحساب كثافة النقاط
            return View(densityMap); // إرسال البيانات إلى الصفحة للعرض
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // Add action to calculate density and pass data to view
        //public async Task<IActionResult> CalculateDensity()
        //{
        //    var shipActivities = await _repository.GetAll(); 
        //    var densityMap = _densityCalculator.CalculateDensity(shipActivities, _settingsRepository.GetDistanceThreshold()); 
        //    return View(densityMap);
        //}

    }
}