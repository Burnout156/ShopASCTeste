using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopASCLibrary.Exception
{
    public class NotFoundException : IOException
    {
        public NotFoundException(string entityName, object entityId)
            : base($"Entity '{entityName}' with ID '{entityId}' not found.")
        {
        }
    }
}
