using Day_5.Models;

namespace Day_5.Services
{
    public interface IPerson
    {
        public List<PersonModel> showMaleList(List<PersonModel> listPersonModel);
        public PersonModel showOldest(List<PersonModel> listPersonModel);
        public List<String> showFullName(List<PersonModel> listPersonModel);
        public List<PersonModel>[] showAgeGroup(List<PersonModel> listPersonModel);
        public PersonModel showFirstHanoi(List<PersonModel> listPersonModel);
    }
}
