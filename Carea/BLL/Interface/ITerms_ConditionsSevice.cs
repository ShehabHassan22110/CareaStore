using Carea.Entities;

namespace Carea.Interfaces
{
    public interface ITerms_ConditionsSevice
    {
        IEnumerable<Terms_Conditions> Get();
        Terms_Conditions GetById(int id);
        void Create(Terms_Conditions obj);
        void Edit(Terms_Conditions obj);
        void Delete(Terms_Conditions obj);
    }
}
