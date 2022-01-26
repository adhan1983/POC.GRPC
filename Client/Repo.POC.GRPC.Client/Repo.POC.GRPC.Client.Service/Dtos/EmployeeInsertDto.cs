using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.POC.GRPC.Client.Service.Dtos
{
    public class EmployeeInsertDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
