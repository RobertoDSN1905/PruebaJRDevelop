namespace prueba.Models
{
    public class Usuario
    {
        public string customerId { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public DateTime birthdate { get; set; }
        public List<Direccion> Address { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
        
    }

    public class Direccion
    {
        public string Adress1 { get; set; }
        public string CreationDate { get; set; }
        public string PostalCode { get; set; }
        public bool preferred {  get; set; }
    }

}
