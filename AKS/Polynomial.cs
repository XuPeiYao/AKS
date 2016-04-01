using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AKS {
    public class Polynomial :ICloneable {
        
        public Dictionary<BigInteger, BigInteger> Data = new Dictionary<BigInteger, BigInteger>();

        public object Clone() {
            var result = new Polynomial();
            Dictionary<BigInteger, BigInteger> data = new Dictionary<BigInteger, BigInteger>();
            foreach (var kp in Data) data[kp.Key] = kp.Value;
            result.Data = data;
            return result;
        }

        public static Polynomial operator +(Polynomial A, Polynomial B) {
            var result = (Polynomial)A.Clone();
            foreach(var value in B.Data) {
                if (!result.Data.ContainsKey(value.Key)) result.Data[value.Key] = 0;
                result.Data[value.Key] += value.Value;
                if (result.Data[value.Key] == 0) result.Data.Remove(value.Key);
            }
            return result;
        }

        public static Polynomial operator +(Polynomial A,BigInteger B) {
            var b = new Polynomial();
            b.Data[0] = B;
            return A + b;
        }

        public static Polynomial operator *(Polynomial A, Polynomial B) {
            var result = new Polynomial();
            
            foreach (var value0 in A.Data) {
                foreach (var value1 in B.Data) {
                    var NewPower = value0.Key + value1.Key;
                    var NewCoeff = value0.Value * value1.Value;
                    if (!result.Data.ContainsKey(NewPower)) result.Data[NewPower] = 0;
                    result.Data[NewPower] += NewCoeff;
                }
            }

            foreach(var kp in result.Data) {
                if (kp.Value == 0) result.Data.Remove(kp.Key);
            }

            return result;
        }

        public static Polynomial operator *(Polynomial A, BigInteger B) {
            var b = new Polynomial();
            b.Data[0] = B;
            return A * b;
        }

        public static Polynomial operator -(Polynomial A) {
            return A * -1;
        }
        public static Polynomial operator -(Polynomial A, Polynomial B) {
            return A + -B;
        }
    }
}
