namespace ResourceVariableRenamer.Models
{
    public class ResourceLanguage
    {
        public Dictionary<string, ResourceString> resource { get; set; }
        public string Language { get; set; }

        public ResourceLanguage(string language)
        {
            Language = language;
            resource = new();
        }
    }
}
