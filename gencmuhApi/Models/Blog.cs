namespace gencmuhApi.Models
{
    public class Blog
    {
        public int Id { get; set; }
        private string _title = string.Empty;
        public string Title 
        {  
            get => _title;
            set => _title = value ?? throw new ArgumentNullException(nameof(value), "Title cannot be null");
        } 
        private string _content = string.Empty;
        public string Content 
        {  
            get => _content;
            set => _content = value ?? throw new ArgumentNullException(nameof(value), "Content cannot be null");
        } 
        private string _language = string.Empty;
        public string Language 
        {  
            get => _language;
            set => _language = value ?? throw new ArgumentNullException(nameof(value), "Language cannot be null");
        } 
        private string _image = string.Empty;
        public string Image 
        {  
            get => _image;
            set => _image = value ?? throw new ArgumentNullException(nameof(value), "Image cannot be null");
        }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        private string _seoDesc = string.Empty;
        public string SeoDesc 
        {  
            get => _seoDesc;
            set => _seoDesc = value ?? throw new ArgumentNullException(nameof(value), "SeoDesc cannot be null");
        }
        private string _status = string.Empty;
        public string Status 
        {  
            get => _status;
            set => _status = value ?? throw new ArgumentNullException(nameof(value), "Status cannot be null");
        }
    }
}