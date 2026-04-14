using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod6
{
    class Emitter
    {

        public float GravitationX = 0;
        public float GravitationY = 0;

        List<Particle> particles = new List<Particle>();
        //public List<Point> gravityPoints = new List<Point>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();
        public int MousePositionX;
        public int MousePositionY;
        public int ParticlesCount = 500;
        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1; // уменьшаю здоровье
                                    // если здоровье кончилось
                if (particle.Life < 0)
                {
                    ResetParticle(particle);
                    //particle.Life = 20 + Particle.rand.Next(100); // это не трогаем
                    //                                              // новое начальное расположение частицы — это то, куда указывает курсор
                    //particle.X = MousePositionX;
                    //particle.Y = MousePositionY;
                    

                    //var direction = (double)Particle.rand.Next(360);
                    //var speed = 1 + Particle.rand.Next(10);

                    //particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                    //particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

                    //particle.Radius = 2 + Particle.rand.Next(10);
                }
                else
                {

                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }
                    // а это старый код, его не трогаем
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }


            // добавил генерацию частиц
            // генерирую не более 10 штук за тик
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < ParticlesCount) // пока частиц меньше 500 генерируем новые
                {
                    //// а у тут уже наш новый класс используем
                    //var particle = new ParticleColorful();
                    //// ну и цвета меняем
                    //particle.FromColor = Color.Yellow;
                    //particle.ToColor = Color.FromArgb(0, Color.Magenta);
                    //particle.X = MousePositionX;
                    //particle.Y = MousePositionY;
                    //particles.Add(particle);

                    var particle = new ParticleColorful();
                    particle.FromColor = Color.White;
                    particle.ToColor = Color.FromArgb(0, Color.Black);

                    ResetParticle(particle); // добавили вызов ResetParticle

                    particles.Add(particle);
                }
                else
                {
                    break; // а если частиц уже 500 штук, то ничего не генерирую
                }
            }
        }

        public void Render(Graphics g)
        {
            // ну тут так и быть уж сам впишу...
            // это то же самое что на форме в методе Render
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in impactPoints)
            {
                //g.FillEllipse(
                //    new SolidBrush(Color.Red),
                //    point.X - 5,
                //    point.Y - 5,
                //    10,
                //    10
                //);
                point.Render(g);
            }
        }

        // добавил новый метод, виртуальным, чтобы переопределять можно было
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = 20 + Particle.rand.Next(100);
            particle.X = MousePositionX;
            particle.Y = MousePositionY;

            var direction = (double)Particle.rand.Next(360);
            var speed = 1 + Particle.rand.Next(10);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = 2 + Particle.rand.Next(10);
        }

        public class TopEmitter : Emitter
        {
            public int Width; // длина экрана

            public override void ResetParticle(Particle particle)
            {
                base.ResetParticle(particle); // вызываем базовый сброс частицы, там жизнь переопределяется и все такое

                // а теперь тут уже подкручиваем параметры движения
                particle.X = Particle.rand.Next(Width); // позиция X -- произвольная точка от 0 до Width
                particle.Y = 0;  // ноль -- это верх экрана 

                particle.SpeedY = 1; // падаем вниз по умолчанию
                particle.SpeedX = Particle.rand.Next(-2, 2); // разброс влево и вправа у частиц 
            }
        }
    }
}
