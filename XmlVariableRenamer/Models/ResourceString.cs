namespace ResourceVariableRenamer.Models
{
    public class ResourceString
    {
        public string Value { get; set; }
        public List<Variable> Variables { get; set; } = new List<Variable>();

        public ResourceString(string? value)
        {
            Value = value ?? String.Empty;
            Variables = SetVariables();
        }

        public void ChangeValueForNewVariables()
        {
            for (int i = Variables.Count - 1; i >= 0; i--)
            {
                Value = Value.Replace("{" + Variables[i].originalValue + "}", "{" + Variables[i].newValue + "}");
            }
        }

        private List<Variable> SetVariables()
        {
            const char open = '{', close = '}';
            bool isOpen = true;
            bool isDouble = false;

            var list = new List<Variable>();

            if (!Value.Contains(open))
            {
                return list;
            }

            var startIndex = 0;
            for (int i = 0; i < Value.Length; i++)
            {
                if (isOpen && Value[i] == open)
                {
                    if (Value[i + 1] == open)
                    {
                        startIndex = i + 2;
                        i++;
                        isOpen = false;
                        isDouble = true;
                    }
                    else
                    {
                        startIndex = i + 1;
                        isOpen = false;
                        isDouble = false;
                    }

                }
                else if (!isOpen && Value[i] == close)
                {
                    var endIndex = i - startIndex;
                    list.Add(new(startIndex, i - 1, Value.Substring(startIndex, endIndex)));
                    if (isDouble)
                    {
                        i++;
                    }
                    isOpen = true;
                }
            }
            return list;
        }
    }
}
