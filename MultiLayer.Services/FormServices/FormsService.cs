using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiLayer.Presentation.Models;
using MultiLayer.Domain.Interfaces;
using MultiLayer.Domain.Entities;

namespace MultiLayer.Services.FormServices
{
    public class FormsService : IFormsService
    {
        private readonly IRepository<Forms> _formRepository;
        private readonly IRepository<fields> _fields;

        public FormsService(IRepository<Forms> formRepository, IRepository<fields> fields)
        {
            this._formRepository = formRepository;
            this._fields = fields;
        }

        public void AddForm(Forms forms)
        {
            _formRepository.Insert(forms);
        }

        public Forms Find(int id)
        {
            return _formRepository.GetById(id);
        }

        public IEnumerable<Forms> GetForms()
        {
            return _formRepository.GetAllNoTracking;
        }

        public void Insert(Forms f)
        {
            _formRepository.Insert(f);
        }

        public void InsertFields(fields f)
        {
            _fields.Insert(f);
        }

        public IEnumerable<fields> GetFields(int formId)
        {
            return _fields.GetAllNoTracking.Where(w => w.formsId == formId);
        }
    }
}
