namespace Utilities.Objects.API
{
    public class DataDownloadReport
    {
        public string errorMessage { get; set; }
        public string fileName { get; set; }
        public string file { get; set; }
        public string fileType { get; set; }
        public string URI { get; set; }
    }

    public class DataDownloadReportBody
    {
        public string saveAsFile { get; set; }
        public string fileName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string includeHeaders { get; set; }
    }
}