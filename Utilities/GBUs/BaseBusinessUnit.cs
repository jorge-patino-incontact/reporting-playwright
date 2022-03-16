using System;
using System.Collections.Generic;
using Utilities.Objects.POCO;

namespace Utilities.GBUs
{
    public abstract class BaseBusinessUnit
    {
        #region Variables

        public Dictionary<Enum, Agent> Agent { get; set; }
        public Dictionary<Enum, Team> Team { get; set; }
        public Dictionary<Enum, Campaign> Campaign { get; set; }
        public Dictionary<Enum, Skill> Skill { get; set; }
        public Dictionary<Enum, Script> Script { get; set; }
        public Dictionary<Enum, PointOfContact> PointOfContact { get; set; }
        protected string ClusterName;
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }

        #endregion

        public enum Agents
        {
            Administrator01,
            Manager01,
            Agent01,
            Agent02
        }
        public enum Campaigns
        {
            Campaign
        }

        public enum PointOfContacts
        {
            IBEmail,
            Chat,
            WorkItem,
            Phone
        }

        public enum Scripts
        {
            Chat,
            Email,
            SpawnInboundCall,
            VoiceMail,
            WorkItem
        }

        public enum Skills
        {
            IBPhone,
            OBPhone,
            PcPhone,
            IBEmail,
            OBEmail,
            Chat,
            WorkItem,
            VoiceMail
        }

        public enum Teams
        {
            Team
        }

        public BaseBusinessUnit(string clusterName)
        {
            ClusterName = clusterName;
            GenerateGuaranteedObjectNames();
            GetSpecificTestRunInfo();
        }

        public abstract void GetSpecificTestRunInfo();

        private void GenerateGuaranteedObjectNames()
        {
            Team = new Dictionary<Enum, Team>
            {
                { Teams.Team, new Team { Name = nameof(Teams.Team) } }
            };
            Campaign = new Dictionary<Enum, Campaign>
            {
                { Campaigns.Campaign, new Campaign { Name = nameof(Campaigns.Campaign) } },
            };
            Skill = new Dictionary<Enum, Skill>
            {
                { Skills.IBPhone,   new Skill { Name = nameof(Skills.IBPhone) } },
                { Skills.OBPhone,   new Skill { Name = nameof(Skills.OBPhone) } },
                { Skills.PcPhone,   new Skill { Name = nameof(Skills.PcPhone) } },
                { Skills.IBEmail,   new Skill { Name = nameof(Skills.IBEmail) } },
                { Skills.OBEmail,   new Skill { Name = nameof(Skills.OBEmail) } },
                { Skills.Chat,      new Skill { Name = nameof(Skills.Chat) } },
                { Skills.WorkItem,  new Skill { Name = nameof(Skills.WorkItem) } },
                { Skills.VoiceMail, new Skill { Name = nameof(Skills.VoiceMail) } }
            };
            Script = new Dictionary<Enum, Script>
            {
                { Scripts.Email,            new Script { Name = nameof(Scripts.Email) } },
                { Scripts.Chat,             new Script { Name = nameof(Scripts.Chat) } },
                { Scripts.WorkItem,         new Script { Name = nameof(Scripts.WorkItem) } },
                { Scripts.SpawnInboundCall, new Script { Name = nameof(Scripts.SpawnInboundCall) } }
            };
            PointOfContact = new Dictionary<Enum, PointOfContact>
            {
                { PointOfContacts.IBEmail,  new PointOfContact { Name = nameof(PointOfContacts.IBEmail) } },
                { PointOfContacts.Chat,     new PointOfContact { Name = nameof(PointOfContacts.Chat) } },
                { PointOfContacts.WorkItem, new PointOfContact { Name = nameof(PointOfContacts.WorkItem) } },
                { PointOfContacts.Phone,    new PointOfContact { Name = nameof(PointOfContacts.Phone) } }
            };
        }
    }
}
