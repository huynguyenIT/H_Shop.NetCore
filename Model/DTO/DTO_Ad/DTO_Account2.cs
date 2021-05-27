using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.DTO_Ad
{
    public class DTO_Account2
    {
        public string _id { get; set; }

        public int idUser { get; set; }

      
        public string FirstName { get; set; }

      
        public string LastName { get; set; }

        public string Email { get; set; }

       
        public string Password { get; set; }

        public int? RoleId { get; set; }
    }
}
