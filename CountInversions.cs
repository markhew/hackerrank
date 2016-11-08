using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
/*
For a number t, of datasets print the number of inversions needed to sort

Basic merge sort with an additional counter to log the total number of inversions needed
which is incremented when the elements in the right sub-array are chosen over
the elements in the left sub-array during merging.

References 
Part 1) https://www.youtube.com/watch?v=yP0asUjcrBA
Part 2) https://www.youtube.com/watch?v=hqeoAIryJOc
*/

class CountInversions {

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
            Console.WriteLine(SortandCount(arr,0,arr.Length-1));
            
        }
        
    }
    
    static long SortandCount(int[] arr, int start, int end){
        if(start >= end){
            return 0;
        }
        int mid = (start + end ) / 2;
        long x = SortandCount(arr,start,mid);
        long y = SortandCount(arr,mid+1,end);
        long z = MergeandCount(arr,start,end,mid);
        
        
        return  x + y + z;
    }
    
    static long MergeandCount(int[] arr, int start, int end, int mid){
        int left = start;
        int right = mid+1;
        
        int numElements = end-start+1;
        int[] temp = new int[numElements];
        
        long inv = 0; //Counter for inversions
        

        int idx = 0;
        
        while(left <= mid && right <= end){
            if(arr[left] > arr[right]){
                temp[idx] = arr[right];
                right++;
                inv += (long)mid+1-(long)left;                    
            }
            else{
                temp[idx] = arr[left];
                left++;
            }
            idx++;
        }
        for(int i=left;i<=mid;i++){
            temp[idx+i-left] = arr[i];
        }
        for(int i=right;i<=end;i++){
            temp[idx+i-right] = arr[i];
        }
        
        
     
        
        
        for(int i=0;i<numElements;i++){
            arr[start+i] = temp[i];
        }
        
        return inv;
    }
}

