
namespace Utilities.Objects.DTO.CXone
{
    public class User : IDTO
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string role { get; set; }
        public string roleUUID { get; set; }
        public string status { get; set; }
        public string creationDate { get; set; }
        public object secondaryRoleIds { get; set; }
        public string externalIdentity { get; set; }
        public string emailAddress { get; set; }
        public string fullName { get; set; }
        public object customAttributes { get; set; }
        public string organizationName { get; set; }
        public string assignedGroup { get; set; }
        public string country { get; set; }
        public string timeZone { get; set; }
        public string teamId { get; set; }
        public string hireDate { get; set; }
        public bool impersonated { get; set; }
        public bool billable { get; set; }
    }

    public class LoginResponse : IDTO
    {
        public User user { get; set; }
        public string token { get; set; }
        public int tokenExpirationTimeSec { get; set; }
        public string refreshToken { get; set; }
        public int refreshTokenExpirationTimeSec { get; set; }
        public string tenantId { get; set; }
        public string sessionId { get; set; }
        public string authCode { get; set; }
    }
}
