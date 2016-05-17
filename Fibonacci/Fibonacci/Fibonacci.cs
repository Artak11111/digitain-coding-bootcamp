using System;

namespace Fibonacci
{
    public class Fibonacci
    {
        public static Fibonacci Create(int length)
        {
            var seq = new Fibonacci(length);
            seq.Caluclate();
            return seq;
        }
        public static Fibonacci Create()
        {
            var seq = new Fibonacci();
            seq.Caluclate();
            return seq;
        }

        public Fibonacci(int length)
        {
            if (length < 3 || length > Capacity)
            {
                throw new ArgumentException($"The {nameof(length)} should be between 3 and {Capacity}", nameof(length));
            }
            numbers = new ulong[length];
            Length = length;
        }
        public Fibonacci():this(Capacity)
        {
        }

        private ulong[] numbers;
        public static readonly int Capacity = 94;

        public bool IsCalculated
        {
            get;
            private set;
        } = default(bool);
        public int Length { get; private set; }

        public ulong this[int i]
        {
            get
            {
                if (!IsCalculated)
                {                   
                    throw new NotCalculatedException("Not Calculated.","Hello World");
                }
                ThorwIfWrongIndex(i);
                return numbers[i];
            }
            private set
            {
                ThorwIfWrongIndex(i);
                numbers[i] = value;
            }
        }

        private void ThorwIfWrongIndex(int i)
        {
            if (i >= Length || i < 0)
            {
                throw new IndexOutOfRangeException($"Indes should belong to [0,{Length})");
            }
        }
        public void Caluclate()
        {
            IsCalculated = true;

            this[0] = 0;
            this[1] = 1;
            this[2] = 1;

            for (int i = 3; i < Length; i++)
            {
                checked
                {
                    this[i] = this[i - 1] + this[i - 2];
                }
            }
        }
    }
}
