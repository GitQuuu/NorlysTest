﻿namespace Services;

public class ReadEmployeesResponse
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string MiddleName { get; set; }
	public string LastName { get; set; }
	public DateOnly Birthdate { get; set; }
}