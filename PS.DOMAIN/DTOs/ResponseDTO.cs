using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.DTOs
{
    public class ResponseDTO <T>
    {
        public List<T> Data =new List<T>();
        public List<string> Response = new List<string>();
    }
}
