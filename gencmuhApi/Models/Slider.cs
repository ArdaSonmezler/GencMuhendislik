namespace gencmuhApi.Models
{
    public class Slider
    {
        public int Id { get; set; }
        private string _sliderTitle = string.Empty;
        public string SliderTitle 
        {  
            get => _sliderTitle;
            set => _sliderTitle = value ?? throw new ArgumentNullException(nameof(value), "SliderTitle cannot be null");
        } 
        private string _sliderImage = string.Empty;
        public string SliderImage 
        {  
            get => _sliderImage;
            set => _sliderImage = value ?? throw new ArgumentNullException(nameof(value), "SliderImage cannot be null");
        } 
        private string _language = string.Empty;
        public string Language 
        {  
            get => _language;
            set => _language = value ?? throw new ArgumentNullException(nameof(value), "Language cannot be null");
        }
        public int SliderNumber { get; set; }

    }
}