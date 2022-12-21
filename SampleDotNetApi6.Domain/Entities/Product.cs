using SampleDotNetApi6.Domain.Validations;

namespace SampleDotNetApi6.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Product(string name, string codErp, decimal price)
        {
            Validation(name, codErp, price);
        }

        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.When(id < 0, "Id deve ser maior que zero!");

            Id = id;

            Validation(name, codErp, price);
        }

        private void Validation(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Informar um nome!");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "Informar um código erp!");
            DomainValidationException.When(price < 0, "Informar um price!");
        
            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
