namespace WilliMaps.Components
{
    public class Calculator
    {

        public int add(int a,  int b) { return a + b; }

        public int subtract(int a, int b) { return a - b; }

        public int multiply(int a, int b) {return a * b; }

        public double divide(int a, double b) 
        {
            if (b ==  0) throw new DivideByZeroException();
            return a / b; 
        }
    }
}
