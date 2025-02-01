namespace gencmuhApi.Models
{
    public class Image
    {
        public Image()
        {
            ImageCategory = new ImageCategory();
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        private string _imageName = string.Empty;
        public string ImageName 
        {  
            get => _imageName;
            set => _imageName = value ?? throw new ArgumentNullException(nameof(value), "ImageName cannot be null");
        } 
        private string _imageUrl = string.Empty;
        public string ImageUrl 
        {  
            get => _imageUrl;
            set => _imageUrl = value ?? throw new ArgumentNullException(nameof(value), "ImageUrl cannot be null");
        } 
        private string _imageStatus = string.Empty;
        public string ImageStatus 
        {  
            get => _imageStatus;
            set => _imageStatus = value ?? throw new ArgumentNullException(nameof(value), "ImageStatus cannot be null");
        } 
        public ImageCategory ImageCategory {get;set;}
    }
}