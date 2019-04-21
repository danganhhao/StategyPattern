// De bai:
/* Cho mang A gom N phan tu (N>1)
 * a) Tra ve vi tri xuat hien dau tien cua so lon nhat trong mang A (so nguyen)
 * b) Tra ve vi tri xuat hien cuoi cung cua so nguyen to nho nhat trong mang A (so nguyen)
 * c) Tra ve vi tri xuat hien bat ky cua so am lon nhat trong mang A (so nguyen)
 * d) Tra ve vi tri xuat hien dau tien cua SV co DTB cao nhat lop (va co DRL cao nhat trong so 
 * nhung nguoi co DTB cao nhat lop).
 * Tra ve -1 neu khong tim thay.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StategyPattern
{
    public class Program
    {
        public struct Student
        {
            public int MSSV;
            public string HoTen;
            public float DTB;
            public int DRL;
            public Student(int MSSV, string HoTen, float DTB, int DRL)
            {
                this.MSSV = MSSV;
                this.HoTen = HoTen;
                this.DTB = DTB;
                this.DRL = DRL;
            }
        };

        public static void Main(string[] args)
        {
            object[] A = { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine("A) Input A = { 1, 2, 3, 4, 5, 6, 7 }");
            Console.WriteLine("Result " + FindA(A));

            object[] B = { 2, 4, 6, 7, 8, 2, 5 };
            Console.WriteLine("B) Input B = { 2, 4, 6, 7, 8, 2, 5 }");
            Console.WriteLine("Result " + FindB(B));

            object[] C = { 6, -3, 7, -5, -2, 7 };
            Console.WriteLine("C) Input C = { 6, -3, 7, -5, -2, 7 }");
            Console.WriteLine("Result " + FindC(C));

            object[] student = new object[3];
            student[0] = new Student(0, "Nguyen Van A", 9.0f, 90);
            student[1] = new Student(1, "Nguyen Van B", 8.0f, 95);
            student[2] = new Student(2, "Nguyen Van C", 9.0f, 95);
            Console.WriteLine("D) Input D = {0, \"Nguyen Van A\", 9.0f, 90} ; {1, \"Nguyen Van B\", 8.0f, 95} ; {2, \"Nguyen Van C\", 9.0f, 95}");
            Console.WriteLine("Result " + FindD(student));

        }


        private static int FindEverything(object[] a, Validator validator, Comparator comparator, EqualChecker equalChecker, Updater updater)
        {
            int result = -1;
            int n = a.Length;
            for (int i = 0; i < n; i++)
                if (validator.Check(a[i]))
                    if (result == -1) result = i;
                    else if (comparator.Check(a[result], a[i]))
                        result = i;
                    else if (equalChecker.Check(a[result], a[i]))
                        if (updater.Check(a[result], a[i]))
                            result = i;
            return result;
        }


        private static int FindA(object[] a)
        {
            Validator validator = new ValidatorExtendNormalNumber();
            Comparator comparator = new ComparatorExtendIsWorse();
            EqualChecker equalChecker = new EqualCheckerNumber();
            Updater updater = new FirstPosition();
            return FindEverything(a, validator,comparator,equalChecker,updater);
        }

        private static int FindB(object[] a)
        {
            Validator validator = new ValidatorExtendPrimeNumber();
            Comparator comparator = new ComparatorExtendIsBetter();
            EqualChecker equalChecker = new EqualCheckerNumber();
            Updater updater = new LastPosition();
            return FindEverything(a, validator, comparator, equalChecker, updater);
        }

        private static int FindC(object[] a)
        {
            Validator validator = new ValidatorExtendNegativeNumber();
            Comparator comparator = new ComparatorExtendIsWorse();
            EqualChecker equalChecker = new EqualCheckerNumber();
            Updater updater = new AnyPosition();
            return FindEverything(a, validator, comparator, equalChecker, updater);
        }

        private static int FindD(object[] a)
        {
            Validator validator = new ValidatorExtendStudendObject();
            Comparator comparator = new ComparatorExtendStudentObject();
            EqualChecker equalChecker = new EqualCheckerStudentObject();
            Updater updater = new UpdatePositionStudent();
            return FindEverything(a, validator, comparator, equalChecker, updater);
        }
    }
}
