using Dapper;
using EmployeeWeb.Model;
using EmployeeWeb.Model.Data;
using System.Data;

namespace EmployeeWeb.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DapperDbContext dbContext;
        public EmployeeRepo(DapperDbContext context) 
        {
            this.dbContext = context;
        }

        public async Task<string> Create(EmployeeModel employee)
        {
            string response = string.Empty;
            string query = "insert into  employee (Name,Gender,Designation,Salary) values" +
                "(@Name,@Gender,@Designation,@Salary)";

            var parameters = new DynamicParameters();
           
            parameters.Add("Name", employee.Name, DbType.String);
            parameters.Add("Gender", employee.Gender, DbType.String);
            parameters.Add("Designation", employee.Designation, DbType.String);
            parameters.Add("Salary", employee.Salary, DbType.String);

            using (var connectin = this.dbContext.CreateConnection())
            {
                var emplist = await connectin.ExecuteAsync(query, parameters);
                response = "Pass";
            }
            return response;
        }

        public async Task<string> Delete(string EmpID)
        {
            string response = string.Empty;
            string query = "delete from employee where EmpID=@EmpID";
            using (var connectin = this.dbContext.CreateConnection())
            {
                var emplist = await connectin.ExecuteAsync(query, new { EmpID });
                response = "Pass";
            }
            return response;
        }

        public async Task<List<EmployeeModel>> GetAll()
        {
            string query = "select * from employee";
            using (var connectin =this.dbContext.CreateConnection()) 
            {
                var emplist = await connectin.QueryAsync<EmployeeModel>(query);
                return emplist.ToList();
            }
           
        }

        public async Task<EmployeeModel> GetById(string EmpID)
        {
            string query = "select * from employee where EmpID=@EmpID";
            using (var connectin = this.dbContext.CreateConnection())
            {
                var emplist = await connectin.QueryFirstOrDefaultAsync<EmployeeModel>(query,new { EmpID });
                return emplist;
            }
        }

        public async  Task<string> Update(EmployeeModel employee, string EmpId)
        {
            string response = string.Empty;
            string query = "update employee set Name=@Name,Gender=@Gender," +
                "Designation=@Designation,Salary=@Salary where EmpID=@EmpID";              

            var parameters = new DynamicParameters();

            parameters.Add("EmpID", employee.EmpID, DbType.String);
            parameters.Add("Name", employee.Name, DbType.String);
            parameters.Add("Gender", employee.Gender, DbType.String);
            parameters.Add("Designation", employee.Designation, DbType.String);
            parameters.Add("Salary", employee.Salary, DbType.Int32);

            using (var connectin = this.dbContext.CreateConnection())
            {
                var emplist = await connectin.ExecuteAsync(query, parameters);
                response = "Pass";
            }
            return response;
        }
    }
}
