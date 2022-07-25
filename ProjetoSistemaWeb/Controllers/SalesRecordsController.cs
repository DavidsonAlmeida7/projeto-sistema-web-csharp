using Microsoft.AspNetCore.Mvc;
using ProjetoSistemaWeb.Services;

namespace ProjetoSistemaWeb.Controllers
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

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(2019, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = new DateTime(2021, 1, 1);
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
