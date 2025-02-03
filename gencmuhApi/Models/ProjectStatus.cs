

namespace gencmuhApi.Models
{
    public class ProjectStatus
    {
        public int ProjectStatusID { get; set; }
        public string ProjectStatusName { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}