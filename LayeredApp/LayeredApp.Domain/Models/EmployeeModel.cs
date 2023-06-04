using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredApp.DataAccess.Repositories;
using LayeredApp.DataAccess.Entities;
using LayeredApp.Domain.ValueObjects;
using LayeredApp.DataAccess.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace LayeredApp.Domain.Models
{
    public class EmployeeModel
    {
        private int _employeeID;
        private string _number;
        private string _name;
        private string _mail;
        private DateTime _birthday;
        private int _age;

        private List<EmployeeModel> _employeeModelList;
        private IEmployeeRepository _employeeRepository;

        #region Properties/Data Validation
        public EntityState State { private get; set; } // Only get in this class
        public int EmployeeID { get => _employeeID; set => _employeeID = value; }

        [Required(ErrorMessage = "The field identification number is required")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Identification number must be only numbers")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "Identification number must be 10 digits")]
        public string Number { get => _number; set => _number = value; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The field name must be only letters")]
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string Name { get => _name; set => _name = value; }

        [Required]
        [EmailAddress]
        public string Mail { get => _mail; set => _mail = value; }
        public DateTime Birthday { get => _birthday; set => _birthday = value; }
        public int Age { get => _age; private set => _age = value; }
        #endregion

        #region Constructors
        public EmployeeModel()
        {
            _employeeRepository = new EmployeeRepository();
        }
        #endregion

        /// <summary>
        ///     Execute an respective operation
        /// </summary>
        /// <returns>The description of result operation</returns>
        public string SaveChanges()
        {
            string message = "";
            try
            {
                var employeeDataModel = new Employee();
                employeeDataModel.EmployeeID = _employeeID;
                employeeDataModel.Number = _number;
                employeeDataModel.Name = _name;
                employeeDataModel.Mail = _mail;
                employeeDataModel.Birthday = _birthday;

                switch (State)
                {
                    case EntityState.Added:
                        // Execute comercial rules
                        _employeeRepository.Add(employeeDataModel);
                        message = "successfully record";
                        break;
                    case EntityState.Modified:
                        _employeeRepository.Edit(employeeDataModel);
                        message = "successfully edited";
                        break;
                    case EntityState.Deleted:
                        _employeeRepository.Remove(_employeeID);
                        message = "successfully removed";
                        break;
                }

            }
            catch (Exception ex)
            {
                // Capture the exception
                SqlException sqlException = ex as SqlException;
                if (sqlException != null && sqlException.Number == SqlErrorCode.Duplicate)
                    message = "Duplicate record";
                else
                    message = ex.ToString();
                
            }

            return message;
        }

        private int CalculateAge(DateTime birthday)
        {
            var actualDate = DateTime.Now;
            return actualDate.Year - birthday.Year;
        }

        public List<EmployeeModel> GetAll()
        {
            var employeeDataModel = _employeeRepository.GetAll();
            _employeeModelList = new List<EmployeeModel>();
            foreach (var employee in employeeDataModel)
            {
                _employeeModelList.Add(new EmployeeModel
                {
                    EmployeeID = employee.EmployeeID,
                    Number = employee.Number,
                    Name = employee.Name,
                    Mail = employee.Mail,
                    Birthday = employee.Birthday,
                    Age = CalculateAge(employee.Birthday)
                });
            }
            return _employeeModelList;
        }

        public IEnumerable<EmployeeModel> GetByPattern(string filter) => _employeeModelList.FindAll(employee => employee.Number.Contains(filter) || employee.Name.Contains(filter));
    }
}
