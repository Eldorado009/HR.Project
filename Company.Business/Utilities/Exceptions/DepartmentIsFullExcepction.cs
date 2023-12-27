namespace Company.Business.Utilities.Exceptions;

public class DepartmentIsFullExcepction:Exception
{
    public DepartmentIsFullExcepction(string message) : base(message) 
    {
    
    }
}
