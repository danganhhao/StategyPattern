using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StategyPattern
{
    public abstract class Comparator
    {
        public virtual bool Check(object A, object B)
        {
            return false;
        }
    }

    public class ComparatorExtendIsBetter: Comparator
    {
        public override bool Check(object A, object B)
        {
            int valueA = (int)A, valueB = (int)B;
            return valueA > valueB;
        }
    }

    public class ComparatorExtendIsWorse : Comparator
    {
        public override bool Check(object A, object B)
        {
            int valueA = (int)A, valueB = (int)B;
            return valueA < valueB;
        }
    }

    public class ComparatorExtendStudentObject : Comparator
    {
        public override bool Check(object A, object B)
        {
            Program.Student studentA = (Program.Student)A;
            Program.Student studentB = (Program.Student)B;
            return studentA.DTB < studentB.DTB;
        }
    }
}
