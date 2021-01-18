using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPHR_server
{
    public interface CUserRepo
    {
        Task<bool> Insert(cuser user);
        Task<bool> Check(cuser user);
    }
}
