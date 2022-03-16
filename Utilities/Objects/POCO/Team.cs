using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Objects.POCO
{
    public class Team : IPOCO
    {
        public int? BusNo { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes;
        public string Description;
        public bool IsActive;
        public bool WfmEnabled;
        public bool QmEnabled;
        public bool WfoEnabled;
        public bool IwfmEnabled;
        public bool MchEnabled;
        public int MaxChat;
        public int MaxWorkItem;
        public bool RTAEnabled;        

        public override string ToString()
        {
            return string.Format("BusNo: {0} -- Id: {1} -- Name: {2}", BusNo, Id, Name);
        }
    }
}
