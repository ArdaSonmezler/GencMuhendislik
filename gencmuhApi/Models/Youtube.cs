namespace gencmuhApi.Models
{
    public class Youtube
    {
        public int Id { get; set;}
        private string _linkTitle = string.Empty;
        public string LinkTitle 
        {  
            get => _linkTitle;
            set => _linkTitle = value ?? throw new ArgumentNullException(nameof(value), "LinkTitle cannot be null");
        } 
        private string _url = string.Empty;
        public string Url 
        {  
            get => _url;
            set => _url = value ?? throw new ArgumentNullException(nameof(value), "Url cannot be null");
        } 
    }
}