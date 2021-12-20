using System.Diagnostics;

namespace Mandelbrot {
    public struct Camera {
        int screenWidth;
        int screenHeight;
        double xScale = 1.0;
        double yScale = 1.0;
        double[] topLeftCoord = { -2.0, 1.5 };
        double[] bottomRightCoord = { 1.0, -1.5 };
        double zoomScale = 1.0;
        double[] offset = { 0.0, 0.0 };

        public Camera(int _screenWidth, int _screenHeight) {
            screenHeight = _screenHeight;
            screenWidth = _screenWidth;
        }

        public void zoom(double zoomChange) {
            zoomScale += zoomScale * zoomChange * 0.3;
            topLeftCoord[0] = -2.0 / zoomScale;
            topLeftCoord[1] = 1.5 / zoomScale;
            bottomRightCoord[0] = 1.0 / zoomScale;
            bottomRightCoord[1] = -1.5 / zoomScale;
        }

        public void pan(double dx, double dy) {
            offset[0] += dx / zoomScale;
            offset[1] += dy / zoomScale;
        }

        public void calculateAxisScales() {
            xScale = (bottomRightCoord[0] - topLeftCoord[0]) / (double)screenWidth;
            yScale = (bottomRightCoord[1] - topLeftCoord[1]) / (double)screenHeight;

        }

        public double[] screenToCameraCoords(int x, int y) {
            double[] result = { x * xScale + topLeftCoord[0] + offset[0], y * yScale + topLeftCoord[1] + offset[1] };
            return result;
        }
    }

    public partial class Form1 : Form {
        static int maxIterations = 100;
        static string renderMethod = "Single-threaded";

        int[,] iteratonCounts = new int[0,0];
        Bitmap[] bitmaps = new Bitmap[16];
        static Camera camera;
        static Color[] palette = new Color[maxIterations];

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e) {
            camera = new Camera(canvas.Width, canvas.Height);
            iteratonCounts = new int[canvas.Width, canvas.Height];
            for (int i = 0; i < maxIterations; i++) {
                palette[i] = Color.FromArgb(i / maxIterations * 255, (i * 2) % 255, (i * 5) % 255);
            }
            palette[maxIterations - 1] = Color.Black;
            drawMandelbrot();
        }

        private void drawMandelbrot() {
            DateTime startTime = DateTime.Now;
            switch (renderMethod) {
                case "Multi-threaded":
                    drawMandelbrotMultithreaded(8);
                    break;
                case "Multi-threaded (16)":
                    drawMandelbrotMultithreaded(16);
                    break;
                case "Bitmap Stitching":
                    drawMandelbrotMultipleBitmaps(8);
                    break;
                case "Bitmap Stitching (16)":
                    drawMandelbrotMultipleBitmaps(16);
                    break;
                default:
                    drawMandelbrotSingleThread();
                    break;
            }

            TimeSpan elapsed = (DateTime.Now - startTime);
            renderTimeLabel.Text = "Render Time: " + Math.Floor(elapsed.TotalMilliseconds) + "ms";
        }

        private void drawMandelbrotMultipleBitmaps(int threadCount) {
            camera.calculateAxisScales();
            Thread[] threads = new Thread[threadCount];

            for (int i = 0; i < threadCount; i++) {
                bitmaps[i] = new Bitmap(canvas.Width, canvas.Height);
            }

            for (int i = 0; i < threadCount; i++) {
                int startY = (canvas.Height / threadCount) * i;
                int endY = (canvas.Height / threadCount) * (i + 1);
                int index = i;
                threads[i] = new Thread(() => {
                    drawMandelbrotStrip(startY, endY, index);
                });
                threads[i].Name = "Worker #" + i;
                threads[i].Start();
            }

            for (int i = 0; i < threadCount; i++) {
                threads[i].Join();
            }

            Graphics g = canvas.CreateGraphics();
            for (int i = 0; i < threadCount; i++) {
                g.DrawImage(bitmaps[i], new Point(0, 0));
            }
        }

        private void drawMandelbrotStrip(int startY, int endY, int index) {
            for (int y = startY; y < endY; y++) {
                for (int x = 0; x < canvas.Width; x++) {
                    double[] coords = camera.screenToCameraCoords(x, y);
                    Complex c = new Complex(coords[0], coords[1]); //position in complex plane
                    Complex z = new Complex(0, 0); //the number to be iterated

                    int i = 0;
                    while (i < maxIterations && z.magSquared() < 4.0) {
                        i++;
                        z.square();
                        z.add(c);
                    }

                    bitmaps[index].SetPixel(x, y, palette[i - 1]);
                }
            }
        }

        private void drawMandelbrotMultithreaded(int threadCount) {
            camera.calculateAxisScales();

            Thread[] threads = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++) {
                int startY = (canvas.Height / threadCount) * i;
                int endY = (canvas.Height / threadCount) * (i + 1);
                threads[i] = new Thread(() => {
                    calculateMandelbrotStrip(startY, endY);
                });
                threads[i].Name = "Worker #" + i;
                threads[i].Start();
            }

            for (int i = 0; i < threadCount; i++) {
                threads[i].Join();
            }

            Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);
            for (int y = 0; y < canvas.Height; y++) {
                for (int x = 0; x < canvas.Width; x++) {
                    bmp.SetPixel(x, y, palette[iteratonCounts[x, y]]);
                }
            }
            canvas.Image = bmp;
        }

        private void calculateMandelbrotStrip(int startY, int endY) {
            for (int y = startY; y < endY; y++) {
                for (int x = 0; x < canvas.Width; x++) {
                    double[] coords = camera.screenToCameraCoords(x, y);
                    Complex c = new Complex(coords[0], coords[1]); //position in complex plane
                    Complex z = new Complex(0, 0); //the number to be iterated

                    int i = 0;
                    while (i < maxIterations && z.magSquared() < 4.0) {
                        i++;
                        z.square();
                        z.add(c);
                    }

                    iteratonCounts[x,y] = i - 1;
                }
            }
        }

        private void drawMandelbrotSingleThread() {
            camera.calculateAxisScales();
            Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);

            for (int y = 0; y < canvas.Height; y++) {
                for (int x = 0; x < canvas.Width; x++) {
                    double[] coords = camera.screenToCameraCoords(x, y);
                    Complex c = new Complex(coords[0], coords[1]); //position in complex plane
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

            canvas.Image = bmp;
        }

        #region UI_EVENTS
        private void toolStripButton1_Click(object sender, EventArgs e) {
            camera.zoom(1);
            drawMandelbrot();
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            camera.zoom(-1);
            drawMandelbrot();
        }

        private void toolStripButton3_Click(object sender, EventArgs e) {
            camera.pan(-0.25, 0);
            drawMandelbrot();
        }

        private void toolStripButton4_Click(object sender, EventArgs e) {
            camera.pan(0.25, 0);
            drawMandelbrot();
        }

        private void toolStripButton5_Click(object sender, EventArgs e) {
            camera.pan(0, 0.25);
            drawMandelbrot();
        }

        private void toolStripButton6_Click(object sender, EventArgs e) {
           camera.pan(0.0, -0.25);
           drawMandelbrot();
        }

        private void toolStripDropDownButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            renderMethod = e.ClickedItem.Text;
            toolStripDropDownButton1.Text = e.ClickedItem.Text;
            drawMandelbrot();
        }
        #endregion
    }
}

