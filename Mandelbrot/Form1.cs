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

        public Camera(int _screenWidth, int _screenHeight) {
            screenHeight = _screenHeight;
            screenWidth = _screenWidth;
        }

        public void zoom(double zoomChange) {
            zoomScale += zoomChange;
            double zoomAmount = 0.2 * (bottomRightCoord[0] - topLeftCoord[0]) * zoomChange;
            topLeftCoord[0] += zoomAmount;
            topLeftCoord[1] -= zoomAmount;
            bottomRightCoord[0] -= zoomAmount;
            bottomRightCoord[1] += zoomAmount;
        }

        public void pan(double dx, double dy) {
            topLeftCoord[0] += dx / (zoomScale * zoomScale);
            topLeftCoord[1] += dy / (zoomScale * zoomScale);
            bottomRightCoord[0] += dx / (zoomScale * zoomScale);
            bottomRightCoord[1] += dy / (zoomScale * zoomScale);

        }

        public double[] calculateAxisScales() {
            xScale = (bottomRightCoord[0] - topLeftCoord[0]) / (double)screenWidth;
            yScale = (bottomRightCoord[1] - topLeftCoord[1]) / (double)screenHeight;
            double[] result = { xScale, yScale };
            return result;
        }

        public double[] screenToCameraCoords(int x, int y) {
            double[] result = { x * xScale + topLeftCoord[0], y * yScale + topLeftCoord[1] };
            return result;
        }

        public double[] getTopLeftCoord() {
            return topLeftCoord;
        }
    }

    public partial class Form1 : Form {
        static int maxIterations = 100;
        static string renderMethod = "Single-threaded Naive";
        static int threadCount = 4;

        int[,] iteratonCounts = new int[0, 0];
        Bitmap[] bitmaps = new Bitmap[16];
        Bitmap theBitmap;
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
            theBitmap = new Bitmap(canvas.Width, canvas.Height);
        }

        private void drawMandelbrot() {
            DateTime startTime = DateTime.Now;
            switch (renderMethod) {
                case "Single-threaded Naive":
                    drawMandelbrotNaive();
                    break;
                case "Multi-threaded Naive":
                    drawMandelbrotNaiveMultithreaded();
                    break;
                case "Bitmap Stitching":
                    drawMandelbrotMultipleBitmaps();
                    break;
                case "Doubles Only":
                    drawMandelbrotDoublesOnly();
                    break;
                case "Multi-threaded Doubles":
                    drawMandelbrotMultithreadedDoubles();
                    break;
                case "Single-threaded Algebra Optimized":
                    drawMandelbrotAlgebraicSimplification();
                    break;
                case "Multi-threaded Algebra Optimized":
                    drawMandelbrotMultithreadedAlgebraicSimplificiaction();
                    break;
                case "Reduced Camera":
                    drawMandelbrotReducedCamera();
                    break;
                case "Multi-threaded Reduced Camera":
                    drawMandelbrotMultithreadedReducedCamera();
                    break;
                case "Single-threaded Final":
                    drawMandelbrotFinal();
                    break;
                case "Multi-threaded Final":
                    drawMandelbrotFinalMT();
                    break;
                default:
                    Debug.WriteLine("Tried to use an unknown rendering method...");
                    canvas.Image = null;
                    break;
            }

            TimeSpan elapsed = (DateTime.Now - startTime);
            renderTimeLabel.Text = "Render Time: " + Math.Floor(elapsed.TotalMilliseconds) + "ms";
        }

        private void drawMandelbrotFinal() {
            //camera scales
            double[] scales = camera.calculateAxisScales();
            double xScale = scales[0];
            double yScale = scales[1];
            //position in complex plane
            double initalX = camera.getTopLeftCoord()[0];
            double ca; //x0
            double cb = camera.getTopLeftCoord()[1]; //y0
            //iterated variables
            double za;  //(x) real
            double zb;  //(y) imaginary
            double za2; //(x2)
            double zb2; //(y2)
            int i;

            for (int y = 0; y < canvas.Height; y++) {
                ca = initalX;
                for (int x = 0; x < canvas.Width; x++) {
                    za = 0; //real (x)
                    zb = 0; //imaginary (y)
                    za2 = 0; //(x2)
                    zb2 = 0; //(y2)
                    i = 0;
                    while ((za2 + zb2) < 4.0 && i < maxIterations) {
                        zb = 2 * za * zb + cb;
                        za = za2 - zb2 + ca;
                        za2 = za * za;
                        zb2 = zb * zb;
                        i++;
                    }
                    theBitmap.SetPixel(x, y, palette[i - 1]);
                    ca += xScale;
                }
                cb += yScale;
            }
            canvas.Image = theBitmap;
        }

        private void drawMandelbrotFinalMT() { 
        
        }


        #region BITMAP STITCHING
        private void drawMandelbrotMultipleBitmaps() {
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
        #endregion

        #region REDUCED CAMERA
        private void drawMandelbrotMultithreadedReducedCamera() {
            double[] scales = camera.calculateAxisScales();
            double xScale = scales[0];
            double yScale = scales[1];

            Thread[] threads = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++) {
                int startY = (canvas.Height / threadCount) * i;
                int endY = (canvas.Height / threadCount) * (i + 1);
                threads[i] = new Thread(() => {
                    calculateMandelbrotStripReducedCamera(startY, endY, xScale, yScale);
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

        private void calculateMandelbrotStripReducedCamera(int startY, int endY, double xScale, double yScale) {
            //position in complex plane
            double ca = camera.getTopLeftCoord()[0]; //x0
            double cb = camera.screenToCameraCoords(0, startY)[1];
            for (int y = startY; y < endY; y++) {
                ca = camera.getTopLeftCoord()[0];
                for (int x = 0; x < canvas.Width; x++) {
                    double za = 0; //real (x)
                    double zb = 0; //imaginary (y)
                    double za2 = 0; //(x2)
                    double zb2 = 0; //(y2)
                    int i = 0;

                    while ((za2 + zb2) < 4.0 && i < maxIterations) {
                        i++;
                        zb = 2 * za * zb + cb;
                        za = za2 - zb2 + ca;
                        za2 = za * za;
                        zb2 = zb * zb;
                    }

                    iteratonCounts[x, y] = i - 1;
                    ca += xScale;
                }
                cb += yScale;
            }
        }

        private void drawMandelbrotReducedCamera() {
            double[] scales = camera.calculateAxisScales();
            double xScale = scales[0];
            double yScale = scales[1];
            Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);

            //position in complex plane
            double ca = camera.getTopLeftCoord()[0]; //x0
            double cb = camera.getTopLeftCoord()[1]; //y0
            for (int y = 0; y < canvas.Height; y++) {
                ca = camera.getTopLeftCoord()[0];
                for (int x = 0; x < canvas.Width; x++) {
                    double za = 0; //real (x)
                    double zb = 0; //imaginary (y)
                    double za2 = 0; //(x2)
                    double zb2 = 0; //(y2)
                    int i = 0;
                    while ((za2 + zb2) < 4.0 && i < maxIterations) {
                        i++;
                        zb = 2 * za * zb + cb;
                        za = za2 - zb2 + ca;
                        za2 = za * za;
                        zb2 = zb * zb;
                    }
                    bmp.SetPixel(x, y, palette[i - 1]);
                    ca += xScale;
                }
                cb += yScale;
            }
            canvas.Image = bmp;
        }
        #endregion

        #region ALGEBRAIC SIMPLIFICATION
        private void drawMandelbrotMultithreadedAlgebraicSimplificiaction() {
            camera.calculateAxisScales();

            Thread[] threads = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++) {
                int startY = (canvas.Height / threadCount) * i;
                int endY = (canvas.Height / threadCount) * (i + 1);
                threads[i] = new Thread(() => {
                    calculateMandelbrotStripAlgebraicSimplification(startY, endY);
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

        private void calculateMandelbrotStripAlgebraicSimplification(int startY, int endY) {
            for (int y = startY; y < endY; y++) {
                for (int x = 0; x < canvas.Width; x++) {
                    double[] coords = camera.screenToCameraCoords(x, y); //position in complex plane
                    double ca = coords[0]; //real (x0)
                    double cb = coords[1]; //imaginary (y0)
                    double za = 0; //real (x)
                    double zb = 0; //imaginary (y)
                    double za2 = 0; //(x2)
                    double zb2 = 0; //(y2)
                    int i = 0;

                    while ((za2 + zb2) < 4.0 && i < maxIterations) {
                        i++;
                        zb = 2 * za * zb + cb;
                        za = za2 - zb2 + ca;
                        za2 = za * za;
                        zb2 = zb * zb;
                    }

                    iteratonCounts[x, y] = i - 1;
                }
            }
        }

        private void drawMandelbrotAlgebraicSimplification() {
            camera.calculateAxisScales();
            Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);

            for (int y = 0; y < canvas.Height; y++) {
                for (int x = 0; x < canvas.Width; x++) {
                    double[] coords = camera.screenToCameraCoords(x, y); //position in complex plane
                    double ca = coords[0]; //real (x0)
                    double cb = coords[1]; //imaginary (y0)
                    double za = 0; //real (x)
                    double zb = 0; //imaginary (y)
                    double za2 = 0; //(x2)
                    double zb2 = 0; //(y2)
                    int i = 0;
                    while ((za2 + zb2) < 4.0 && i < maxIterations) {
                        i++;
                        zb = 2 * za * zb + cb;
                        za = za2 - zb2 + ca;
                        za2 = za * za;
                        zb2 = zb * zb;
                    }
                    bmp.SetPixel(x, y, palette[i - 1]);

                }
            }
            canvas.Image = bmp;
        }
        #endregion

        #region DOUBLES ONLY
        private void drawMandelbrotMultithreadedDoubles() {
            camera.calculateAxisScales();

            Thread[] threads = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++) {
                int startY = (canvas.Height / threadCount) * i;
                int endY = (canvas.Height / threadCount) * (i + 1);
                threads[i] = new Thread(() => {
                    calculateMandelbrotStripDoubles(startY, endY);
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

        private void calculateMandelbrotStripDoubles(int startY, int endY) {
            for (int y = startY; y < endY; y++) {
                for (int x = 0; x < canvas.Width; x++) {
                    double[] coords = camera.screenToCameraCoords(x, y); //position in complex plane
                    double za = 0; //real
                    double zb = 0; //imaginary
                    double ca = coords[0]; //real 
                    double cb = coords[1]; //imaginary

                    int i = 0;
                    while (i < maxIterations && ((za * za) + (zb * zb)) < 4.0) {
                        i++;
                        //square z
                        double tempA = (za * za) - (zb * zb);
                        zb = 2.0 * za * zb;
                        za = tempA;
                        //add c to z
                        za += ca;
                        zb += cb;
                    }

                    iteratonCounts[x, y] = i - 1;
                }
            }
        }

        private void drawMandelbrotDoublesOnly() {
            camera.calculateAxisScales();
            Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);

            for (int y = 0; y < canvas.Height; y++) {
                for (int x = 0; x < canvas.Width; x++) {
                    double[] coords = camera.screenToCameraCoords(x, y); //position in complex plane
                    double za = 0; //real
                    double zb = 0; //imaginary
                    double ca = coords[0]; //real 
                    double cb = coords[1]; //imaginary

                    int i = 0;
                    while (i < maxIterations && ((za * za) + (zb * zb)) < 4.0) {
                        i++;
                        //square z
                        double tempA = (za * za) - (zb * zb);
                        zb = 2.0 * za * zb;
                        za = tempA;
                        //add c to z
                        za += ca;
                        zb += cb;
                    }
                    bmp.SetPixel(x, y, palette[i - 1]);

                }
            }

            canvas.Image = bmp;
        }
        #endregion DOUBLES ONLY

        #region NAIVE
        private void drawMandelbrotNaive() {
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

        private void drawMandelbrotNaiveMultithreaded() {
            camera.calculateAxisScales();

            Thread[] threads = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++) {
                int startY = (canvas.Height / threadCount) * i;
                int endY = (canvas.Height / threadCount) * (i + 1);
                threads[i] = new Thread(() => {
                    calculateMandelbrotStripNaive(startY, endY);
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

        private void calculateMandelbrotStripNaive(int startY, int endY) {
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

                    iteratonCounts[x, y] = i - 1;
                }
            }
        }
        #endregion

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

        private void toolStripDropDownButton2_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            threadCount = Int32.Parse(e.ClickedItem.Text);
            toolStripDropDownButton2.Text = e.ClickedItem.Text;
            drawMandelbrot();
        }
        #endregion
    }
}

