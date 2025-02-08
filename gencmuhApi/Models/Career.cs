namespace gencmuhApi.Models
{
    public class Career
    {
        public int Id { get; set; }
        private string _applicantName { get; set; } = string.Empty;
        public string ApplicantName 
        {  
            get => _applicantName;
            set => _applicantName = value ?? throw new ArgumentNullException(nameof(value), "ApplicantName cannot be null");
        } 
        private string _applicantSurname { get; set; } = string.Empty;
        public string ApplicantSurname 
        {  
            get => _applicantSurname;
            set => _applicantSurname = value ?? throw new ArgumentNullException(nameof(value), "ApplicantSurname cannot be null");
        } 

        public string _applicantPhone { get; set; } = string.Empty;
        public string ApplicantPhone 
        {  
            get => _applicantPhone;
            set => _applicantPhone = value ?? throw new ArgumentNullException(nameof(value), "ApplicantPhone cannot be null");
        } 

        public string _applicantMail { get; set; } = string.Empty;
        public string ApplicantMail 
        {  
            get => _applicantMail;
            set => _applicantMail = value ?? throw new ArgumentNullException(nameof(value), "ApplicantMail cannot be null");
        } 
        public string _applicantFile { get; set; } = string.Empty;
        public string ApplicantFile 
        {  
            get => _applicantFile;
            set => _applicantFile = value ?? throw new ArgumentNullException(nameof(value), "ApplicantFile cannot be null");
        } 

        public DateTime SendDate { get; set; }
    }
}