namespace Domain.Endpoint.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; } 

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }
    }
}
