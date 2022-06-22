using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Resources;
using ResourceVariableRenamer;

List<string> languages = new() { "nl", "en", "de", "pl" };
string languageToChangeTo = "nl";

ResourceManager myResourceClass = new ResourceManager("Labels.resx", Assembly.GetAssembly(typeof(Program)));

ResourceSet resourceSet = myResourceClass.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

var languageManager = new LanguageManager(languages);

foreach (DictionaryEntry entry in resourceSet)
{
    languageManager.PutInCorrectResource(entry);
}
languageManager.ChangeVariables(languageToChangeTo);

using var resourceWriter = new ResourceWriter("newLabels.resx");

foreach (var language in languageManager.Languages)
{
    foreach (var resource in language.resource)
    {
        resourceWriter.AddResource(resource.Key + language.Language, resource.Value.Value);
    }
}

Console.ReadLine();