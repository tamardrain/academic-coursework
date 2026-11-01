package lesson_2;

public abstract class Employee {
	private String firstName;
	private String lastName;
	private int id;
	public static int numOfEmps=0;
	
	public Employee(String firstName, String lastName, int id) {
		numOfEmps++;
		this.firstName = firstName;
		this.lastName = lastName;
		this.id = id;
	}
	
	@Override
	public String toString() {
		
		return "firstName: "+firstName+"lastName: "+lastName+"id: "+id;
	}
	public abstract double BrootuSalary();
	
	public double mas() {
		return BrootuSalary()*0.23;
	}
	public double NetoSalary() {
		return BrootuSalary()-mas();
	}
}
