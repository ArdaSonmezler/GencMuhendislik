

namespace gencmuhApi.Context
{
    public class ProjectStatus
    {
        public int ProjectStatusID { get; set; }
        public string ProjectStatusName { get; set; }

        public ICollection<Projects> Projects { get; set; }
    }
}