using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class HeapMedian {
    /*
    Create two heaps, one min heap to hold numbers higher than the current median
    and one max heap to hold numbers lower than the current median.
    For each new number, if it is greater than the current median, add it to the min heap
    if it is smaller, add it to the max heap.
    Then balance the heaps to make sure that no heap is bigger than the other by more than 1.
    If the min/max heap has more than 2 elements over its corresponding heap. Move the top of the heap to
    the other one. Max/Min Heapify the heaps.

    To get the median, get the top element of the heap with the greater size, or the average of the top elements
    of the two heaps if their sizes are equal.
    */

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] a_temp = new string[n];    
        
        for(int i=0; i<n;i++){
            a_temp[i] = Console.ReadLine();
        }
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);
        List<int>  minHeap = new List<int> ();
        List<int>  maxHeap = new List<int> ();
        decimal median = (decimal)a[0];
        minHeap.Add(a[0]);
        Console.WriteLine(median.ToString("F1"));
        
        for(int i=1; i<a.Length;i++){
            if(a[i] < median){
                maxHeap.Add(a[i]);
                MaxHeapify(maxHeap,maxHeap.Count-1);
            }
            else{
                minHeap.Add(a[i]);
                MinHeapify(minHeap,minHeap.Count-1);
            }
            
            if(maxHeap.Count > minHeap.Count + 1){
                minHeap.Add(maxHeap[0]);
                MinHeapify(minHeap,minHeap.Count-1);
                Remove(maxHeap, true);

            }
            
            if(minHeap.Count > maxHeap.Count + 1){
                maxHeap.Add(minHeap[0]);
                MaxHeapify(maxHeap,maxHeap.Count-1);
                Remove(minHeap,false);
            }
            
            MaxHeapifyDown(maxHeap,0);
            MinHeapifyDown(minHeap,0);



            
            if(minHeap.Count > maxHeap.Count){
                median = (decimal)minHeap[0];
            
            }
            else if(minHeap.Count < maxHeap.Count){
                median = (decimal)maxHeap[0];
            }
            else{
                median = ((decimal)minHeap[0] + (decimal)maxHeap[0]) / 2;
            }
            Console.WriteLine(median.ToString("F1"));
            
        }


    }
    //Debugging function
     static void debug(List<int> maxHeap, List<int> minHeap,int idx){
         if(idx > 190){   
         Console.WriteLine(idx+1 + ":");
             Console.Write("Max Heap ");
            outputElements(maxHeap);
            Console.Write("Min Heap ");


            outputElements(minHeap);
         }
    }
    //Function for removing top element of heap,
    //Swap top and last element, use trickle down heapify
    //bool variable used so to differentiate between max and min heap
    static void Remove(List<int> heap, bool max){
        SwapElements(heap,0,heap.Count-1);
        heap.RemoveAt(heap.Count-1);
        if(max){
            MaxHeapifyDown(heap,0);
        }
        else{
            MinHeapifyDown(heap,0);
        }
    }
    
   
    
    static void MaxHeapify(List<int> heap, int i){
        if(i > 0){
            int parent;
            if(i % 2 == 0){
                parent = (i-1) /2;
            }
            else{
                parent = i/2;
            }

            if(heap[i] > heap[parent]){
                SwapElements(heap,i,parent);
                MaxHeapify(heap,parent);
            }
            
        }  
    }
    
    static void MaxHeapifyDown(List<int> heap, int i){
        int left = 2 * (i+1) - 1;
        int right = 2 * (i+1);
        int largest = i;
        
        if(left < heap.Count && heap[left] > heap[largest] ){
            largest = left;
        }
        if(right < heap.Count && heap[right] > heap[largest]){
            largest = right;
        }
        if(largest != i){
            SwapElements(heap,largest,i);
            MaxHeapifyDown(heap,largest);
        }
    }
    
    static void MinHeapify(List<int> heap, int i){
        if(i > 0){
            int parent;
            if(i % 2 == 0){
                parent = (i-1) /2;
            }
            else{
                parent = i/2;
            }

            if(heap[i] < heap[parent]){
                SwapElements(heap,i,parent);
                MinHeapify(heap,parent);
            }
            
        }  
    }    
    static void MinHeapifyDown(List<int> heap, int i){
        int left = 2 * (i+1) - 1;
        int right = 2 * (i+1);
        int smallest = i;
        
        if(left < heap.Count && heap[left] < heap[smallest] ){
            smallest = left;
        }
        if(right < heap.Count && heap[right] < heap[smallest]){
            smallest = right;
        }
        if(smallest != i){
            SwapElements(heap,smallest,i);
            MinHeapifyDown(heap,smallest);
        }
    }
    static void SwapElements(List<int> heap, int i, int j){
        int temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
    static void MaxHeapRemove(List<int> heap, int i){
        
    }
    
    static void outputElements(List<int> heap){
        foreach(int i in heap){
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}


