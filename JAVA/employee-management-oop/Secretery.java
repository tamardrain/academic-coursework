package lesson_2;

public class Secretery extends Employee {
		
	   //תכונות  
		private int countHours;
	    private double salaryPerHour;
	    private int bonus;
	       
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
		public int getBonus() {
			return bonus;
		}
		public void setBonus(int bonus) {
			this.bonus = bonus;
		}
		//c-tor
		public Secretery(String firstName, String lastName, int id, int countHours, double salaryPerHour, int bonus) {
			super(firstName, lastName, id);
			this.countHours = countHours;
			this.salaryPerHour = salaryPerHour;
			this.bonus = bonus;
		}
		//שכר ברוטו
		public double BrootuSalary() {
			return (this.salaryPerHour*this.countHours)+bonus;
				}
		@Override
		public String toString() {
			
			return super.toString()+"countHours: "+countHours+"salaryPerHour: "+salaryPerHour+"bonus: "+bonus;
		}
		public int FreedomDays() {
			return 40;
		}

		
}
