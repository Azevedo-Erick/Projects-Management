namespace ProjectsManagement.Common;

public static class EventIds
{
    public static readonly EventId DatabaseError = new(1001, "DatabaseError");
    public static readonly EventId ExceptionOccurred = new(1002, "ExceptionOccurred");
}
