package maat_2025;

public class T8 {
	
	private static boolean search(char[][] arr, int i, int j, String word) {
		boolean isApear=false;
		// Check row to the right
		if (j+word.length()<=arr[j].length) {
			isApear=true;
			for (int k = 0; k < word.length(); k++) {
				if (arr[i][j+k]!=word.charAt(k)) {
					isApear=false;
				}
			}
			if(isApear) {
				return true;
			}
		}
			// Check row to the left
			if (j-word.length()+1>=0) {
				isApear=true;
				for (int k = 0; k < word.length(); k++) {
					if (arr[i][j-k]!=word.charAt(k)) {
						isApear=false;
					}
				}
				if(isApear) {
					return true;
				}
			}
				// Check column downwards
				if (i+word.length()<=arr.length) {
					isApear=true;
					for (int k = 0; k < word.length(); k++) {
						if (arr[i+k][j]!=word.charAt(k)) {
							isApear=false;
						}
					}
					if(isApear) {
						return true;
					}
				}
					// Check column upwards
					if (i-word.length()+1>=0) {
						isApear=true;
						for (int k = 0; k < word.length(); k++) {
							if (arr[i-k][j]!=word.charAt(k)) {
								isApear=false;
							}
						}
						if(isApear) {
							return true;
						}
			
		}
					return false;
		
	
			}
	
	
	public static boolean exist(char arr[][],String word) {
		
		for (int i = 0; i < arr.length; i++) {
			for (int j = 0; j < arr[i].length; j++) {
				if (arr[i][j]==word.charAt(0)) {
					if(search(arr,i,j,word)) {
						return true;
					}
				}
			}
		}
		return false;
	}
	public static void main(String[] args) {
		  // Create a character matrix
	    char[][] matrix = {
	        {'H', 'E', 'L', 'L', 'O'},
	        {'A', 'B', 'C', 'D', 'E'},
	        {'F', 'G', 'H', 'I', 'J'},
	        {'K', 'L', 'M', 'N', 'O'},
	        {'P', 'Q', 'R', 'S', 'T'}
	    };

	    // Create a word to search
	    String word = "HELLO";
	    System.out.println("Is the word " + word + " found in the matrix? ");
	    System.out.println(exist(matrix,word));
	}

	
	

}