namespace LabourCommissioner.Common
{
    public class CouchDBResponse
    {
        public bool IsSuccess { get; set; }
        public string Id { get; set; }
        public string Rev { get; set; }
        public string Result { get; set; }
        public Task<byte[]> ImageData { get; set; }
    }
}
