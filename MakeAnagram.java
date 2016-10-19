import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;
public class MakeAnagram {
    /*Create two hashmaps for the strings, 
        iterate through both strings, adding frequency of characters to the hash map.
        When adding the characters for the second string, if the characters do not appear in the first string
        add them to the first hashmap with a value of 0
        
        Iterate through the first hashmap, return the total difference between the frequency of characters in both
        hashmaps
    */
    public static int numberNeeded(String first, String second) {
        if(first.length() < 1){
          return second.length();
        }
        if(second.length() < 1){
            return first.length();
        }
        HashMap<Character, Integer> firstHM = new HashMap<>();
        HashMap<Character, Integer> secondHM = new HashMap<>();
        
        for(int i=0; i<first.length();i++){
            char fc = first.charAt(i);
            
            if(firstHM.containsKey(fc)){
                firstHM.put(fc,firstHM.get(fc)+1);
            }
            else{
                firstHM.put(fc,1);
            }                   
        }
        for(int j=0; j<second.length();j++){
            char sc = second.charAt(j);
            
            if(secondHM.containsKey(sc)){
                secondHM.put(sc,secondHM.get(sc)+1);
            }
            else{
                secondHM.put(sc,1);
            }
            if(!firstHM.containsKey(sc)){
                firstHM.put(sc,0);
            }
        }
        
        
        int remove = 0;
        for(Map.Entry<Character,Integer> entry : firstHM.entrySet()){
            char c = entry.getKey();
            if(secondHM.containsKey(c)){
                remove += Math.abs( entry.getValue() - secondHM.get(c));
            }
            else{
                remove += entry.getValue();
            }
        }
        
        return remove;
       
    }
  
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        String a = in.next();
        String b = in.next();
        System.out.println(numberNeeded(a, b));
    }
}

