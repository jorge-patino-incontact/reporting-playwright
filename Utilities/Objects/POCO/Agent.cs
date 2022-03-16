using System.Collections.Generic;

namespace Utilities.Objects.POCO
{
    public class Agent : IPOCO
    {
        #region enums

        public enum EmploymentTypes
        {
            None = 0,
            FullTime = 1,
            PartTime = 2,
            Temporary = 3,
            Outsourced = 4,
            Other = 5
        }

        public enum UserType
        {
            Agent,
            Supervisor,
            Administrator
        }

        public enum SFAgentFooterlogo
        {
            None,
            SFAgentCoBrand,
            SFAgent,
            CoBrand
        }

        public enum ContactEvent
        {
            CallContactEvent,
            ChatContactEvent,
            TextContactEvent,
            EmailContactEvent,
            WorkItemContactEvent
        }
        public enum CXoneUserType
        {
            Agent,
            Rollover,
            BusinessUser,
            GeneralVoicemail
        }
        public enum CXoneNotificationType
        {
            EmailOnly,
            EmailWithFileAttachment,
            WebOnly,
            ViaAgent
        }

        public enum CXoneAccessType
        {
            None,
            CXoneAttendantOnly,
            CXoneAttendantWithACD
        }

        #endregion

        public int? BusNo { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public string Email;
        public bool IsActive;
        public int TeamId;
        public string TeamName;
        public string CountryCode;
        public string StateCode;
        public string City;
        public int? ReportToId;
        public string ReportToFirstName;
        public string ReportToMiddleName;
        public string ReportToLastName;
        public bool IsSupervisor;
        public string TimeZone;
        public string Custom1;
        public string Custom2;
        public string Custom3;
        public string Custom4;
        public string Custom5;
        public string InternalId;
        public string Username;
        public string Password = Properties.Resources.Password;
        public string DialingPatternName;
        public string Notes;
        public int? EmailRefusalTimeout;
        public int? DocumentRefusalTimeout;
        public int? ChatRefusalTimeout;
        public int? PhoneCallRefusalTimeout;
        public int? VoiceMailRefusalTimeout;
        public int? WorkItemRefusalTimeout;
        public int UseTeamMaxConcurrentChats;
        public int MaxConcurrentChats;
        public double? HourlyCost;
        public EmploymentTypes EmploymentType;
        public bool? AtHomeWorker;
        public int SecurityProfileId;
        public string SecurityProfileName;
        public bool WhatIfAgent;
        public string HireDate;
        public string TerminationDate;
        public CXoneUserType CxoneUserType;
        public CXoneNotificationType CxoneNotificationType;
        public string VoicemailPin;
        public bool CheckToenterNonusNumber;
        public string PhoneNumber;
        public bool CompanyDirectory;
        public bool AutoAssignExtension;
        public string Extension;
        public CXoneAccessType CxoneAccessType;
        public UserType usrType;
        public List<AgentIntegratedSoftphoneWebRtcUrl> WebRtcUrls;

        public override string ToString()
        {
            return string.Format("BusNo: {0} -- Id: {1} -- Name: {2}", BusNo, Id, Name);
        }
    }
}