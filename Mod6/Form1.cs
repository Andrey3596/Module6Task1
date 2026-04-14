namespace Mod6
{
    public partial class Form1 : Form
    {
        List<Particle> particles = new List<Particle>();
        private int MousePositionX = 0;
        private int MousePositionY = 0;

        Emitter emitter = new Emitter();
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            emitter.gravityPoints.Add(new Point(
                picDisplay.Width / 2, picDisplay.Height / 2
            ));
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

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }
    }
}
