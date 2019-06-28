using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramApi.Interface
{
    public interface IUserService
    {
        IResult GetUser(string id);
    }
}
