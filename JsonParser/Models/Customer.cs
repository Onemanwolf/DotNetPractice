using Newtonsoft.Json;

namespace JsonParser.Parser
{
    public class Customer
    {

        public string CustomerId { get; set; }

        [JsonProperty("firstName")]
        public string? FirstName { get; private set; }
        [JsonProperty("lastName")]
        public string? LastName { get; private set; }
        [JsonProperty("email")]
        public string? Email { get; private set; }
        [JsonProperty("phone")]
        public string? PhoneNumber { get; private set; }
        [JsonProperty("street")]

        public string? Street { get; private set; }
        [JsonProperty("city")]
        public string? City { get; private set; }
        [JsonProperty("state")]
        public string? State { get; private set; }
        [JsonProperty("zip")]
        public string? ZipCode { get; private set; }

        public async Task<Customer> CreateCustomer(string firstName, string lastName, string email, string phoneNumber, string street, string city, string state, string zipCode)
        {


            var exist = await CustomerEmailExist(email);
             if(exist == true){
                throw new Exception("Email already exist");
             }

            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Street = street,
                City = city,
                State = state,
                ZipCode = zipCode,

                CustomerId = Guid.NewGuid().ToString()
            };

            return customer;
        }

        private async Task<bool> CustomerEmailExist(string email)
        {
            if(email == "timothy.oleson@gmail.com"){
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}