using ServiceContracts;

namespace Services
{
    public class CitiesService: ICitiesService, IDisposable 
    {
        private List<string> _cities;
        private Guid _serviceInstanceId;

        public Guid ServiceInstanceId { get
            {
                return _serviceInstanceId;
            }
        }
        
        public CitiesService() {
            _serviceInstanceId = Guid.NewGuid();
            _cities = new List<string>()
            {
                "london",
                "Paris",
                "Tokyo",
                "Delhi"
            };

            //Instance be logic to open db connection and end in dispose method
        }

        public List<string> GetCities()
        {
            return _cities;
        }
        public void Dispose()
        {
            //End the db connection eg.
        }
    }
}
