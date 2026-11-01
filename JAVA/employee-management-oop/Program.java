package lesson_2;

import java.security.PublicKey;

public class Program {
	
	public static void sumRevach() {
	  System.out.println("כמות העובדים במוסד: "+Employee.numOfEmps);
	  System.out.println("סהכ רווחים למוסד: "+Employee.numOfEmps*1500);
	}
	
	public static void main(String[] args) {
		
	    Employee[] e=new Employee[8];
		e[0]=new Teacher("tamar", "drain", 11234566,100, 60);
		e[1]=new Teacher("leah", "levi", 512685412, 70, 65);
		e[2]=new Teacher("yael", "cohen", 542695212,40, 85);
		e[3]=new Teacher("chana", "pinto", 865223236, 30, 70);
		e[4]=new Manager("malka", "david", 1254552, 15000);
		e[5]=new Secretery("nechama", "jeikob", 254852685, 120, 50, 500);
		e[6]=new Secretery("freidy", "green", 65214589, 110, 50, 700);
		e[7]=new Secretery("miryam", "moshe", 25412541, 100, 50, 600);
		
		for (int i = 0; i < e.length; i++) {
			System.out.println("emp "+(i+1));
			if (e[i] instanceof Teacher) {
				System.out.println(e[i].NetoSalary());
				System.out.println(e[i].toString());
			}
			if (e[i] instanceof Manager) {
				System.out.println(e[i].NetoSalary());
				System.out.println(e[i].toString());
			}
			if (e[i] instanceof Secretery) {
				System.out.println(e[i].NetoSalary());
				System.out.println(e[i].toString());
			}
			
			
		}
		sumRevach();
		//כמות העובדים במוסד: 8
		//סהכ רווחים למוסד: 12000

		/* 
	    emp 1
		4620.0
		firstName: tamarlastName: drainid: 11234566countHours: 100salaryPerHour: 60.0
		emp 2
		3503.5
		firstName: leahlastName: leviid: 512685412countHours: 70salaryPerHour: 65.0
		emp 3
		2618.0
		firstName: yaellastName: cohenid: 542695212countHours: 40salaryPerHour: 85.0
		emp 4
		1617.0
		firstName: chanalastName: pintoid: 865223236countHours: 30salaryPerHour: 70.0
		emp 5
		11550.0
		firstName: malkalastName: davidid: 1254552salary: 15000.0
		emp 6
		5005.0
		firstName: nechamalastName: jeikobid: 254852685countHours: 120salaryPerHour: 50.0bonus: 500
		emp 7
		4774.0
		firstName: freidylastName: greenid: 65214589countHours: 110salaryPerHour: 50.0bonus: 700
		emp 8
		4312.0
		firstName: miryamlastName: mosheid: 25412541countHours: 100salaryPerHour: 50.0bonus: 600
		 */
		
		
		
	
	}

}
