using Microsoft.AspNetCore.Mvc;

namespace LocationApi.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<Location> Locations = new List<Location>
        {
            new Location { Name = "Pharmacy", Type = "Health", OpeningTime = TimeSpan.FromHours(9), ClosingTime = TimeSpan.FromHours(18) },
            new Location { Name = "Bakery", Type = "Food", OpeningTime = TimeSpan.FromHours(7), ClosingTime = TimeSpan.FromHours(20) },
            new Location { Name = "Barber Shop", Type = "Services", OpeningTime = TimeSpan.FromHours(10), ClosingTime = TimeSpan.FromHours(19) },
            new Location { Name = "Supermarket", Type = "Retail", OpeningTime = TimeSpan.FromHours(8), ClosingTime = TimeSpan.FromHours(22) },
            new Location { Name = "Candy Store", Type = "Food", OpeningTime = TimeSpan.FromHours(11), ClosingTime = TimeSpan.FromHours(18) },
            new Location { Name = "Cinema Complex", Type = "Entertainment", OpeningTime = TimeSpan.FromHours(12), ClosingTime = TimeSpan.FromHours(23) },
            new Location { Name = "Gym", Type = "Fitness", OpeningTime = TimeSpan.FromHours(6), ClosingTime = TimeSpan.FromHours(21) },
            new Location { Name = "Bookstore", Type = "Retail", OpeningTime = TimeSpan.FromHours(10), ClosingTime = TimeSpan.FromHours(19) },
            new Location { Name = "Tech Store", Type = "Electronics", OpeningTime = TimeSpan.FromHours(9), ClosingTime = TimeSpan.FromHours(20) },
            new Location { Name = "Coffee Shop", Type = "Food", OpeningTime = TimeSpan.FromHours(7), ClosingTime = TimeSpan.FromHours(18) },
            new Location { Name = "Art Gallery", Type = "Entertainment", OpeningTime = TimeSpan.FromHours(11), ClosingTime = TimeSpan.FromHours(17) },
            new Location { Name = "Games Complex", Type = "Entertainment", OpeningTime = TimeSpan.FromHours(12), ClosingTime = TimeSpan.FromHours(23) },

        };

        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetLocationsWithAvailability()
        {
            var currentTime = DateTime.Now.TimeOfDay;
            var availableLocations = Locations
                .Where(l => l.OpeningTime <= currentTime && currentTime <= l.ClosingTime)
                .ToList();

            return Ok(availableLocations);
        }

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

    }
}
