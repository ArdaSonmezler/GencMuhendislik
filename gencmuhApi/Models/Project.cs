

namespace gencmuhApi.Models
{
    public class Project
    {
        public int ID { get; set; }
        public int projectStatusID { get; set; }
        public int applicationID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Language { get; set; }
        public string EmployeerName { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string SEO_Description { get; set; }
        public string Status { get; set; }

        public ProjectStatus ProjectStatus { get; set; }
        public ApplicationType ApplicationType { get; set; }

    }


}