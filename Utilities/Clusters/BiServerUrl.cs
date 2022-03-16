using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities.Clusters
{
    public class BiServerUrl
    {
        #region Constants

        // Test

        private const string STAGING_BI_SERVER = "https://bi.ucnlabext.com";
        private const string STAGING_BI_SERVER_A = "http://SCA-INGWS01/bisecurityproxy";
        private const string STAGING_BI_SERVER_B = "http://SCB-INGWS01/bisecurityproxy";
        private const string ACD_TEST_BI_SERVER_1 = "https://bi-{0}.ucnlabext.com";
        private const string ACD_TEST_BI_SERVER_2 = "https://bi-tc.ucnlabext.com";
        private const string UH_TEST_BI_SERVER = "https://bi-to.nice-incontact.com";
        private const string UH_STAGING_BI_SERVER = "https://bi-so.staging.niceincontact.com";
        private const string HC_BI_SERVER = "http://{0}gws01/BISecurityProxy";

        // Production
        private const string AUSTRALIAN_PROD_BI_SERVER = "https://bi-aa.niceincontact.com";
        private const string CENTRAL_PROD_BI_SERVER_1 = "https://bi.incontact.com";
        private const string CENTRAL_PROD_BI_SERVER_2 = "https://bi-ao.incontact.com";
        private const string EUROPE_PROD_BI_SERVER = "https://bi-af.niceincontact.com";
        private const string EUROPE_PROD_BI_SERVER_A = "http://FRA-INGWS01.INEUR.EU/bisecurityproxy";
        private const string EUROPE_PROD_BI_SERVER_B = "http://MUN-INGWS01.INEUR.EU/bisecurityproxy";
        private const string LONDON_PROD_BI_SERVER = "https://bi-al.niceincontact.com";
        private const string FED_RAMP_PROD_BI_SERVER = "https://bi-cv.nice-incontact.com";
        private const string UH_PROD_BI_SERVER = "https://bi-ao.nice-incontact.com";
        private const string MONTREAL_PROD_BI_SERVER = "https://bi-am.niceincontact.com";
        private const string JAPAN_PROD_BI_SERVER = "https://bi-aj.niceincontact.com";

        #endregion

        #region Enums

        public enum Na1Dev
        {
            DO10, DO12, DO13, DO15, DO17, DO28, DO29, DO31, DO32, DO33, DO35, DO36, DO38, DO39, DO40, DO41, DO44, DO45, DO46, DO47, DO48, DO50, DO52, DO54, DO55, DO56, DO59, DO60, DO61, DO62, DO66, DO68, DO72, DO74, DO80, DO81, DO83, DO84, DO85, DO86, DO88, DO90, DO91, DO92, DO94, DO95
        }
        public enum Na1Test
        {
            TO31, TO32
        }
        public enum Test1
        {
            TC4, TC5
        }
        public enum Test2
        {
            TC1, TC2, TC3
        }
        public enum Na1Staging
        {
            SO30, SO31, SO32, SO33
        }
        public enum Staging
        {
            SC1, SC3, SC10, SC11
        }
        public enum HC
        {
            HC18
        }
        public enum AuProduction
        {
            A31, A32
        }
        public enum CentralProduction1
        {
            B2, B3,
            C4, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20
        }
        public enum CentralProduction2
        {
            B31,
            C26, C27, C28, C29, C30, C31, C34, C40, C42
        }
        public enum EuProduction
        {
            E1, E31, E32, E33, E34, E35
        }
        public enum FedRampProduction
        {
            C71, C72, C73
        }
        public enum UhProduction
        {
            B32,
            C32, C33, C35, C36, C37, C38, C39, C41, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53
        }
        public enum LondonProduction
        {
            L32, L33, L34
        }
        public enum MontrealProduction
        {
            M32
        }
        public enum JapanProduction
        {
            J32
        }

        #endregion

        /// <summary>
        /// This will generate the BI Server Url
        /// </summary>
        /// <param name="cluster">Cluster POCO</param>
        /// <returns>string</returns>
        public static void SetBiServerUrl(Cluster cluster)
        {
            Dictionary<Type, string[]> biUrl = new Dictionary<Type, string[]>
            {
                { typeof(Na1Dev),               new string[0] {} },
                { typeof(Na1Test),              new string[1] { UH_TEST_BI_SERVER } },
                { typeof(Na1Staging),           new string[1] { UH_STAGING_BI_SERVER } },
                { typeof(Staging),              new string[2] { STAGING_BI_SERVER_A, STAGING_BI_SERVER_B } },
                { typeof(Test1),                new string[1] { string.Format(ACD_TEST_BI_SERVER_1, cluster.Name) } },
                { typeof(Test2),                new string[1] { ACD_TEST_BI_SERVER_2} },
                { typeof(HC),                   new string[1] { HC_BI_SERVER } },
                { typeof(CentralProduction1),   new string[1] { CENTRAL_PROD_BI_SERVER_1} },
                { typeof(CentralProduction2),   new string[1] { CENTRAL_PROD_BI_SERVER_2 } },
                { typeof(AuProduction),         new string[1] { AUSTRALIAN_PROD_BI_SERVER } },
                { typeof(EuProduction),         new string[1] { EUROPE_PROD_BI_SERVER } },
                { typeof(FedRampProduction),    new string[1] { FED_RAMP_PROD_BI_SERVER } },
                { typeof(LondonProduction),     new string[1] { LONDON_PROD_BI_SERVER } },
                { typeof(UhProduction),         new string[1] { UH_PROD_BI_SERVER } },
                { typeof(MontrealProduction),   new string[1] { MONTREAL_PROD_BI_SERVER } },
                { typeof(JapanProduction),      new string[1] { JAPAN_PROD_BI_SERVER } },
            };
           cluster.BiServerUrl = biUrl.Where(_ => Enum.IsDefined(_.Key, cluster.Name)).FirstOrDefault().Value;
        }
    }
}

