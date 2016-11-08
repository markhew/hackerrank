/*References
    http://www.geeksforgeeks.org/dynamic-programming-set-7-coin-change/
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class CoinChangeDP {

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        string[] coins_temp = Console.ReadLine().Split(' ');
        int[] coins = Array.ConvertAll(coins_temp,Int32.Parse);
        
        //need to use long to avoid int overflow
        long numComb = MakeChange(coins, m, n);
        
        Console.WriteLine(numComb);
    }
    
    static long MakeChange(int[] coins, int numCoins, int targetSum){              
        long[] dp = new long[targetSum+1];
        dp[0] = (long)1;
        
        for(int i=1; i<=targetSum; i++){
            dp[i] = (long)0;
        }
        
        for(int i=0; i<numCoins;i++){
           for(int j=coins[i];j<=targetSum;j++){
               dp[j] += dp[j-coins[i]];

           }
        }
        
        return dp[targetSum];
        
        
    }
    
}

