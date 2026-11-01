package aviv_2022_T9_T11;

import java.util.Arrays;

public class T11 {
	public static boolean specialNumber(int num) {
		int sumE=0, sumZ=0;
		int reversed=0;
		// Reverse the number
		while(num!=0) {
			reversed=reversed*10+(num%10);
			num/=10;
		}
		// Perform checks on the reversed number
		while(reversed!=0) {
		sumE+=reversed%10;
		reversed/=10;
		sumZ+=reversed%10;
		reversed/=10;
		}
		if(sumE==sumZ) {
			return true;
		}
		return false;
	}
	
	public static boolean isSpecialArr(int arr[]) {
		int index=-1;
		boolean isRezef=true;
		// Enter the loop only if the array starts with a special number, indicating the beginning of a sequence
		if(specialNumber(arr[0])) {
		for (int i = 0; i < arr.length&&isRezef; i++) {
			// If the sequence breaks
			if(!specialNumber(arr[i])){
				index=i; // Save the index
				isRezef=false;
			}
		}
		for (int i = index; i < arr.length; i++) {
			if (specialNumber(arr[i])) {
				return false;
			}
			
		}
		
		}
		return true;
	}
	
	public static int [] buildArr(int arr1[], int arr2[]) {
		int index1=0;
		int arr3[]=new int[arr1.length+arr2.length];
		for (int i = 0; i < arr1.length; i++) {
			if (specialNumber(arr1[i])) {
				arr3[index1++]=arr1[i];
			}
		}
		for (int i = 0; i < arr2.length; i++) {
			if (specialNumber(arr2[i])) {
				arr3[index1++]=arr2[i];
			}
		}
		// Create a short array sized by the number of special elements found
		int shortArr[]=new int[index1];
		// Copy the values into the short array
		for (int i = 0; i < shortArr.length; i++) {
			shortArr[i]=arr3[i];
		}
		
		return shortArr;
	}
	
	public static void main(String[] args) {
		int num=15345;
		int num2=13345;
		System.out.println(specialNumber(num));
		System.out.println(specialNumber(num2));
		System.out.println();
		int arr[]= {12551,6215,77,4254,4,13345};
		int arr1[]= {12551,4,6215,77,4254,15345};
		System.out.println(isSpecialArr(arr));
		System.out.println(isSpecialArr(arr1));
		System.out.println(Arrays.toString(buildArr(arr,arr1)));
	}
/*
 Output:
 true
 false

 true
 false
 [12551, 6215, 77, 12551, 6215, 77, 15345]
 */
}