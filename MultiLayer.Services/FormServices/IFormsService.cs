using MultiLayer.Domain.Entities;
using MultiLayer.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLayer.Services.FormServices
{
    public interface IFormsService
    {
        void AddForm(Forms blog);
        IEnumerable<Forms> GetForms();
        Forms Find(int id);
        void Insert(Forms model);
        void InsertFields(fields f);
        IEnumerable<fields> GetFields(int formId);
    }
}
