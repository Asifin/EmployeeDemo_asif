using EmployeeWeb.Model;

namespace EmployeeWeb.Repo
{
    public interface IEmployeeRepo
    {
        Task<List<EmployeeModel>> GetAll();
        Task<EmployeeModel> GetById(string EmpID);
        Task<string> Create (EmployeeModel employee);
        Task <string> Update (EmployeeModel employee, string EmpId);
        Task <string> Delete (string EmpID);

       

    }
}
