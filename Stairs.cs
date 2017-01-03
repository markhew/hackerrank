using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
/*
Solved using a version of a modification of fibonacci 
*/
class Solution {

    static void Main(String[] args) {
        int s = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < s; a0++){
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(NumWays(n));
            
        }
    }
    
    static int NumWays(int n){
        
        int[] dp;
        if(n < 3){
            dp = new int[3];
        }
        else{
            dp = new int[n];
        }
        dp[0] = 1;
        dp[1] = 2;
        dp[2] = 4;
        if(n >= 3){
            for(int i=3;i<n;i++){
                dp[i] = dp[i-1] + dp[i-2] + dp[i-3];
            }
        }
        
        return dp[n-1];
    }
}

