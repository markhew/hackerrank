using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
/* Determining if a set of numbers input from the terminal are prime for each number, it is determined if it is prime if it is divisible by any number lesser or equal to its square root, since if the number is not a prime number, when multiplying two numbers to achieve it, at least one of those divisors need to be less than or equal to the non-prime number's square root */
class Prime {

    static void Main(String[] args) {
        int p = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < p; a0++){
            int n = Convert.ToInt32(Console.ReadLine());
            if(isPrime(n)){
                Console.WriteLine("Prime");
            }
            else{
                Console.WriteLine("Not prime");
            }
        }
    }
        
    static bool isPrime(int n){
        if(n == 2){
            return true;
        }
        else if((n== 1) || (n & 1) == 0){
            return false;
        }
        else{
            for(int i=3;i<=Math.Sqrt(n);i+=2){
                if(n % i == 0){
                    return false;
                }
            }
        }
        return true;
    }    
}

