namespace TODO.Utils.GlobalConstants
{
    public class Constants
    {
        //Regex patterns
        // A regex to check if a string contains only letters, numbers and underscore

        public const string RegexNamePattern = @"^[a-zA-Z0-9_]+$";

        public const int MinUserLength = 3;

        public const string PathToDatabase = "../../../../Database";
        public static readonly string[] Formats = new string[] {"dd.MM.yyyy.HH.mm", "HH.mm.dd.MM.yyyy",
        "dd-MM-yyyy-HH-mm", "HH-mm-dd-MM-yyyy","dd/MM/yyyy/HH/mm", "HH/mm/dd/MM/yyyy",
        "dd MM yyyy HH mm", "HH mm dd MM yyyy","dd|MM|yyyy|HH|mm", "HH|mm|dd|MM|yyyy",
        "dd.MM.yyyy", "dd.MM.yyyy",
        "dd-MM-yyyy", "dd-MM-yyyy","dd/MM/yyyy", "dd/MM/yyyy",
        "dd MM yyyy", "dd MM yyyy","dd|MM|yyyy", "dd|MM|yyyy"};

        public const string EmptyOrNullList = "List cannot be null or empty";
        public const string EmptyCollection = "This collection is currently empty or null";
    }
}
