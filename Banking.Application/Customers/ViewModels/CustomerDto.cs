namespace Banking.Application.Customers.ViewModels
{
    public class CustomerDto
    {
        public long idUser { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string identityDocument { get; set; }
        public bool active { get; set; }

        public CustomerDto()
        {
        }
    }
}
