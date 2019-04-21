using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StategyPattern
{
    public abstract class Updater
    {
        public virtual bool Check(object A, object B)
        {
            return false;
        }
    }

    public class FirstPosition:Updater
    {
        public override bool Check(object A, object B)
        {
            return false;
        }
    }

    public class LastPosition : Updater
    {
        public override bool Check(object A, object B)
        {
            return true;
        }
    }

    public class AnyPosition : Updater
    {
        public override bool Check(object A, object B)
        {
            return true;
        }
    }
    public class UpdatePositionStudent : Updater
    {
        public override bool Check(object A, object B)
        {
            Program.Student studentA = (Program.Student)A;
            Program.Student studentB = (Program.Student)B;
            return studentA.DRL < studentB.DRL;
        }
    }

}
