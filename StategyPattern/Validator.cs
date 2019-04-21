using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StategyPattern
{
    public abstract class Validator
    {
        public virtual bool Check(object A)
        {
            return false;
        }
    }

    public class ValidatorExtendNormalNumber: Validator
    {
        public override bool Check(object A)
        {
            int i = 0;
            if (Object.ReferenceEquals(A.GetType(), i.GetType()))
                return true;
            return false;
        }
    }

    public class ValidatorExtendPrimeNumber: Validator
    {
        public override bool Check(object A)
        {
            int value = (int)A;
            return isPrimeNumber(value);
        }

        public bool isPrimeNumber(int a)
        {
            for (int i=2; i<= a/2; i++)
                if (a % i == 0) return false;
            return true;
        }
    }

    public class ValidatorExtendNegativeNumber: Validator
    {
        public override bool Check(object A)
        {
            int value = (int)A;
            return value < 0;
        }
    }

    public class ValidatorExtendStudendObject : Validator
    {
        public override bool Check(object A)
        {
            Program.Student temp;
            temp.MSSV = -1; temp.HoTen = "Nguyen Van A"; temp.DTB = 0.0f; temp.DRL = 0;
            Program.Student student = (Program.Student)A;
            if (Object.ReferenceEquals(student.GetType(), temp.GetType()))
                return true;
            return false;
        }
    }
}
