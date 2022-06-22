using ResourceVariableRenamer.Models;
using System.Collections;

namespace ResourceVariableRenamer
{
    public class LanguageManager
    {
        public List<ResourceLanguage> Languages { get; set; } = new();

        public LanguageManager(List<string> languages)
        {
            foreach (var language in languages)
            {
                Languages.Add(new ResourceLanguage(language));
            }
        }

        public void PutInCorrectResource(DictionaryEntry entry)
        {
            var entryKey = entry.Key.ToString();
            var entryValue = entry.Value?.ToString();

            var resourceString = new ResourceString(entryValue);

            var language = entryKey?.Substring(entryKey.Length - 2);

            var resource = GetLanguage(language);
            if (resource is null)
            {
                Console.WriteLine($"skipped Resource. Reason= Could not find correct language.{Environment.NewLine}" +
                                  $"Language Two letter iso: {language},{Environment.NewLine}" +
                                  $"Resource Key: {entryKey},{Environment.NewLine}" +
                                  $"Resource String: {resourceString}{Environment.NewLine}");
                return;
            }
            entryKey = entryKey!.Substring(0, entryKey.Length - 2);

            resource.resource.Add(entryKey, resourceString);
        }

        public void ChangeVariables(string languageToChangeTo)
        {
            ResourceLanguage? resourceToChangeFrom = GetLanguage(languageToChangeTo);

            if (resourceToChangeFrom is null)
            {
                throw new ArgumentException($"Unknown language to change to could not find language in resources and was: {languageToChangeTo}");
            }

            foreach (var resource in resourceToChangeFrom.resource)
            {
                if (resource.Value.Variables.Count == 0)
                {
                    continue;
                }
                for (int i = 0; i < resource.Value.Variables.Count; i++)
                {
                    string dutchVariable = resource.Value.Variables[i].originalValue;

                    foreach (var lang in Languages)
                    {
                        lang.resource[resource.Key].Variables[i].newValue = dutchVariable;
                    }
                }
                foreach (var lang in Languages)
                {
                    lang.resource[resource.Key].ChangeValueForNewVariables();
                }
            }
        }

        private ResourceLanguage? GetLanguage(string? languageToChangeTo)
        {
            if (languageToChangeTo is null)
            {
                return null;
            }
            return Languages.Where(x => x.Language == languageToChangeTo).FirstOrDefault();
        }
    }
}
