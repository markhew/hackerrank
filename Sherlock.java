import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;
/*
Watson gives Sherlock an array A of length N. Then he asks him to determine if there exists an element in the array such that the sum of the elements on its left is equal to the sum of the elements on its right. If there are no elements to the left/right, then the sum is considered to be zero. 
Formally, find an i, such that A1, A2, ...Ai-1 = Ai+1, Ai+2, ..AN.


Input Format 
The first line contains T, the number of test cases. For each test case, the first line contains N, the number of elements in the array A. The second line for each test case contains N space-separated integers, denoting the array A.

Output Format 
For each test case print YES if there exists an element in the array, such that the sum of the elements on its left is equal to the sum of the elements on its right; otherwise print NO.
*/


public class Sherlock {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        
        int numTestCases = sc.nextInt();
        for(int n=0; n<numTestCases; n++){
            int size = sc.nextInt();
            int[] array = new int[size];
            for(int i=0;i<size;i++){
                array[i] = sc.nextInt();
            }
            if(sherlockArray(array,size)){
                System.out.println("YES");
            }
            else{
                System.out.println("NO");
            }
        }
    }
    //Create 2 new arrays, 1 for the which cumalatively adds elements from "a" from the left and 1 which adds elements from the right, compare elements in both indexes, if one matches, return true otherwise return false
    //Special case: if array only contains one element return true 
    public static boolean sherlockArray(int[] a, int size){
        if(size == 1){
            return true;
        }
        else{
            int[] cumLeft = new int[size]; //Array where the elements of "a" are cumalatively added from the left
            int[] cumRight = new int[size];//Array where the elements of "a" are cumalatively added from the right
            cumLeft[0] = a[0];
            cumRight[size-1] = a[size-1];
            for(int i=1;i<size;i++){
                cumLeft[i] = a[i] + cumLeft[i-1];
                cumRight[size-i-1] = a[size-i-1] + cumRight[size-i];
            }
            
            for(int i=1;i<size;i++){
                if(cumLeft[i] == cumRight[i]){
                    return true;
                }
            }
        }
        return false;
    }
}