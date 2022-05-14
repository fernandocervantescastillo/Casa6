using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casa6.interfaz;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Casa6.model
{
    class Parte : IDibujo
    {
        public Punto cm { get; set; }
        public Color color { get; set; }
        public string name { get; set; }

        public LinkedList<Punto> l;

        private Matrix4 m;

        public Parte()
        {
            l = new LinkedList<Punto>();
            color = Color.White;
            m = Matrix4.Identity;
        }

        public Parte(String name) : this()
        {
            this.name = name;
        }

        public Parte(Parte p)
        {
            this.name = p.name;
            this.color = p.color;
            this.cm = p.cm.copiar();
            this.l = new LinkedList<Punto>();

            Punto punto;
            for (int i = 0; i < p.nroPuntos(); i++)
            {
                punto = p.getPunto(i);
                addPunto(punto.copiar());
            }
        }

        public void addPunto(Punto punto)
        {
            l.AddLast(punto);
        }

        public Punto getPunto(int i)
        {
            return (Punto)l.ElementAt(i);
        }

        public void borrarPunto(int pos)
        {
            Punto p = getPunto(pos);
            l.Remove(p);
        }

        public void borrarPunto(Punto punto)
        {
            l.Remove(punto);
        }

        public int nroPuntos()
        {
            return l.Count;
        }

        public Parte copiar()
        {
            Parte p1 = new Parte(this);
            return p1;
        }

        public void dibujar(Matrix4 m)
        {
            Matrix4 u = m * this.m;

            GL.LoadMatrix(ref u);

            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(color);
            foreach (Punto punto in l)
            {
                GL.Vertex3(punto.ToVector3());
            }
            GL.End();
        }

        public void dispose()
        {
            l.Clear();
        }

        public void rotar(float x, float y, float z)
        {
            trasladar(-cm.x, -cm.y, -cm.z);
            m = Matrix4.CreateRotationX(x) * Matrix4.CreateRotationY(y) * Matrix4.CreateRotationZ(z) * m;
            trasladar(cm.x, cm.y, cm.z);
        }

        public void ampliar(float x, float y, float z)
        {
            m = Matrix4.CreateScale(x, y, z) * m;
        }

        public void trasladar(float x, float y, float z)
        {
            m = Matrix4.CreateTranslation(x, y, z) * m;
        }
    }
}


