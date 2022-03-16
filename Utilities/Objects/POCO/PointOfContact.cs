namespace Utilities.Objects.POCO
{
    public class PointOfContact : IPOCO
    {
        public int? BusNo { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public MediaTypes.MediaType MediaType;
        public string Dnis;
        public string SkillName;
        public string ScriptName;
        public bool IvrReportingEnabled;
        public bool BusinessContinuityDoNothing;
        public bool BusinessContinuityPlayMessage;
        public bool BusinessContinuityForward;
        public string BusinessContinuityPhoneNumber;
        public string PathToLogo;
        public string ChatProfileName;
        public string PointOfContactEmail;
        public string ChatAddress;

        public override string ToString()
        {
            return string.Format("BusNo: {0} -- Id: {1} -- Name: {2}", BusNo, Id, Name);
        }
    }
}
