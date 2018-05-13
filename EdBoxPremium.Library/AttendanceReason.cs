using EdBoxPremium.Library.Dictionary;

namespace EdBoxPremium.Library
{
    public enum AttendanceReason : int
    {
        [EnumDisplayName(DisplayName = "Exam Attendance")]
        ExamAttendance = 1,
        [EnumDisplayName(DisplayName = "Class Attendance")]
        ClassAttendance,
        [EnumDisplayName(DisplayName = "Quick Attendance")]
        QuickAttendance
    }
}
