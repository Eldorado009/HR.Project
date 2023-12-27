namespace Company.Business.Interfaces;

public interface ICompanyService
{
    void Create(string? name, string description);
    void Delete(string name);
    void Activated(string name, bool isActive = false);

    void GetAllDepartment(string departmentName);
    Company.Core.Entities.Company GetCompany(int Id);
    void GetDepartmentIncluded();
    Company.Core.Entities.Company? FindCompanyByName(string name);

}
