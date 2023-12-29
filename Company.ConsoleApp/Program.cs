using Company.Business.Services;
using Company.Business.Utilities.Helpers;
using Company.DataAccess.Contexts;

Console.WriteLine("Hello, World!");
CompanyService companyService = new CompanyService();
DepartmentService departmentService = new DepartmentService();
EmployeeService employeeService = new EmployeeService();

bool isContinue = true;
while (isContinue)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1 - Create Company \n" +
                      "2 - Show All Company \n" +
                      "3 - Activated Company \n" +
                      "4 - Delete Company \n" +
                      "5 - Get By Name Company\n" +
                      "6 - Create Department \n" +
                      "7 - Show All Department \n" +
                      "8 - Create Employee \n" +
                      "0 - Exit");

    string? option = Console.ReadLine();
    int optionNumber;
    bool isInt=int.TryParse(option, out optionNumber);
    if (isInt)
    {
        if (optionNumber >= 0 && optionNumber <= 15)
        {
            switch (optionNumber) 
            {
                case (int)Menu.CreateCompany:
                    try
                    {
                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        Console.WriteLine("Enter Company Description:");
                        string? companyDesc = Console.ReadLine();
                        companyService.Create(companyName, companyDesc);
                        Console.WriteLine("was created");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case (int)Menu.CreateCompany;
                    }
                    break;
                case (int)Menu.ShowAllCompany:
                    Console.WriteLine("All Company:");
                    if (companyService.IsCompanyExist() == false)
                    {
                        Console.WriteLine("No Company ");
                    }
                    companyService.ShowAll();
                    break;
                case (int)Menu.ActivatedCompany:
                    if (companyService.IsCompanyExist() == false)
                    {
                        Console.WriteLine("No Company ");
                    }
                    try
                    {
                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        companyService.Activated(companyName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                 case (int)Menu.DeleteCompany:
                    if (companyService.IsCompanyExist() == false)
                    {
                        Console.WriteLine("No Company ");
                    }
                    try
                    {
                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        companyService.Delete(companyName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.GetByNameCompany:
                    try
                    {
                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        companyService.GetCompany(companyName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.CreateDepartment:
                    if (companyService.IsCompanyExist() == false)
                    {
                        Console.WriteLine("There is no company, create a company twice and then come ");
                        goto case (int)Menu.CreateCompany;
                    }
                    try
                    {
                        Console.WriteLine("Enter Department Name:");
                        string? departmentName = Console.ReadLine();
                        Console.WriteLine("Enter Department Employee Limit:");
                        int employeeLimit = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("-------------------");
                        companyService.ShowAll();
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Enter Company Name:");
                        string? companyName2 = Console.ReadLine();
                        departmentService.Create(departmentName, employeeLimit, companyName2);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case (int)Menu.CreateDepartment;
                    }
                    break;
                case (int)Menu.ShowAllDepartment:
                    Console.WriteLine("All Department:");
                    departmentService.ShowAll();
                    break;
                case 8:
                    break;
                default:
                    isContinue=false;
                    break;

            }
        }
        else
        {
            Console.WriteLine("Please enter correct option number!!!");
        }
    }
    else 
    {
        Console.WriteLine("Please enter correct format!!!");
    }
}

