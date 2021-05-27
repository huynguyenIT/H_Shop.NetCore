using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.DataModel
{
    public class Account
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string _id { get; set; }
        //public int idUser { get; set; }
        //[Required]
        //[StringLength(50, MinimumLength = 3)]
        //public string FirstName { get; set; }
        //[Required]
        //[StringLength(50, MinimumLength = 3)]
        //public string LastName { get; set; }
        //[Required]

        //// [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }

        //[Required]
        ////[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        ////[DataType(DataType.Password)]
        //public string Password { get; set; }

        //[NotMapped]
        //[Required]
        //[DataType(DataType.Password)]
        //[System.ComponentModel.DataAnnotations.Compare("Password")]
        //public string ConfirmPassword { get; set; }


        //public string FullName()
        //{
        //    return this.FirstName + " " + this.LastName;
        //}
        //public int? RoleId { get; set; }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public int idUser { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        //[Required]
        //[StringLength(50)]
        public string Password { get; set; }

        public int? RoleId { get; set; }
    }
}
