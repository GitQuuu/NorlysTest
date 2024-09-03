namespace DAL.Entities;

public class Employee
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string MiddleName { get; set; }
	public string LastName { get; set; }
	public DateOnly Birthdate { get; set; }
	public List<Office> Offices { get; set; }
}