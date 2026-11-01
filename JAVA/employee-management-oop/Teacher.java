package lesson_2;

public class Teacher extends Employee implements FreedomAble {
    //תכונות  
	private int countHours;
    private double salaryPerHour;
       
       
    //get set
	public int getCountHours() {
		return countHours;
	}
	public void setCountHours(int countHours) {
		this.countHours = countHours;
	}
	public double getSalaryPerHour() {
		return salaryPerHour;
	}
	public void setSalaryPerHour(double salaryPerHour) {
		this.salaryPerHour = salaryPerHour;
	}
	//c-tor
	public Teacher(String firstName, String lastName, int id, int countHours, double salaryPerHour) {
		super(firstName, lastName, id);
		this.countHours = countHours;
		this.salaryPerHour = salaryPerHour;
	}
	//שכר ברוטו
	public double BrootuSalary() {
		return this.salaryPerHour*this.countHours;
	}
	@Override
	public String toString() {
		
		return super.toString()+"countHours: "+countHours+"salaryPerHour: "+salaryPerHour;
	}
	//חישוב לפי יום אחד בשבוע למשך 10 חודשים
	public int FreedomDays() {
		return 40;
	}
	
	
	
	
       
       
}
