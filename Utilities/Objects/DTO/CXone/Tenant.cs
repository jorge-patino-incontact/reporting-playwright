
namespace Utilities.Objects.DTO.CXone
{
    public class Tenant : IDTO
    {
        public Tenant tenant { get; set; }
        public string tenantId { get; set; }
        public string tenantName { get; set; }
        public string schemaName { get; set; }
        public string parentId { get; set; }
        public string partnerId { get; set; }
        public string source { get; set; }
        public string creationDate { get; set; }
        public string expirationDate { get; set; }
        public string timezone { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string customerType { get; set; }
        public string clusterId { get; set; }
        public string billingId { get; set; }
        public int billingCycle { get; set; }
        public string billingTelephoneNumber { get; set; }
        public int userSoftLimit { get; set; }
        public string modificationDate { get; set; }

    }
}
