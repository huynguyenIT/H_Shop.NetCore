﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.CommonModel

{
    public class UpdateAccount
    {
        public String Email { get; set; }
        public String Password { get; set; }
        public String NewPassword { get; set; }
    }
}
