using static Mod6.Emitter;

namespace Mod6
{
    public partial class Form1 : Form
    {
        List<Particle> particles = new List<Particle>();
        private int MousePositionX = 0;
        private int MousePositionY = 0;

        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; // добавим поле дл€ эмиттера




        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);


            //emitter = new TopEmitter
            //{
            //    Width = picDisplay.Width,
            //    GravitationY = 0.25f
            //};
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


            this.emitter = new Emitter // создаю эмиттер и прив€зываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter); // все равно добавл€ю в список emitters, чтобы он рендерилс€ и обновл€лс€
        }



        // ну и обработка тика таймера, тут просто декомпозицию выполнили
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // каждый тик обновл€ем систему

            using (var g = Graphics.FromImage(picDisplay.Image))
            {

                g.Clear(Color.Black);
                emitter.Render(g); // рендерим систему
            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value; // направлению эмиттера присваиваем значение ползунка 
            lblDirection.Text = $"{tbDirection.Value}∞"; // добавил вывод значени€
        }
    }
}
