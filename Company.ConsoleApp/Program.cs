using Company.Business.Services;

Console.WriteLine("Hello, World!");
CompanyService companyService = new CompanyService();
DepartmentService departmentService = new DepartmentService();
EmployeeService employeeService = new EmployeeService();

companyService.Create("Furniture", "Hem yumusaq, Hem komfortlu");
companyService.Create("Amazon", "En dogru secim ve en tez catdiran");
companyService.Create("Socar", "....");
companyService.GetDepartmentIncluded();

departmentService.Create("gozeller", 5, "Furniture");
Console.WriteLine("All Department:");
departmentService.ShowAll();

employeeService.Create("Eldar", "Akhmedov", "eldar@code.edu.az", "+994555005550", 300, 0, "gozeller");
employeeService.Create("Eldar", "Akhmedov", "eldar@code.edu.az", "+994555005550", 300, 0, "gozeller");
employeeService.Create("Eldar", "Akhmedov", "eldar@code.edu.az", "+994555005550", 300, 0, "gozeller");
employeeService.Create("Eldar", "Akhmedov", "eldar@code.edu.az", "+994555005550", 300, 0, "gozeller");
employeeService.Create("Eldar", "Akhmedov", "eldar@code.edu.az", "+994555005550", 300, 0, "gozeller");
employeeService.Create("Eldar", "Akhmedov", "eldar@code.edu.az", "+994555005550", 300, 0, "gozeller");

