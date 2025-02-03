

namespace gencmuhApi.Context
{
    public class ApplicationType
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeName { get; set; }

        public ICollection<Projects> Projects { get; set; }
    }
}