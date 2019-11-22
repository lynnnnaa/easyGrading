using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services.Interface
{
    public interface IAccountServices
    {
        public bool isUser(string userID, string password);
    }
}
