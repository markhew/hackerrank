using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class RansomNote {

    static void Main(String[] args) {
        string[] tokens_m = Console.ReadLine().Split(' ');
        string[] magazine = Console.ReadLine().Split(' ');
        string[] ransom = Console.ReadLine().Split(' ');
        
        if(untracable(magazine, ransom)){
            Console.WriteLine("Yes");
        }
        else{
            Console.WriteLine("No");
        }
    }
    
    static bool untracable(string[] mag, string[] ransom){
        if(mag.Length < ransom.Length){
            return false;
        }
        Dictionary<string,int> dict = new Dictionary<string,int>();
        foreach(string s in mag){
            int value;
            if(!dict.TryGetValue(s, out value)){
                dict.Add(s,1);
            }
            else{
                dict[s] = value + 1;
            }
            
        }
        foreach(string s in ransom){
            int value;
            if(!dict.TryGetValue(s, out value)){
                return false;
            }
            else{
                if(value <= 0){
                    return false;
                }
                dict[s] = value - 1;
            }
        }
        return true;
    }
}

