namespace Day_5.Models;

public class PersonModel
{
    String firstName;
    String lastName;
    int gender;
    String dateOfBirth;
    String phoneNumber;
    String birthPlace;
    int age;
    int isGraduated;

    public PersonModel(){
    }
    public PersonModel(String firstName, String lastName, int gender, String dateOfBirth, String phoneNumber, String birthPlace){
        this.firstName = firstName;
        this.lastName = lastName;
        this.gender = gender;
        this.dateOfBirth = dateOfBirth;
        this.phoneNumber = phoneNumber;
        this.birthPlace = birthPlace;
        this.age = ageCal(dateOfBirth);
        this.isGraduated = 0;
    }
    public PersonModel(int age){
        this.age = age;
    }
    private int ageCal(String dateOfBirht) {
        DateTime date = Convert.ToDateTime(dateOfBirht);
        DateTime now = DateTime.Now;
        int age = now.Year - date.Year;
        return age;
    }

    public String showInfo() {
        return $"Full-Name: {firstName} {lastName} Age: {age} Gender: {(gender==0 ? "Female" : "Male")} City: {birthPlace} \n";
    }

    public int Age {
        get{
            return age;
        }
        set {
            age = value;
        }
    }
    public int Gender {
        get{
            return gender;
        }
        set {
            gender = value;
        }
    }
    public String LastName {
        get{
            return lastName;
        }
        set {
            lastName = value;
        }
    }
    public String FirstName {
        get{
            return firstName;
        }
        set {
            firstName = value;
        }
    }
    public String BirthPlace {
        get{
            return birthPlace;
        }
        set {
            birthPlace = value;
        }
    }
    public String DateOfBirth {
        get{
            return dateOfBirth;
        }
        set {
            dateOfBirth = value;
        }
    }
    public int YearOfBirth {
        get{
            DateTime date = Convert.ToDateTime(dateOfBirth);
            return date.Year;
        }
    }
}
