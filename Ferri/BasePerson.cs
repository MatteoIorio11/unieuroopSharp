namespace DefaultNamespace;

using System.Date;

public interface BasePerson
{
    /**
     * set person name.
     * @param name
     */
    void setPersonName(string name);

    /**
     * set person surname.
     * @param surname
     */
    void setPersonSurname(string surname);

    /**
     * set person birthday.
     * @param birthday
     */
    void setPersonBirthday(LocalDate birthday);

    /**
     * @return the name of the person 
     */
    string getName();

    /**
     * @return the surname of the person 
     */
    string getSurname();

    /**
     * @return the birthday of the person 
     */
    LocalDate getBirthdayDate();

    /**
     * 
     * @return person code
     */
    string getCode();

    /**
     * @return toString of the person
     */
    string toString();

    /**
     * override of hashCode.
     * @return hashCode
     */
    int hashCode();

    /**
     * override of equals.
     * @param obj
     * @return equals
     */
    bool equals(Object obj);
}