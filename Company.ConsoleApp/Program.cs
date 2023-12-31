using Company.Business.Services;
using Company.Business.Utilities.Helpers;
using System;

Console.WriteLine("    __  ______     ____  ____  ____      ____________________\r\n   / / / / __ \\   / __ \\/ __ \\/ __ \\    / / ____/ ____/_  __/\r\n  / /_/ / /_/ /  / /_/ / /_/ / / / __  / / __/ / /     / /   \r\n / __  / _, _/  / ____/ _, _/ /_/ / /_/ / /___/ /___  / /    \r\n/_/ /_/_/ |_|  /_/   /_/ |_|\\____/\\____/_____/\\____/ /_/     \r\n                                                             ");
CompanyService companyService = new CompanyService();
DepartmentService departmentService = new DepartmentService();
EmployeeService employeeService = new EmployeeService();

bool isContinue = true;
while (isContinue)
{
    
    Console.WriteLine("Menu:");
    Console.WriteLine("1 - Create Company \n" +
                      "2 - Show All Company \n" +
                      "3 - Activate Company \n" +
                      "4 - Delete Company \n" +
                      "5 - Get By Name Company\n" +

                      "------------------------\n" +

                      "6 - Create Department \n" +
                      "7 - Get All Department \n" +
                      "8 - Activate Department \n" +
                      "9 - Delete Department \n" +
                      "10 - Get Department Employees \n" +

                      "-------------------------\n" +

                      "11 - Create Employee \n" +
                      "12 - Show All Employee \n" +

                      "-------------------------\n" +
                      "13 - Get Company \n" +
                      "14 - Move Employee \n" +
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
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        Console.WriteLine("Enter Company Description:");
                        string? companyDesc = Console.ReadLine();
                        Console.WriteLine("---------------------");
                        companyService.Create(companyName, companyDesc);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("was created");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case (int)Menu.CreateCompany;
                    }
                    break;
                case (int)Menu.ShowAllCompany:
                    Console.WriteLine("---------------------");
                    Console.WriteLine("All Company:");
                    if (companyService.IsCompanyExist() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No Company ");
                        Console.ResetColor();
                    }
                    companyService.ShowAll();
                    break;
                case (int)Menu.ActivatedCompany:
                    if (companyService.IsCompanyExist() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No Company ");
                        Console.ResetColor();
                    }
                    try
                    {
                        Console.WriteLine("---------------------");
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No Company ");
                        Console.ResetColor();
                    }
                    try
                    {
                        Console.WriteLine("---------------------");
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
                        Console.WriteLine("---------------------");
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There is no company, create a company twice and then come ");
                        Console.ResetColor();
                        goto case (int)Menu.CreateCompany;
                    }
                    try
                    {
                        Console.WriteLine("---------------------");
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
                case (int)Menu.GetAllDepartment:
                    if (departmentService.isDepartmentExist() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("not Department is exist");
                        Console.ResetColor();
                        goto case (int)Menu.CreateDepartment;
                    }
                    Console.WriteLine("---------------------");
                    Console.WriteLine("All Department:");
                    departmentService.GetAllDepartment();
                    break;

                case (int)Menu.ActivateDepartment:
                    try
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Enter Department Name:");
                        string? departmentName = Console.ReadLine();
                        departmentService.Activete(departmentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)Menu.DeleteDepartment:
                    try
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Enter Department Name:");
                        string? departmentName = Console.ReadLine();
                        departmentService.Delete(departmentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)Menu.GetDepartmentEmployees:
                    try
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Enter Department Name:");
                        string? departmentName = Console.ReadLine();
                        departmentService.GetDepartmentEmployees(departmentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)Menu.CreateEmployee:
                    try
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Enter Employee Name:");
                        string? employeeName = Console.ReadLine();
                        Console.WriteLine("Enter Employee Surname:");
                        string? employeeSurname = Console.ReadLine();
                        Console.WriteLine("Enter Employee Email:");
                        string? employeeEmail = Console.ReadLine();
                        Console.WriteLine("Enter Employee Phone Number:");
                        string employeePhoneNumber = Console.ReadLine();
                        Console.WriteLine("Enter Employee Salary:");
                        int employeeSalary = Convert.ToInt32( Console.ReadLine());
                        Console.WriteLine("------------------");
                        departmentService.GetAllDepartment();
                        Console.WriteLine("------------------");
                        Console.WriteLine("Enter Department Name:");
                        string? departmentName = Console.ReadLine();
                        employeeService.Create(employeeName, employeeSurname, employeeEmail, employeePhoneNumber, employeeSalary, departmentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)Menu.ShowAllEmployee:
                    Console.WriteLine("---------------------");
                    Console.WriteLine("All Employee:");
                    Console.WriteLine("---------------------");
                    employeeService.ShowAll();
                    Console.WriteLine("---------------------");
                    break;

                case (int)Menu.getCompany:
                    try
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        companyService.GetCompany(companyName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.moveEmployee:
                    try
                    {
                        Console.WriteLine("-----------------------------");
                        employeeService.ShowAll();
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Enter Employee ID");
                        int employeeId = Convert.ToInt32( Console.ReadLine());
                        Console.WriteLine("-----------------------------");
                        departmentService.GetAllDepartment();
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Enter Department Name:");
                        string? departmentName = Console.ReadLine();
                        employeeService.ChangeDepartment(employeeId, departmentName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;


                default:
                    isContinue=false;
                    break;

            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter correct option number!!!");
            Console.ResetColor();
        }
    }
    else 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please enter correct format!!!");
        Console.ResetColor();
    }
}

