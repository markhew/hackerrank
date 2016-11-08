using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class NumSwapsBubble {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);
        int numSwaps = BubbleSort(a,n);
        Console.WriteLine("Array is sorted in "+numSwaps+" swaps.");
        Console.WriteLine("First Element: "+ a[0]);
        Console.WriteLine("Last Element: "+ a[n-1]);
    }
    
    static int BubbleSort(int[] a, int n){
        // Track number of elements swapped during a single array traversal
        int numberOfSwaps = 0;

        for (int i = 0; i < n-1; i++) {
            for (int j = 0; j < n-1; j++) {
            // Swap adjacent elements if they are in decreasing order
                if (a[j] > a[j + 1]) {
                    Swap(a, j,j+1);
                    numberOfSwaps++;
                }
            }
            if(numberOfSwaps == 0){
                break;
            }
        }
        
        return numberOfSwaps;
    }
    
    static void Swap(int[] a, int i, int j){
        int tmp = a[i];
        a[i] = a[j];
        a[j] = tmp;
    }
}

