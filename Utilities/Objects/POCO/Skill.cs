using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Objects.POCO
{
    public class Skill : IPOCO
    {
        public int? BusNo { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MediaTypeId { get; set; }

        public int CampaignId;
        public MediaTypes.MediaType MediaType;
        public int Interruptible;
        public bool Outbound;
        public string CallerIdNumber;
        public string FromEmailAddress;
        public string FromEmailAddressDomain;
        public string Notes;
        public int? CustomScriptId;
        public bool IsDialer;
        public bool EnableBlending;
        public string BccEmailAddress;
        public bool IsNaturalCalling;
        public int SLAThreshold;
        public int SLAGoal;
        public bool IsActive;
        public bool Dispositions;
        public bool UseAcw;
        public int AcwTimer;
        public int AcwState;
        public bool UseDispositions;
        public bool UseSecondaryDispositions;
        public bool RequireDispositions;
        public string ChatThankMessage;
        public bool DisplayChatThankPage;
        public bool CanDownloadChatTranscript;
        public string ChatFromAddress;
        public string ChatThankPopUrl;
        public bool UseChatThankPopUrl;
        public bool DispositionsByScripting;
        public int? WFIMinimumAgents;
        public int? WFIMinimumAvailableAgents;
        public int InitialPriority;
        public int Acceleration;
        public int MaximumPriority;
        public int ShortAbandonThreshold;
        public int MinimumWorkingTime;
        public bool AgentOverriteBadNumber;
        public bool TreatProgressAsRinging;
        public bool PreConnectCpaEnabled;
        public bool AgentOrerrideFax;
        public bool AgentAnsweringMachine;
        public string CampaignName;
        public string Phonecall;
        public string EnableChatMessagingTimeout;
        public int TimetoinactiveChatMessage;
        public string ChatTerminatedMessage;
        public string InactiveChatMessage;
        public int ChatTerminationCountDown;
        public bool IsSmsTrasportCode;

        public override string ToString()
        {
            return string.Format("BusNo: {0} -- Id: {1} -- CampaignId: {2}", BusNo, Id, CampaignId);
        }
    }
}