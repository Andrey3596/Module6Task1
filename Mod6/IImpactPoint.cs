using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod6
{
    public abstract class IImpactPoint
    {
        public float X; // ну точка же, вот и две координаты
        public float Y;

        // абстрактный метод с помощью которого будем изменять состояние частиц
        // например притягивать
        public abstract void ImpactParticle(Particle particle);

        // базовый класс для отрисовки точечки
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }
    //public class GravityPoint : IImpactPoint
    //{
    //    public int Power = 100; // сила притяжения

    //    // а сюда по сути скопировали с минимальными правками то что было в UpdateState
    //    public override void ImpactParticle(Particle particle)
    //    {
    //        float gX = X - particle.X;
    //        float gY = Y - particle.Y;
    //        double r = Math.Sqrt(gX * gX + gY * gY);

    //        if (r + particle.Radius < Power / 2) // если частица оказалось внутри окружности
    //        {
    //            // то притягиваем ее
    //            float r2 = (float)Math.Max(100, gX * gX + gY * gY);
    //            particle.SpeedX += gX * Power / r2;
    //            particle.SpeedY += gY * Power / r2;
    //        }
    //    }

    //    public override void Render(Graphics g)
    //    {
    //        // буду рисовать окружность с диаметром равным Power
    //        g.DrawEllipse(
    //               new Pen(Color.Red),
    //               X - Power / 2,
    //               Y - Power / 2,
    //               Power,
    //               Power
    //         );

    //        var stringFormat = new StringFormat(); // создаем экземпляр класса
    //        stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
    //        stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали
    //                                                             // обязательно выносим текст и шрифт в переменные
    //        var text = $"Я гравитон\nc силой {Power}";
    //        var font = new Font("Verdana", 10);

    //        // вызываем MeasureString, чтобы померить размеры текста
    //        var size = g.MeasureString(text, font);

    //        // рисуем подложнку под текст
    //        g.FillRectangle(
    //            new SolidBrush(Color.Red),
    //            X - size.Width / 2, // так как я выравнивал текст по центру то подложка должна быть центрирована относительно X,Y
    //            Y - size.Height / 2,
    //            size.Width,
    //            size.Height
    //        );

    //        // ну и текст рисую уже на базе переменных
    //        g.DrawString(
    //            text,
    //            font,
    //            new SolidBrush(Color.White),
    //            X,
    //            Y,
    //            stringFormat
    //        );
    //    }
    //}

    //public class AntiGravityPoint : IImpactPoint
    //{
    //    public int Power = 100; // сила отторжения

    //    // а сюда по сути скопировали с минимальными правками то что было в UpdateState
    //    public override void ImpactParticle(Particle particle)
    //    {
    //        float gX = X - particle.X;
    //        float gY = Y - particle.Y;
    //        float r2 = (float)Math.Max(100, gX * gX + gY * gY);

    //        particle.SpeedX -= gX * Power / r2; // тут минусики вместо плюсов
    //        particle.SpeedY -= gY * Power / r2; // и тут
    //    }
    //}

    public class RadarPoint : IImpactPoint
    {
        public int Radar = 100;
        public int count = 0;

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY);

            ParticleColorful colorful = particle as ParticleColorful;

            if (r + particle.Radius < Radar / 2 ) // если частица оказалось внутри окружности
            {
                // Помечаем, что частица внутри радара (для подсветки)
                if (!colorful.InRadar)
                {
                    colorful.InRadar = true;   // это поле добавим ниже
                    count++;

                }
            }

            if (!(r + particle.Radius < Radar / 2)) // если частица оказалось внутри окружности
            {
                // Помечаем, что частица внутри радара (для подсветки)
                if ((colorful.InRadar && !colorful.InDead) || (colorful.InRadar && colorful.InDead))
                {
                    colorful.InRadar = false;
                    colorful.InDead = false;
                    count--;
                }
                
            }
        }
        
        public override void Render(Graphics g)
        {
            // буду рисовать окружность с диаметром равным Power
            g.DrawEllipse(
                   new Pen(Color.Green),
                   X - Radar / 2,
                   Y - Radar / 2,
                   Radar,
                   Radar
             );

            var stringFormat = new StringFormat(); // создаем экземпляр класса
            stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
            stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали
                                                                 // обязательно выносим текст и шрифт в переменные
            var text = $"Я Засек\n {count}";
            var font = new Font("Verdana", 10);

            // вызываем MeasureString, чтобы померить размеры текста
            var size = g.MeasureString(text, font);


            // ну и текст рисую уже на базе переменных
            g.DrawString(
                text,
                font,
                new SolidBrush(Color.White),
                X,
                Y,
                stringFormat
            );
        }
    }

    public class ColorPoint : IImpactPoint
    {
        public int Radar = 100;
        public Color СolorP;
        private static Random rand = new Random();


        public ColorPoint()
        {
            // Генерируем насыщенный цвет (например, R, G, B от 100 до 255)
            СolorP = Color.FromArgb(
                rand.Next(100, 256),
                rand.Next(100, 256),
                rand.Next(100, 256)
            );
        }
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY);

            if (r + particle.Radius < Radar / 2) // если частица оказалось внутри окружности
            {
                // Помечаем, что частица внутри радара (для подсветки)
                if (particle is ParticleColorful colorful)
                {
                    colorful.InColorPoint = true;   
                    colorful.ColorPoint = this.СolorP;
                }
            }
            
        }

        public override void Render(Graphics g)
        {
            // буду рисовать окружность с диаметром равным Power
            g.DrawEllipse(
                   new Pen(СolorP),
                   X - Radar / 2,
                   Y - Radar / 2,
                   Radar,
                   Radar
             );
        }
    }



    public class DelitePoint : IImpactPoint
    {
        public int Radar = 50;
        public int CountDead = 0;

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY);

            if (r + particle.Radius < Radar) // если частица оказалось внутри окружности
            {
                
                particle.Life = 0;
                CountDead++;
            }
            
        }

        public override void Render(Graphics g)
        {
            
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - Radar/2,
                   Y - Radar/2,
                   Radar,
                   Radar
             );


            var stringFormat = new StringFormat(); 
            stringFormat.Alignment = StringAlignment.Center; 
            stringFormat.LineAlignment = StringAlignment.Center; 
                                                                 
            var text = $"Я убил\n {CountDead}";
            var font = new Font("Verdana", 10);
            var size = g.MeasureString(text, font);    
            

            g.DrawString(
                text,
                font,
                new SolidBrush(Color.White),
                X,
                Y,
                stringFormat
            );
        }
    }
}
