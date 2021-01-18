using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPHR_server.SV_Interface
{
    public interface CServerRepo
    {
        Task<bool> Create(csv_struct sv);
        Task<bool> Delete(csv_struct sv);
        Task<bool> Validate(csv_struct sv);
    }
}
