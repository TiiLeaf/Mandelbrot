using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot {
    public class Complex {
        public double a; //real
        public double b; //imaginary

        public Complex(double a, double b) {
            this.a = a; this.b = b;
        }

        public void square() {
            double tempA = (a * a) - (b * b);
            b = 2.0 * a * b;
            a = tempA;
        }

        public double magSquared() {
            return ((a * a) + (b * b));
        }

        public void add(Complex c) {
            a += c.a;
            b += c.b;
        }
    }
}
