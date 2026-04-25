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

        //GravityPoint point1; // добавил поле под первую точку
        //GravityPoint point2; // добавил поле под вторую точку

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


            //emitter.impactPoints.Add(new ColorPoint
            //{
            //    X = picDisplay.Width / 2 - 110,
            //    Y = picDisplay.Height / 2 - 100
            //});
            //emitter.impactPoints.Add(new ColorPoint
            //{
            //    X = picDisplay.Width / 2 + 220,
            //    Y = picDisplay.Height / 2 - 100
            //});
            //emitter.impactPoints.Add(new ColorPoint
            //{
            //    X = picDisplay.Width / 2 - 220,
            //    Y = picDisplay.Height / 2 - 100
            //});
            //emitter.impactPoints.Add(new ColorPoint
            //{
            //    X = picDisplay.Width / 2 + 330,
            //    Y = picDisplay.Height / 2 - 100
            //});
            //emitter.impactPoints.Add(new ColorPoint
            //{
            //    X = picDisplay.Width / 2 - 330,
            //    Y = picDisplay.Height / 2 - 100
            //});




            emitter.impactPoints.Add(new DelitePoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2 + 100
            });

            //// гравитон
            //emitter.impactPoints.Add(new GravityPoint
            //{
            //    X = (float)(picDisplay.Width * 0.25),
            //    Y = picDisplay.Height / 2
            //});

            //// в центре антигравитон
            //emitter.impactPoints.Add(new AntiGravityPoint
            //{
            //    X = picDisplay.Width / 2,
            //    Y = picDisplay.Height / 2
            //});

            //// снова гравитон
            //emitter.impactPoints.Add(new GravityPoint
            //{
            //    X = (float)(picDisplay.Width * 0.75),
            //    Y = picDisplay.Height / 2
            //});


            //this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            //{
            //    Direction = 0,
            //    Spreading = 10,
            //    SpeedMin = 10,
            //    SpeedMax = 10,
            //    ColorFrom = Color.Gold,
            //    ColorTo = Color.FromArgb(0, Color.Red),
            //    ParticlesPerTick = 10,
            //    X = picDisplay.Width / 2,
            //    Y = picDisplay.Height / 2,
            //};

            //emitters.Add(this.emitter); // все равно добавляю в список emitters, чтобы он рендерился и обновлялся


            // привязываем гравитоны к полям
            //point1 = new GravityPoint
            //{
            //    X = picDisplay.Width / 2 + 100,
            //    Y = picDisplay.Height / 2,
            //};
            //point2 = new GravityPoint
            //{
            //    X = picDisplay.Width / 2 - 100,
            //    Y = picDisplay.Height / 2,
            //};

            // привязываем поля к эмиттеру
            //emitter.impactPoints.Add(point1);
            //emitter.impactPoints.Add(point2);
        }



        // ну и обработка тика таймера, тут просто декомпозицию выполнили
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
            // Увеличиваем или уменьшаем диаметр на 10
            radarPoint.Radar += e.Delta > 0 ? 10 : -10;
            // Чтобы избежать отрицательного или нулевого диаметра, можно добавить минимальную проверку:
            if (radarPoint.Radar < 30) radarPoint.Radar = 30;
            // Максимум можно не ставить, но тогда круг станет огромным.
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            //radarPoint.X = e.X;
            //radarPoint.Y = e.Y;
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







        //private void tbDirection_Scroll(object sender, EventArgs e)
        //{
        //    emitter.Direction = tbDirection.Value; // направлению эмиттера присваиваем значение ползунка 
        //    lblDirection.Text = $"{tbDirection.Value}°"; // добавил вывод значения
        //}

        //private void tbGraviton_Scroll(object sender, EventArgs e)
        //{
        //    point1.Power = tbGraviton.Value;
        //}

        //private void tbGraviton2_Scroll(object sender, EventArgs e)
        //{
        //    point2.Power = tbGraviton2.Value;
        //}


    }
}
