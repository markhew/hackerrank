using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            string expression = Console.ReadLine();
            if(validExpression(expression)){
                Console.WriteLine("YES");
            }
            else{
                Console.WriteLine("NO");
            }
        }
    }
    //Loop through expression adding '{'s, '('s and '['s to the stack, 
    //When encountering a ']', ')' or '}', pop an element from the stack,
    //Check if the ascii difference is in between 1 and 2 (NOTE: Assuming string only contains characters which are
    //a type of bracket)
    static bool validExpression(string expression){
        
        Stack<char> brackets = new Stack<char>();
        for(int i=0;i<expression.Length;i++){
            char c = expression[i];
            if(c == '(' || c == '{' || c == '['){
                brackets.Push(c);
            }
            else{
                if(brackets.Count < 1){
                    return false;
                }
                char b = brackets.Pop();
                int diff = (int) c - (int) b;
                if(diff < 1 || diff > 2 ){
                    return false;
                }
            }
        }
        return brackets.Count == 0;
    }
}

