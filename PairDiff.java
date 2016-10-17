import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

/*
Create a hashset to store all integers of array
Loop through array after storing, check if the hashset contains k+element(will result in a difference of k)
*/
public class PairDiff {
    static int pairs(int[] a,int k) {
        int count = 0;
        HashSet<Integer> numHash = new HashSet<>();
        for(int i=0;i<a.length;i++){
            numHash.add(a[i]);
        }
        for(int j=0;j<a.length;j++){
            if(numHash.contains(a[j]+k)){
                count++;
            }
        }
        return count;
    }

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        int res;
        
        String n = in.nextLine();
        String[] n_split = n.split(" ");
        
        int _a_size = Integer.parseInt(n_split[0]);
        int _k = Integer.parseInt(n_split[1]);
        
        int[] _a = new int[_a_size];
        int _a_item;
        String next = in.nextLine();
        String[] next_split = next.split(" ");
        
        for(int _a_i = 0; _a_i < _a_size; _a_i++) {
            _a_item = Integer.parseInt(next_split[_a_i]);
            _a[_a_i] = _a_item;
        }
        
        res = pairs(_a,_k);
        System.out.println(res);
    }
}

