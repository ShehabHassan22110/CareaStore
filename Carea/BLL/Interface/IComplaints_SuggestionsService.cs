using Carea.Entities;

namespace Carea.Interfaces
{
    public interface IComplaints_SuggestionsService
    {
        IEnumerable<Complaints_Suggestions> Get();
        Complaints_Suggestions GetById(int id);
        void Create(Complaints_Suggestions obj);
        void Edit(Complaints_Suggestions obj);
        void Delete(Complaints_Suggestions obj);
    }
}
