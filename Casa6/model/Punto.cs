using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Casa6.model
{
    class Punto
    {
        private float ejeX { get; set; }
        private float ejeY { get; set; }
        private float ejeZ { get; set; }

        public float x { get { return ejeX; } set { ejeX = value; } }
        public float y { get { return ejeY; } set { ejeY = value; } }
        public float z { get { return ejeZ; } set { ejeZ = value; } }


        public Punto(float x, float y, float z)
        {
            this.ejeX = x;
            this.ejeY = y;
            this.ejeZ = z;
        }

        public Punto() : this(0, 0, 0) { }

        public Punto(Punto p)
        {
            this.ejeX = p.ejeX;
            this.ejeY = p.ejeY;
            this.ejeZ = p.ejeZ;
        }


        public Punto(float valor)
        {
            this.ejeX = this.ejeY = this.ejeZ = valor;
        }

        public Vector3 ToVector3()
        {
            return new Vector3(this.ejeX, this.ejeY, this.ejeZ);
        }

        public void acumular(Punto p)
        {
            this.ejeX += p.x;
            this.ejeY += p.y;
            this.ejeZ += p.z;
        }
        public void acumular(float x, float y, float z)
        {
            this.ejeX += x;
            this.ejeY += y;
            this.ejeZ += z;
        }
        public void multiplicar(float x, float y, float z)
        {
            this.ejeX *= x;
            this.ejeY *= y;
            this.ejeZ *= z;
        }
        public void setPunto(float valor)
        {
            this.ejeX = this.ejeY = this.ejeZ = valor;
        }

        public void sumar(Punto a)
        {
            this.ejeX += a.x;
            this.ejeY += a.y;
            this.ejeZ += a.z;
        }

        public Punto copiar()
        {
            return new Punto(x, y, z);
        }

        public bool compareTo(Punto a)
        {
            return (this.ejeX == a.ejeX && this.ejeY == a.ejeY && this.ejeZ == a.ejeZ);
        }

        public override string ToString() => $"({ejeX}|{ejeY}|{ejeZ})";

    }
}

