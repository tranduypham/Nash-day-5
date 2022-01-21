using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Day_5.Models;
using Day_5.Services;

namespace Day_5.Controllers;

public class PersonController : Controller, IPerson
{
    List<PersonModel> list = new List<PersonModel>();
    
    
    public PersonController()
    {
    }

    public String Index()
    {
        PersonModel m1 = new PersonModel("Duy", "Pham", 1, "1999/12/20", "0946301025", "Ha noi");
        PersonModel m2 = new PersonModel("Hoa", "Ho", 0, "1989/09/02", "0946301025", "Hai Duong");
        PersonModel m3 = new PersonModel("May", "Thi", 1, "1979/03/12", "0946301025", "Nam Dinh");
        PersonModel m4 = new PersonModel("Loan", "Nguyen", 1, "1995/02/05", "0946301025", "Hai Duong");
        PersonModel m5 = new PersonModel("Tuyet", "Sung", 0, "2003/10/10", "0946301025", "Ha noi");
        PersonModel m6 = new PersonModel("Ngoc", "Le", 1, "2002/11/24", "0946301025", "Nam Dinh");
        list.Add(m1);
        list.Add(m2);
        list.Add(m3);
        list.Add(m4);
        list.Add(m5);
        list.Add(m6);

        String result = "";

        result += "PersonModel co tuoi cao nhat la : \n";
        PersonModel oldestPersonModel = showOldest(list);
        result += oldestPersonModel.showInfo();

        result += "PersonModel co gender la male : \n";
        foreach(PersonModel m in showMaleList(list)){
            result += m.showInfo();
        }

        result += "List of full name : \n";
        foreach(String name in showFullName(list)){
            result += name + "\n";
        }

        result += "\nFirst born in Hanoi : \n";
        result += showFirstHanoi(list).showInfo();

        List<PersonModel>[] arrAge = showAgeGroup(list);
        result += "Born in 2000 : \n";
        foreach(PersonModel m in arrAge[0]){
            result += m.showInfo();
        }
        result += "Born after 2000 : \n";
        foreach(PersonModel m in arrAge[2]){
            result += m.showInfo();
        }
        result += "Born before 2000 : \n";
        foreach(PersonModel m in arrAge[1]){
            result += m.showInfo();
        }
        return result;
    }

    public FileResult DownLoad(){
        return File(
            "tmp/Result.xlsx", 
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
            "Result.xlsx"
            );
    }
    public List<PersonModel> showMaleList(List<PersonModel> listPersonModel){
        List<PersonModel> male = (from PersonModel in listPersonModel
                                where PersonModel.Gender == 1
                                select PersonModel).ToList();
        return male;
    }
    public PersonModel showOldest(List<PersonModel> listPersonModel){
        var oldest = (from PersonModel in listPersonModel
                orderby PersonModel.Age descending
                select PersonModel).ToList();
        return oldest.FirstOrDefault() == null ? new PersonModel() : oldest.First();
    }
    public List<String> showFullName(List<PersonModel> listPersonModel){
        List<String> fullName = (from PersonModel in listPersonModel
                                select PersonModel.LastName + " " + PersonModel.FirstName).ToList();
        return fullName;
    }
    public List<PersonModel>[] showAgeGroup(List<PersonModel> listPersonModel){
        List<PersonModel> is2000 = (from PersonModel in listPersonModel
                    where PersonModel.YearOfBirth == 2000
                    select PersonModel).ToList();
        List<PersonModel> above2000 = (from PersonModel in listPersonModel
                    where PersonModel.YearOfBirth > 2000
                    select PersonModel).ToList();
        List<PersonModel> below2000 = (from PersonModel in listPersonModel
                    where PersonModel.YearOfBirth < 2000
                    select PersonModel).ToList();
        return new List<PersonModel>[]{
            is2000,
            above2000,
            below2000
        };
    }
    public PersonModel showFirstHanoi(List<PersonModel> listPersonModel){
        var hanoier = (from PersonModel in listPersonModel
                    where PersonModel.BirthPlace == "Ha noi"
                    select PersonModel).ToList();
        PersonModel firstHanoier = hanoier.First();
        return firstHanoier == null ? new PersonModel(){BirthPlace = ""} : firstHanoier;
    }

}
