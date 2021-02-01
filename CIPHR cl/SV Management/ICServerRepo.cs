using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPHR.SV_Management
{
    public interface ICServerRepo
    {
        Task<bool> Create(cserver sv);
        Task<bool> Delete(cserver sv);
        Task<bool> Validate(cserver sv);
    }
}
