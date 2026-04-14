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
        public float GravitationY = 1;

        List<Particle> particles = new List<Particle>();
        public List<Point> gravityPoints = new List<Point>();
        public int MousePositionX;
        public int MousePositionY;

        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1; // уменьшаю здоровье
                                    // если здоровье кончилось
                if (particle.Life < 0)
                {
                    particle.Life = 20 + Particle.rand.Next(100); // это не трогаем
                                                                  // новое начальное расположение частицы — это то, куда указывает курсор
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
                    

                    var direction = (double)Particle.rand.Next(360);
                    var speed = 1 + Particle.rand.Next(10);

                    particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                    particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

                    particle.Radius = 2 + Particle.rand.Next(10);
                }
                else
                {


                    // сделаем сначала для одной точки
                    // и так считаем вектор притяжения к точке
                    float gX = gravityPoints[0].X - particle.X;
                    float gY = gravityPoints[0].Y - particle.Y;

                    // считаем квадрат расстояния между частицей и точкой r^2
                    float r2 = gX * gX + gY * gY;
                    float M = 100; // сила притяжения к точке, пусть 100 будет

                    // пересчитываем вектор скорости с учетом притяжения к точке
                    particle.SpeedX += (gX) * M / r2;
                    particle.SpeedY += (gY) * M / r2;

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
                if (particles.Count < 500) // пока частиц меньше 500 генерируем новые
                {
                    // а у тут уже наш новый класс используем
                    var particle = new ParticleColorful();
                    // ну и цвета меняем
                    particle.FromColor = Color.Yellow;
                    particle.ToColor = Color.FromArgb(0, Color.Magenta);
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
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

            foreach (var point in gravityPoints)
            {
                g.FillEllipse(
                    new SolidBrush(Color.Red),
                    point.X - 5,
                    point.Y - 5,
                    10,
                    10
                );
            }
        }
    }
}
