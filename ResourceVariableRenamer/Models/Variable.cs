namespace ResourceVariableRenamer.Models
{
    public class Variable
    {
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public string originalValue { get; set; }
        public string? newValue { get; set; }

        public Variable(int startIndex, int endIndex, string value)
        {
            StartIndex = startIndex;
            EndIndex = endIndex;
            originalValue = value;
        }
    }
}
