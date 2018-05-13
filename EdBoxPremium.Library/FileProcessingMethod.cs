using EdBoxPremium.Library.Dictionary;

namespace EdBoxPremium.Library
{
    public enum FileProcessingMethod : int
    {
        [EnumDisplayName(DisplayName = "EdBox Premium Format")]
        EdBoxPre = 1,
        [EnumDisplayName(DisplayName = "School Custom")]
        SchoolCustom
    }
}
