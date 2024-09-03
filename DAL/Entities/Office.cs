namespace DAL.Entities;

public class Office
{
	public int Id { get; set; }
	public string Address { get; set; }
	public string Number { get; set; }
	public int Zipcode { get; set; }
	public string City { get; set; }
	public List<Employee> Employees { get; set; }
	
	/// <summary>
	/// The number of employees allowed on the office according to the fire department by law
	/// </summary>
	public int FireCode { get; set; }
}