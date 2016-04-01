using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AKS {
    class Program {
        static void Main(string[] args) {
            Stopwatch watch = new Stopwatch();//建構碼表用以計算耗時
            watch.Start();
            AKSRangePrime(BigInteger.Parse("1000")).ForEach(x=>Console.WriteLine(x));
            watch.Stop();
            Console.WriteLine("運算耗時:" + watch.Elapsed);
            Console.ReadKey();
        }

        public static List<BigInteger> AKSRangePrime(BigInteger Max) {
            List<BigInteger> list = new List<BigInteger>();
            var a = new Polynomial(); ;
            a.Data[0] = -1;
            a.Data[1] = 1;
            var a_ = (Polynomial)a.Clone();
            for (int i = 2; i <= Max; i++) {
                a *= a_;
                if (list.Any(x => i % x == 0)) continue;

                var b = new Polynomial(); ;
                b.Data[0] = -1;
                b.Data[i] = 1;                

                if ((a - b).Data.All(x => x.Value % i == 0)) {
                    list.Add(i);
                }
            }
            return list;
        }

        public static bool IsPrime(BigInteger Value) {
            var a = new Polynomial(); ;
            a.Data[0] = -1;
            a.Data[1] = 1;

            var a_ = (Polynomial)a.Clone();
            for (int i = 1; i < Value; i++) a_ *= a;

            var b = new Polynomial(); ;
            b.Data[Value] = 1;
            b.Data[0] = -1;

            var result = (a_ - b);

            return result.Data.Where(x => x.Key > 0).All(x => x.Value % Value == 0);
        }
    }
}
