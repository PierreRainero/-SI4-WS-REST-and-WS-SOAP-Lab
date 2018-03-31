using System;

namespace MathsLibrary
{
    public class MathsOperations : IMathsOperations{
        public int Add(int num1, int num2){
            return (num1 + num2);
        }

        public int Multiply(int num1, int num2){
            return (num1 * num2);
        }

        public int Divide(int num1, int num2){
            if (num2 == 0){
                throw new Exception("Divide by zero forbidden");
            }
            return (num1/num2);
        }
    }
}
