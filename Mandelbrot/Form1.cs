namespace Mandelbrot {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e) {
            drawMandelbrot();
        }
        private void drawMandelbrot() {
            //generate palette
            int maxIterations = 64;
            Color[] palette = new Color[maxIterations];
            for (int i = 0; i < maxIterations; i++) {
                palette[i] = Color.FromArgb(255 * i / maxIterations, (i * 2) % 255, (i * 5) % 255);
            }
            palette[maxIterations - 1] = Color.Black;

            //calculate 'camera' values
            double[] topLeftCoord = { -2.0, 1.5 };
            double[] bottomRightCoord = { 1.0, -1.5 };
            double xScale = ((bottomRightCoord[0] - topLeftCoord[0]) / (double)mandelbrotPicture.Width);
            double yScale = ((bottomRightCoord[1] - topLeftCoord[1]) / (double)mandelbrotPicture.Height);

            Bitmap bmp = new Bitmap(mandelbrotPicture.Width, mandelbrotPicture.Height);
            for (int y = 0; y < mandelbrotPicture.Height; y++) {
                for (int x = 0; x < mandelbrotPicture.Width; x++) {
                    Complex c = new Complex(x * xScale + topLeftCoord[0], y * yScale + topLeftCoord[1]); //position in complex plane
                    Complex z = new Complex(0, 0); //the number to be iterated

                    int i = 0;
                    while (i < maxIterations && z.magSquared() < 4.0) {
                        i++;
                        z.square();
                        z.add(c);
                    }
                    bmp.SetPixel(x, y, palette[i - 1]);

                }
            }
            mandelbrotPicture.Image = bmp;
        }


    }
}

