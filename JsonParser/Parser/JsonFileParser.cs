using Newtonsoft.Json;


namespace JsonParser.Parser
{
    public class JsonFileParser
    {
        public string Path { get; set; }


        public async Task<Customer> ParseFile(string path)
        {
            this.Path = path;
            var json = await File.ReadAllTextAsync(path);
            var data = JsonConvert.DeserializeObject<Customer>(json);
            var customer = new Customer();
            if(data == null){
                throw new Exception("File is empty");
            }
           var customerFromFile = await customer.CreateCustomer(data.FirstName, data.LastName, data.Email, data.PhoneNumber, data.Street, data.City, data.State, data.ZipCode);
           return customerFromFile;

        }
    }
}