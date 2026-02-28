using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FlightSearchEngine.Data;
using FlightSearchEngine.Models;


namespace FlightSearchEngine.Controllers
{
    public class FlightController : Controller
    {
        private readonly DatabaseHelper _db;

        public FlightController(IConfiguration configuration)
        {
            _db = new DatabaseHelper(configuration);
        }

        public async Task<IActionResult> Index()
        {
                SearchViewModel model = new SearchViewModel();

                var sources = await _db.GetSourcesAsync();
                var destinations = await _db.GetDestinationsAsync();

                model.SourceList = new SelectList(sources);
                model.DestinationList = new SelectList(destinations);

                return View(model);
        }

        [HttpPost]
        public IActionResult SearchFlights()
        {
            return View("Results");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchFlightsWithHotels(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.SourceList = new SelectList(await _db.GetSourcesAsync());
                model.DestinationList = new SelectList(await _db.GetDestinationsAsync());
                return View("Index", model);
            }

            var results = await _db.SearchFlightsWithHotelsAsync(
                model.Source,
                model.Destination,
                model.NumberOfPersons
            );

            return View("Results", results);
        }

    }
}