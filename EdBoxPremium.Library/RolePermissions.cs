using EdBoxPremium.Library.Dictionary;

namespace EdBoxPremium.Library
{
    public enum RolePermissions : int
    {
        [EnumDisplayName(DisplayName = "Web Administrator")]
        WebAdministrator = 1,
        [EnumDisplayName(DisplayName = "Local Administrator")]
        LocalAdministrator,
        [EnumDisplayName(DisplayName = "Attendance Operative")]
        AttendanceOpr,
        [EnumDisplayName(DisplayName = "Verification Operative")]
        VerificationOpr,
        [EnumDisplayName(DisplayName = "Tag Operative")]
        TagOpr,
        [EnumDisplayName(DisplayName = "Registration Operative")]
        RegOpr
    }
}
