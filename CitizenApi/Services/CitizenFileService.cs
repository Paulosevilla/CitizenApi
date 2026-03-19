using CitizenApi.Models;
using Microsoft.Extensions.Logging;

namespace CitizenApi.Services
{
    public class CitizenFileService
    {
        private readonly string _filePath;
        private readonly ILogger<CitizenFileService> _logger;

        public CitizenFileService(IConfiguration configuration, ILogger<CitizenFileService> logger)
        {
            _filePath = configuration["CitizenFilePath"] ?? "Data/citizens.csv";
            _logger = logger;

            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }


        public List<Citizen> GetAll()
        {
            try
            {
                var citizens = new List<Citizen>();
                var lines = File.ReadAllLines(_filePath);

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var values = line.Split(',');

                    if (values.Length < 5)
                        continue;

                    citizens.Add(new Citizen
                    {
                        FirstName = values[0],
                        LastName = values[1],
                        CI = values[2],
                        BloodGroup = values[3],
                        PersonalAsset = values[4]
                    });
                }

                return citizens;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading citizens file");
                return new List<Citizen>();
            }
        }

        public Citizen? GetByCi(string ci)
        {
            return GetAll().FirstOrDefault(c => c.CI == ci);
        }

        public void SaveAll(List<Citizen> citizens)
        {
            try
            {
                var lines = citizens.Select(c =>
                    string.Join(",", c.FirstName, c.LastName, c.CI, c.BloodGroup, c.PersonalAsset));

                File.WriteAllLines(_filePath, lines);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing citizens file");
            }
        }
    }
}
