using System.Collections.Generic;

namespace Utilities.Objects.DTO.CXone
{   
    public class Role : IDTO
    {
        public Role role { get; set; }
        public string roleId { get; set; }
        public string roleName { get; set; }
        public object permissions { get; set; }
        public List<Application> applications { get; set; }
        public string displayName { get; set; }
        public int? sequence { get; set; }
        public string description { get; set; }
        public int? modifiable { get; set; }
        public int? Internal { get; set; }
        public string status { get; set; }
        public string lastModifiedTime { get; set; }
        public string parentAccess { get; set; }
        public string loginAuthenticatorId { get; set; }

    }
    public class Roles : IDTO
    {
        public List<Role> roles { get; set; }
    }
    public class Application: IDTO
    {
        public string applicationId { get; set; }
        public List<Privilege> privileges { get; set; }


    }
    public class Privilege : IDTO
    {
        public string privilegeId { get; set; }
        public List<string> actions { get; set; }

    }
}
