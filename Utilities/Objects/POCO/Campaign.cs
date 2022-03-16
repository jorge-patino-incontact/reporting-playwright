namespace Utilities.Objects.POCO
{
    public class Campaign : IPOCO
    {
        public int Id { get; set; }
        public int? BusNo { get; set; }
        public string Name { get; set; }
        public string Description;
        public bool IsActive;
        public string Notes;

        public override string ToString()
        {
            return string.Format("BusNo: {0} -- Id: {1} -- Name: {2}", BusNo, Id, Name);
        }
    }
}
