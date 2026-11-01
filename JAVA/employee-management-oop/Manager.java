package lesson_2;

public class Manager extends Employee{
	
	private double salary;

	public double getSalary() {
		return salary;
	}

	public void setSalary(double salary) {
		this.salary = salary;
	}

	public Manager(String firstName, String lastName, int id, double salary) {
		super(firstName, lastName, id);
		this.salary = salary;
	}
	public double BrootuSalary() {
		return this.salary;
	}
	@Override
	public String toString() {
		
		return super.toString()+"salary: "+salary;
	}
	public int FreedomDays() {
		return 50;
	}

	
}
