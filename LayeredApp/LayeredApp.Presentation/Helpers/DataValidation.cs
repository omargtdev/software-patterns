using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredApp.Presentation.Helpers
{
    public class DataValidation
    {
        private readonly ValidationContext _context;
        private readonly List<ValidationResult> _results;
        private bool _isValid;
        private string _message;

        public DataValidation(object instance)
        {
            _context = new ValidationContext(instance);
            _results = new List<ValidationResult>();
            _isValid = Validator.TryValidateObject(instance, _context, _results, true);
        }

        public bool Validate()
        {
            if (!_isValid)
            {
                foreach (var item in _results)
                    _message += $"{item.ErrorMessage}\n";

                System.Windows.Forms.MessageBox.Show(_message);
            }

            return _isValid;
        }
    }
}
