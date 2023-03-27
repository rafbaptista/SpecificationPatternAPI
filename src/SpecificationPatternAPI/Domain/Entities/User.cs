namespace SpecificationPatternAPI.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual int? CompanyId { get; set; }
        public Company Company { get; set; }
        public bool IsCompanyAdministrator { get; set; }

        public bool Active { get; set; }

        public bool IsSystemAdministrator
        {
            get
            {
                return CompanyId is null;
            }
        }
    }
}
