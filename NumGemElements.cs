using System;
using System.Collections.Generic;
using System.IO;
class CountGemElements {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int numRocks = Int32.Parse(Console.ReadLine());
        int[,] elements = new int[numRocks,26];
        
        for(int i=0; i< numRocks;i++){
            string gemElement = Console.ReadLine();
            foreach(char c in gemElement){
                int index = (int)c - 97;
                elements[i,index]++;
            }
        }
        int numGemElements = 0;
        bool isGem;
        for(int j=0;j<26;j++){
            isGem = true;
            for(int i=0;i<numRocks;i++){
                if(elements[i,j] == 0){
                    isGem = false;
                    break;
                }
            }
            if(isGem){
                numGemElements++;
            }
        }
        
        Console.WriteLine(numGemElements);
        
    }
}