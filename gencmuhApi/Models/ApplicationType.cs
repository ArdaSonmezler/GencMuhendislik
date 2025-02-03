

namespace gencmuhApi.Models
{
    public class ApplicationType
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeName { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}