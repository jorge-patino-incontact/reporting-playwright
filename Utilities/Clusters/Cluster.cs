using System;
using System.Collections.Generic;
using System.Text;
using Utilities.GBUs;

namespace Utilities.Clusters
{
    public class Cluster
    {

        #region Variables

        public string Name { get; set; }
        public string CXoneDomain { get; set; }
        public string ApiBaseUrl { get; set; }
        public string TokenWebServiceUrl { get; set; }
        public string ResourceBaseUrl { get; set; }
        public string CXoneTokenWebServiceUrl { get; set; }
        public string ACD_Domain { get; internal set; }
        public string InternalApiBaseUrl { get; set; }
        public string[] BiServerUrl { get; set; }
        public BaseBusinessUnit BusinessUnit { get; set; }

        // ---------------------------------------
        // ------------- Data Access -------------
        // ---------------------------------------
        public string FileServerHost { get; set; }
        public string CorA { get; set; }
        public string CorB { get; set; }
        public string DWA { get; set; }
        public string DWB { get; set; }
        public string SMTP { get; set; }
        public string Host { get; set; }
        public string HostASide { get; set; }
        public string HostBSide { get; set; }
        public string HostDWASide { get; set; }
        public string HostDWBSide { get; set; }
        public string scDataBase { get; set; }
        public string scServerHost { get; set; }
        public string DBUserID { get; set; }
        public string UserID { get; set; }
        public string DbPassword { get; set; }
        public string DataBase { get; set; }
        public string DataBaseInData { get; set; }
        public string Tablename { get; set; }
        public string DataBaseDWCode { get; set; }
        public string DataBaseDWData { get; set; }

        // Tenant Management
        public string TM_User { get; set; }
        public string TM_Password { get; set; }

        #endregion

    }
}
