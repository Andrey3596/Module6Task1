using static Mod6.Emitter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mod6
{
    public partial class Form1 : Form
    {
        List<Particle> particles = new List<Particle>();
        private int MousePositionX = 0;
        private int MousePositionY = 0;

        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; // добавим поле для эмиттера


        RadarPoint radarPoint;
        ColorPoint colorPointOne;
        ColorPoint colorPointTwo;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);


            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };

            //РАДАР
            radarPoint = new RadarPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2 + 100
            };
            emitter.impactPoints.Add(radarPoint);


            colorPointOne = new ColorPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2 - 100
            };
            emitter.impactPoints.Add(colorPointOne);

            colorPointTwo = new ColorPoint
            {
                X = picDisplay.Width / 2 + 110,
                Y = picDisplay.Height / 2 - 100
            };
            emitter.impactPoints.Add(colorPointTwo);

            emitter.impactPoints.Add(new DelitePoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2 + 100
            });

        }



        // ну и обработка тика таймера тут просто декомпозицию выполнили
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // каждый тик обновляем систему

            using (var g = Graphics.FromImage(picDisplay.Image))
            {

                g.Clear(Color.Black);
                emitter.Render(g); // рендерим систему
            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            var delitePoint = new DelitePoint
            {
                X = e.X,
                Y = e.Y,
                Radar = 50
            };
            emitter.impactPoints.Add(delitePoint);
        }

        private void PicDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            //// Увеличиваем или уменьшаем диаметр на 10
            //radarPoint.Radar += e.Delta > 0 ? 10 : -10;
            //// Чтобы избежать отрицательного или нулевого диаметра
            //if (radarPoint.Radar < 30) radarPoint.Radar = 30;


            foreach (var point in emitter.impactPoints)
            {

                float dx = point.X - e.X;
                float dy = point.Y - e.Y;
                float distance = (float)Math.Sqrt(dx * dx + dy * dy);


                int currentRadius = 0;

                if (point is RadarPoint rp) currentRadius = rp.Radar;
                else if (point is ColorPoint cp) currentRadius = cp.Radar;
                else if (point is DelitePoint dp) currentRadius = dp.Radar;
                else continue;


                if (distance <= currentRadius / 2)
                {
                    int delta = e.Delta > 0 ? 10 : -10;


                    if (point is RadarPoint radar)
                        radar.Radar = Math.Max(30, radar.Radar + delta);
                    else if (point is ColorPoint color)
                        color.Radar = Math.Max(20, color.Radar + delta);
                    else if (point is DelitePoint del)
                        del.Radar = Math.Max(20, del.Radar + delta);

                    break;
                }
            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            radarPoint.X = e.X;
            radarPoint.Y = e.Y;
        }

        private void trackBarXOne_Scroll(object sender, EventArgs e)
        {
            colorPointOne.X = trackBarXOne.Value;
        }

        private void trackBarYOne_Scroll(object sender, EventArgs e)
        {
            colorPointOne.Y = trackBarYOne.Value;
        }

        private void trackBarXTwo_Scroll(object sender, EventArgs e)
        {
            colorPointTwo.X = trackBarXTwo.Value;
        }

        private void trackBarYTwo_Scroll(object sender, EventArgs e)
        {
            colorPointTwo.Y = trackBarYTwo.Value;
        }



        private void trackBarCol_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesCount = trackBarCol.Value;
        }

        
    }
}
