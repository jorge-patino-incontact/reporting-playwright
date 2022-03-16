using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Utilities.Clusters;
using Utilities.Enums.API;
using Version = Utilities.Enums.API.Version;

namespace Utilities.Common
{
    public static class ApiUtilities
    {
        private static Dictionary<Acd_api, string> Acd = new Dictionary<Acd_api, string> 
        {
            //Teams
            { Acd_api.GetTeam, "/teams/{0}" },      // 0: teamId|teamUuid
            { Acd_api.GetTeams, "/teams" },
            { Acd_api.PostTeams, "/teams" },
            { Acd_api.PutTeams,  "/teams/{0}" },    // 0: teamId|teamUuid
            //Agents
            { Acd_api.GetAgent, "/agents/{0}" },    // 0: agentId
            { Acd_api.GetAgents, "/agents" },
            { Acd_api.PostAgents, "/agents" },
            { Acd_api.PutAgents, "/agents/{0}" },   // 0: agentId
            //Campaigns
            { Acd_api.GetCampaign,  "/campaigns/{0}" },     // 0: campaignId
            { Acd_api.GetCampaigns,  "/campaigns" },
            { Acd_api.PostCampaigns,  "/campaigns" },
            { Acd_api.PutCampaigns,  "/campaigns/{0}" },    // 0: campaignId
            //Skills
            { Acd_api.GetSkill,  "/skills/{0}" },   // 0: skillId
            { Acd_api.GetSkills,  "/skills" },
            { Acd_api.PostSkills,  "/skills" },
            { Acd_api.PutSkills,  "/skills/{0}" },  // 0: skillId
            //Point of Contacts
            { Acd_api.GetPointOfContact,  "/points-of-contact/{0}" },   // 0: pointOfContactId
            { Acd_api.GetPointOfContacts,  "/points-of-contact" },
            { Acd_api.PostPointOfContacts,  "/points-of-contact" },
            { Acd_api.PutPointOfContacts,  "/points-of-contact/{0}" },  // 0: pointOfContactId
            //Unavailable codes
            { Acd_api.GetUnavailableCodes, "/unavailable-codes" },
            //Reports
            { Acd_api.GetReport, "/reports" },
            { Acd_api.PostDataDownloadReport, "/report-jobs/datadownload/{0}" }, // 0: reportId
        };

        private static Dictionary<Uh_api, string> UH = new Dictionary<Uh_api, string>
        {
            //Roles
            { Uh_api.GetRole, "authorization/role/{0}" },      // 0: roleId
            { Uh_api.GetRoles, "authorization/roles/search" },
            { Uh_api.PostRole, "authorization/role/" },
            { Uh_api.PutRole,  "authorization/role/" },
            //Tenant
            { Uh_api.GetCurrentTenant,  "tenants/current" },
        };

        public static string AcdUrl(Cluster cluster, Acd_api acd_Api, Version version = Version.V22, string [] urlParameters = null)
        {
            if (Acd.ContainsKey(acd_Api))
                return cluster.ResourceBaseUrl + RelativeUrl(Acd[acd_Api], version, urlParameters ??= new string[] { });
            else
                throw new Exception($"The api {acd_Api.ToString()} is not defined in Acd dictionary");
        }

        public static string UhUrl(Cluster cluster, Uh_api uh_api, string[] urlParameters = null)
        {
            if (UH.ContainsKey(uh_api))
                return cluster.CXoneDomain + string.Format(UH[uh_api], urlParameters ??= new string[] { });
            else
                throw new Exception($"The api {uh_api.ToString()} is not defined in UH dictionary");
        }

        private static string RelativeUrl(string acd_Api, Version version, string[] urlParameters)
        {
            return $"services/{version.ToString().ToLower()}.0{string.Format(acd_Api, urlParameters)}";
        }

        public static string SerializeJson(object objectToSerialize, bool ignoreNulls = true)
        {
            try
            {
                return JsonConvert.SerializeObject(objectToSerialize, Formatting.None,
                    ignoreNulls
                        ? new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }
                        : new JsonSerializerSettings());
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception Thrown!  --  {ex.Message}");
            }
        }
    }
}
