using System;
using System.Collections.Generic;
using System.Text;

namespace FastSchoolApp.ViewModel
{
    public class BaseModel
    {
        public virtual Guid Id { get; set; }
        public virtual Guid Code { get; set; }
    }
}
