using DataAndServices.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Admin_Services.UserAccServices
{
    public interface IUserAccService
    {
        Task<List<User_Acc>> GetAllUser_Accs();


      


        Task<User_Acc> GetUser_AccById(string id);


        Task<bool> Create_Ad_acc(User_Acc User_Acc);


        Task<bool> Update_Ad_acc(User_Acc User_Acc);


        Task<bool> Update_Ad_acc2(User_Acc User_Acc);


        Task<bool> DeleteUser_Acc(int _id);
    }
}
