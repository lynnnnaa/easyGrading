using easyGrading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services.Interface
{
    public interface IClassesServices
    {
        public IEnumerable<ClassInfoViewModel> GetClassInfo(int studentId);
    }
}
