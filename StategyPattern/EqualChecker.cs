using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StategyPattern
{
    public abstract class EqualChecker
    {
        public virtual bool Check(object A, object B)
        {
            return false;
        }
    }

    public class EqualCheckerNumber: EqualChecker
    {
        public override bool Check(object A, object B)
        {
            int valueA = (int)A, valueB = (int)B;
            return valueA == valueB;
        }
    }

    public class EqualCheckerStudentObject: EqualChecker
    {
        public override bool Check(object A, object B)
        {
            Program.Student studentA = (Program.Student)A;
            Program.Student studentB = (Program.Student)B;
            if (Math.Abs(studentA.DTB - studentB.DTB)<= 0.0001f)
                return true;
            return false;
        }
    }
}
