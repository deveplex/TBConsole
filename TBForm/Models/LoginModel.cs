using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TBForm.Models
{
   public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool CheckPassword { get; set; }
        public bool CheckAutoRun { get; set; }
    }
}
