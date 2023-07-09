using Carea.Models;
using Carea.ViewModels;

namespace Carea.BLL.Interface
{
    public interface IUserLoginsRep
    {
        IEnumerable<UserLogins> Get();
        public UserLogins GetById(string userid);
        void Creat(UserLogins obj);
        void Delete(int id);
    }
}
