namespace gencmuhApi.Models
{
    public class ImageCategory
    {
        public ImageCategory()
        {
            Images = new List<Image>();
        }
        public int Id { get; set; }
        private string _categoryName = string.Empty;
        public string CategoryName 
        {  
            get => _categoryName;
            set => _categoryName = value ?? throw new ArgumentNullException(nameof(value), "CategoryName cannot be null");
        }
        private string _categoryStatus = string.Empty;
        public string CategoryStatus
        {  
            get => _categoryStatus;
            set => _categoryStatus = value ?? throw new ArgumentNullException(nameof(value), "CategoryStatus cannot be null");
        }

        //Image sınıfı ile ilişkisi için gerekli
        public ICollection<Image> Images { get; set; }
    }
}