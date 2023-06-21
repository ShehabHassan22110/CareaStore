using Carea.Entities;

namespace Carea.Interfaces {
	public interface IPrivacyPolicyService
	{
		IEnumerable<PrivacyPolicy> Get();
		PrivacyPolicy GetById(int id);
		void Create(PrivacyPolicy obj);
		void Edit(PrivacyPolicy obj);
		void Delete(PrivacyPolicy obj);
	}
}
