
namespace Utilities.Objects.POCO
{
    public class Script : IPOCO
    {
        public int Id { get; set; }
        public int? BusNo { get; set; }
        public string Name { get; set; }
        public MediaTypes.MediaType MediaType;
        public string Path;
        public bool IsActive;
        public string ScriptType;
        public bool Reserved;
        public bool Hidden;
        public bool ReadOnly;
        public string ScriptDirectory;

        public override string ToString()
        {
            return string.Format("BusNo: {0} -- Id: {1} -- MediaType: {2}", BusNo, Id, MediaType);
        }
    }
}
