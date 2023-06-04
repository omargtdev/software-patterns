using LayeredApp.DataAccess.Contracts;
using LayeredApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredApp.DataAccess.Repositories
{
    public class EmployeeRepository : MasterRepository, IEmployeeRepository
    {
        #region Fields
        private readonly string _selectAllQuery;
        private readonly string _insertQuery;
        private readonly string _updateQuery;
        private readonly string _deleteQuery;
        #endregion

        #region Properties

        #endregion

        #region Constructors
        public EmployeeRepository()
        {
            _selectAllQuery = "SELECT * FROM Employee";
            _insertQuery = "INSERT INTO Employee VALUES (@number, @name, @email, @birthday)";
            _updateQuery = "UPDATE Employee SET Number = @number, Name = @name, Mail = @email, Birthday = @birthday WHERE EmployeeID = @id";
            _deleteQuery = "DELETE FROM Employee WHERE EmployeeID = @id";
        }
        #endregion

        #region Methods
        public int Add(Employee entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@number", entity.Number));
            parameters.Add(new SqlParameter("@name", entity.Name));
            parameters.Add(new SqlParameter("@email", entity.Mail));
            parameters.Add(new SqlParameter("@birthday", entity.Birthday));

            return ExecuteNonQuery(_insertQuery);

        }

        public int Edit(Employee entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", entity.EmployeeID));
            parameters.Add(new SqlParameter("@number", entity.Number));
            parameters.Add(new SqlParameter("@name", entity.Name));
            parameters.Add(new SqlParameter("@email", entity.Mail));
            parameters.Add(new SqlParameter("@birthday", entity.Birthday));

            return ExecuteNonQuery(_updateQuery);
        }

        public IEnumerable<Employee> GetAll()
        {
            var tableResult = ExecuteReader(_selectAllQuery);
            var employeesList = new List<Employee>();
            foreach (DataRow row in tableResult.Rows)
                employeesList.Add(new Employee 
                {
                    EmployeeID = Convert.ToInt32(row[0]),
                    Number = row[1].ToString(),
                    Name = row[2].ToString(),
                    Mail = row[3].ToString(),
                    Birthday = Convert.ToDateTime(row[4])
                });

            return employeesList;
        }

        public IEnumerable<Employee> GetBirthdayRange(DateTime startDate, DateTime endDate)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@startDate", startDate));
            parameters.Add(new SqlParameter("@endDate", endDate));

            var tableResult = ExecuteReader("usp_ListEmployeeByBirthday", CommandType.StoredProcedure);
            var employeesList = new List<Employee>();
            foreach (DataRow row in tableResult.Rows)
                employeesList.Add(new Employee
                {
                    EmployeeID = Convert.ToInt32(row[0]),
                    Number = row[1].ToString(),
                    Name = row[2].ToString(),
                    Mail = row[3].ToString(),
                    Birthday = Convert.ToDateTime(row[4])
                });

            return employeesList;
        }

        public int Remove(int idPrimaryKey)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", idPrimaryKey));

            return ExecuteNonQuery(_deleteQuery);
        }
        #endregion
    }
}
