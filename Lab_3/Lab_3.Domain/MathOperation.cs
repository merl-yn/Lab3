using System;

namespace Lab_3.Domain
{
    public class MathOperationEventArgs : EventArgs
    {
        public double Value1 { get; }
        public double Value2 { get; }

        public MathOperationEventArgs(double value1, double value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
    }
    
    public interface IMathOperation
    {
        event EventHandler<MathOperationEventArgs> OnDivision;
        double Sum(double a, double b);
        double Multiple(double a, double b);
        double Divide(double a, double b);
        double Subtract(double a, double b);
    }
    
    public class MathOperation : IMathOperation
    {
        public event EventHandler<MathOperationEventArgs> OnDivision;

        public double Sum(double a, double b) => a + b;

        public double Multiple(double a, double b) => a * b;

        public double Subtract(double a, double b) => a - b;

        public double Divide(double a, double b)
        {
            OnDivision?.Invoke(this, new MathOperationEventArgs(a, b));
            return a / b;
        }
    }
}