using System.Text.Json;
using CitizenApi.DTOs;
using CitizenApi.Models;
using CitizenApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitizenApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitizenController : ControllerBase
    {
        private readonly CitizenFileService _fileService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CitizenController> _logger;

        private readonly string[] _bloodGroups =
        {
            "A+", "A-", "B+", "B-", "O+", "O-", "AB+", "AB-"
        };

        public CitizenController(
            CitizenFileService fileService,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            ILogger<CitizenController> logger)
        {
            _fileService = fileService;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var citizens = _fileService.GetAll();
            return Ok(citizens);
        }

        [HttpGet("{ci}")]
        public IActionResult GetByCi(string ci)
        {
            var citizen = _fileService.GetByCi(ci);

            if (citizen == null)
                return NotFound("Citizen not found");

            return Ok(citizen);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCitizenDto dto)
        {
            var citizens = _fileService.GetAll();

            if (citizens.Any(c => c.CI == dto.CI))
                return BadRequest("Citizen with this CI already exists");

            var bloodGroup = _bloodGroups[new Random().Next(_bloodGroups.Length)];
            var personalAsset = await GetRandomAssetAsync();

            var citizen = new Citizen
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                CI = dto.CI,
                BloodGroup = bloodGroup,
                PersonalAsset = personalAsset
            };

            citizens.Add(citizen);
            _fileService.SaveAll(citizens);

            _logger.LogInformation("Citizen created");

            return Ok(citizen);
        }

        [HttpPut("{ci}")]
        public IActionResult Update(string ci, UpdateCitizenDto dto)
        {
            var citizens = _fileService.GetAll();
            var citizen = citizens.FirstOrDefault(c => c.CI == ci);

            if (citizen == null)
                return NotFound("Citizen not found");

            citizen.FirstName = dto.FirstName;
            citizen.LastName = dto.LastName;

            _fileService.SaveAll(citizens);

            _logger.LogInformation("Citizen updated");

            return Ok(citizen);
        }

        [HttpDelete("{ci}")]
        public IActionResult Delete(string ci)
        {
            var citizens = _fileService.GetAll();
            var citizen = citizens.FirstOrDefault(c => c.CI == ci);

            if (citizen == null)
                return NotFound("Citizen not found");

            citizens.Remove(citizen);
            _fileService.SaveAll(citizens);

            _logger.LogInformation("Citizen deleted");

            return Ok("Citizen deleted");
        }

        private async Task<string> GetRandomAssetAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var url = _configuration["ExternalApi:BaseUrl"];

                _logger.LogInformation("External API request executed");

                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return "Unknown Asset";

                var json = await response.Content.ReadAsStringAsync();
                var objects = JsonSerializer.Deserialize<List<ApiObject>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (objects == null || objects.Count == 0)
                    return "Unknown Asset";

                var randomObject = objects[new Random().Next(objects.Count)];
                return randomObject.Name ?? "Unknown Asset";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling external API");
                return "Unknown Asset";
            }
        }

        private class ApiObject
        {
            public string? Name { get; set; }
        }
    }
}
