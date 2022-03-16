using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Clusters
{
    public class BaseClusterUrl
    {
        // Central clusters test
        private const string HALF = "http://{0}web01.in.lab/";
        private const string TEST = "https://home-{0}.ucnlabext.com/";
        private const string STAGING = "https://home-{0}.ucnlabext.com/";

        private const string HALF_API = "http://{0}web01.in.lab{1}/";
        private const string TEST_API = "https://api-{0}.ucnlabext.com{1}/";
        private const string STAGING_API = "https://api-{0}.ucnlabext.com{1}/";

        // CXone clusters test
        private const string AWS_DEV = "https://home-{0}.dev.nice-incontact.com/";
        private const string AWS_TEST = "https://home-{0}.test.nice-incontact.com/";
        private const string AWS_STAGING = "https://home-{0}.staging.nice-incontact.com/";
        private const string AWS_PERF = "https://home-{0}.perf.nice-incontact.com/";
        private const string AWS_STAGING_V2 = "https://home-{0}.staging.niceincontact.com/";

        private const string AWS_DEV_API = "https://api-{0}.dev.nice-incontact.com{1}/";
        private const string AWS_TEST_API = "https://api-{0}.test.nice-incontact.com{1}/";
        private const string AWS_STAGING_API = "https://api-{0}.staging.nice-incontact.com{1}/";
        private const string AWS_PERF_API = "https://api-{0}.perf.nice-incontact.com/";
        private const string AWS_STAGING_API_V2 = "https://api-{0}.staging.niceincontact.com{1}/";

        // Central clusters Production
        private const string PRODUCTION = "https://home-{0}.incontact.com/";
        private const string NICE_PRODUCTION = "https://home-{0}.niceincontact.com/";
        private const string PRODUCTION_FEDRAMP = "https://home-{0}.niceincontact.com/";
        private const string PRODUCTION_FEDRAMP_V2 = "https://home-{0}.nice-incontact.com/";
        private const string PRODUCTION_API = "https://api-{0}.incontact.com{1}/";
        private const string NICE_PRODUCTION_API = "https://api-{0}.incontact.com{1}/";
        private const string PRODUCTION_FEDRAMP_API = "https://api-{0}.niceincontact.com{1}/";
        private const string PRODUCTION_FEDRAMP_API_V2 = "https://api-{0}.nice-incontact.com{1}/";

        // CXone clusters Production
        private const string PRODUCTION_EUROPE = "https://home-{0}.incontact.eu/";
        private const string AWS_PRODUCTION = "https://home-{0}.nice-incontact.com/";
        private const string AWS_PRODUCTION_V2 = "https://home-{0}.niceincontact.com/";

        private const string PRODUCTION_EUROPE_API = "https://api-{0}.incontact.eu{1}/";
        private const string AWS_PRODUCTION_API = "https://api-{0}.nice-incontact.com{1}/";
        private const string AWS_PRODUCTION_API_V2 = "https://api-{0}.niceincontact.com{1}/";


        // Others
        private const string PERSONAL = "http://localhost/";
        private const string WEBADMINS = "http://{0}/WebAdmins";
        private const string PERSONAL_API = "http://{0}{1}/";

        private const string TOKEN_SERVICE_URL = "{0}InContactAuthorizationServer/Token";
        private const string RESOURCE_BASE_URL = "{0}inContactAPI/";
        private const string CXONE_TOKEN_SERVICE_URL = "{0}public/authentication/v1/login";

        // Sub Domain Central
        private const string LOGIN_PROD = "https://login.incontact.com";
        private const string LOGIN_CMP_PROD = "https://login-cmp.niceincontact.com";

        // Sub Domain CXone
        private const string NA1_DEV = "https://na1.dev.nice-incontact.com/";
        private const string NA1_TEST = "https://na1.test.nice-incontact.com/";
        private const string NA1_STAGING = "https://na1.staging.nice-incontact.com/";
        private const string NA1_PERF = "https://na1.perf.nice-incontact.com/";
        private const string NA1_PROD = "https://na1.nice-incontact.com/";
        private const string NA2_PROD = "https://na2.niceincontact.com/";
        private const string EU1_PROD = "https://eu1.niceincontact.com/";
        private const string AU1_PROD = "https://au1.nice-incontact.com/";
        private const string UK1_PROD = "https://uk1.niceincontact.com/";
        private const string CA1_PROD = "https://ca1.niceincontact.com/";
        private const string JP1_PROD = "https://jp1.niceincontact.com/";

        //BrandEmbassy API Url
        private const string BE_NA1_DEV = "https://api-de-na1.dev.niceincontact.com/{0}";
        private const string BE_NA1_STAGING = "https://api-de-na1.staging.niceincontact.com/{0}";
        private const string BE_NA1_TESTING = "https://api-de-na1.test.niceincontact.com/{0}";

        // Email Management API Url
        private const string EMAIL_MANAGEMENT_API_DEV = "http://email-management-api-na1.dev.inucn.com/{0}";
        private const string EMAIL_MANAGEMENT_API_STAGING = "http://email-management-api-na1.staging.inucn.com/{0}";

        //DevOne URL's
        public const string DevOne_DEV = "https://lab-dev-developer.blfdev.lab/";  //"https://lab-dev-developer.blfdev.lab/";    
        public const string DevOne_TESTING = "https://qa-dev-developer.blfdev.lab/"; // 
        public const string DevOne_STAGING = "https://stg-developer.blfdev.lab/"; //Main Staging
        public const string DevOne_PROD = "https://developer.niceincontact.com/";

        public enum HC
        {
            HC17, HC18
        }
        public enum Test
        {
            TC1, TC2, TC3, TC4, TC5
        }
        public enum Staging
        {
            SC1, SC2, SC3, SC10, SC11
        }
        public enum Staging2
        {
            SO30
        }
        public enum Na1Dev
        {
            DO10, DO12, DO13, DO15, DO17, DO28, DO29, DO31, DO32, DO33, DO35, DO36, DO38, DO39, DO40, DO41, DO44, DO45, DO46, DO47, DO48, DO50, DO52, DO54, DO55, DO56, DO59, DO60, DO61, DO62, DO66, DO68, DO72, DO74, DO79, DO80, DO81, DO83, DO84, DO85, DO86, DO88, DO89, DO90, DO91, DO92, DO94, DO95, DO98
        }
        public enum Na1Test
        {
            TO31, TO32
        }
        public enum Na1Staging
        {
            SO31, SO32, SC1UH, SC2UH, SC3UH, SC10UH, SC11UH
        }
        public enum Na1Perf
        {
            SO33
        }
        public enum Na1Production
        {
            B32,
            C32, C33, C35, C36, C37, C38, C39, C41, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53
        }
        public enum Na2Production
        {
            C72, C73
        }
        public enum Eu1Production
        {
            E32, E33, E34, E35
        }
        public enum Au1Production
        {
            A32
        }
        public enum Uk1Production
        {
            L32, L33, L34
        }
        public enum Ca1Production
        {
            M32
        }
        public enum Jp1Production
        {
            J32
        }
        public enum CentralProduction
        {
            B2, B3, B31,
            C4, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C26, C27, C28, C29, C30, C31, C34, C40, C42, C43,
        }
        public enum ProductionEurope
        {
            E1
        }
        public enum NiceProduction
        {
            A31, E31
        }
        public enum CentralCMPProduction
        {
            C71
        }

        public static void SetBaseUrl(Cluster cluster)
        {
            Dictionary<Type, string[]> url = new Dictionary<Type, string[]>
            {
                { typeof(HC),                   new string[3] { string.Empty, HALF, HALF_API } },
                { typeof(Test),                 new string[3] { string.Empty, TEST, TEST_API } },
                { typeof(Staging),              new string[3] { string.Empty, STAGING, STAGING_API } },
                { typeof(Staging2),             new string[3] { string.Empty, AWS_STAGING_V2, AWS_STAGING_API_V2 } },
                { typeof(Na1Dev),               new string[3] { NA1_DEV, AWS_DEV, AWS_DEV_API } },
                { typeof(Na1Test),              new string[3] { NA1_TEST, AWS_TEST, AWS_TEST_API } },
                { typeof(Na1Staging),           new string[3] { NA1_STAGING, AWS_STAGING, AWS_STAGING_API } },
                { typeof(Na1Perf),              new string[3] { NA1_PERF, AWS_PERF, AWS_PERF_API } },
                { typeof(Na1Production),        new string[3] { NA1_PROD, AWS_PRODUCTION, AWS_PRODUCTION_API } },
                { typeof(Na2Production),        new string[3] { NA2_PROD, PRODUCTION_FEDRAMP, PRODUCTION_FEDRAMP_API } },
                { typeof(Eu1Production),        new string[3] { EU1_PROD, AWS_PRODUCTION_V2, AWS_PRODUCTION_API_V2 } },
                { typeof(Au1Production),        new string[3] { AU1_PROD, AWS_PRODUCTION_V2, AWS_PRODUCTION_API_V2 } },
                { typeof(Uk1Production),        new string[3] { UK1_PROD, AWS_PRODUCTION_V2, AWS_PRODUCTION_API_V2 } },
                { typeof(Ca1Production),        new string[3] { CA1_PROD, AWS_PRODUCTION_V2, AWS_PRODUCTION_API_V2 } },
                { typeof(Jp1Production),        new string[3] { JP1_PROD, AWS_PRODUCTION_V2, AWS_PRODUCTION_API_V2 } },
                { typeof(CentralProduction),    new string[3] { string.Empty, PRODUCTION, PRODUCTION_API } },
                { typeof(ProductionEurope),     new string[3] { string.Empty, PRODUCTION_EUROPE, PRODUCTION_EUROPE_API } },
                { typeof(NiceProduction),       new string[3] { string.Empty, NICE_PRODUCTION, NICE_PRODUCTION_API } },
                { typeof(CentralCMPProduction), new string[3] { string.Empty, PRODUCTION_FEDRAMP_V2, PRODUCTION_FEDRAMP_API_V2 } }
            };
            var urls = url.FirstOrDefault(_ => Enum.IsDefined(_.Key, cluster.Name)).Value;
            cluster.CXoneDomain = urls[0];
            cluster.ACD_Domain = string.Format(urls[1], cluster.Name).ToLower();
            cluster.ApiBaseUrl = string.Format(urls[2], cluster.Name, string.Empty).ToLower();
            cluster.InternalApiBaseUrl = string.Format(urls[2], cluster.Name, ":8800").ToLower();
            cluster.TokenWebServiceUrl = string.Format(TOKEN_SERVICE_URL, cluster.ApiBaseUrl);
            cluster.ResourceBaseUrl = string.Format(RESOURCE_BASE_URL, cluster.ApiBaseUrl);
            cluster.CXoneTokenWebServiceUrl = string.Format(CXONE_TOKEN_SERVICE_URL, cluster.CXoneDomain);
            SetTM_User(cluster);
        }

        public static void SetTM_User(Cluster cluster)
        {
            Dictionary<Type, (string, string)> accounts = new Dictionary<Type, (string, string)>
            {
                { typeof(Na1Dev),               (Properties.Resources.TM_dev_user, Properties.Resources.TM_dev_password) },
                { typeof(Na1Test),              (Properties.Resources.TM_test_user, Properties.Resources.TM_test_password) },
                { typeof(Na1Staging),           (Properties.Resources.TM_staging_user, Properties.Resources.TM_staging_password) },
            };

            (cluster.TM_User, cluster.TM_Password) = accounts.FirstOrDefault(_ => Enum.IsDefined(_.Key, cluster.Name)).Value;
        }
    }
}
