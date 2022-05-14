using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casa6.model;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Casa6.objetos
{
    class Casa : Objeto
    {

        public float ancho { get; set; }
        public float alto { get; set; }
        public float largo { get; set; }

        public Casa()
        {

        }

        public Casa(float ancho, float alto, float largo, float x, float y, float z) : base()
        {
            cm = new Punto(x, y, z);
            this.ancho = ancho;
            this.alto = alto;
            this.largo = largo;
            init();
        }

        public void init()
        {
            vaciar();

            Parte pared1 = new Parte();
            pared1.color = Color.Salmon;
            pared1.cm = new Punto(cm.x, cm.y, cm.z);
            pared1.addPunto(new Punto(cm.x, cm.y, cm.z));
            pared1.addPunto(new Punto(cm.x + ancho, cm.y, cm.z));
            pared1.addPunto(new Punto(cm.x + ancho, cm.y + alto * 0.8f, cm.z));
            pared1.addPunto(new Punto(cm.x + ancho / 2.0f, cm.y + alto, cm.z));
            pared1.addPunto(new Punto(cm.x, cm.y + alto * 0.8f, cm.z));

            Parte pared2 = new Parte();
            pared2.color = Color.AliceBlue;
            pared2.cm = new Punto(cm.x + ancho, cm.y, cm.z);
            pared2.addPunto(new Punto(cm.x + ancho, cm.y, cm.z));
            pared2.addPunto(new Punto(cm.x + ancho, cm.y, cm.z + largo));
            pared2.addPunto(new Punto(cm.x + ancho, cm.y + alto * 0.8f, cm.z + largo));
            pared2.addPunto(new Punto(cm.x + ancho, cm.y + alto * 0.8f, cm.z));

            Parte pared3 = new Parte();
            pared3.color = Color.Pink;
            pared3.cm = new Punto(cm.x, cm.y, cm.z + largo);
            pared3.addPunto(new Punto(cm.x, cm.y, cm.z + largo));
            pared3.addPunto(new Punto(cm.x + ancho, cm.y, cm.z + largo));
            pared3.addPunto(new Punto(cm.x + ancho, cm.y + alto * 0.8f, cm.z + largo));
            pared3.addPunto(new Punto(cm.x + ancho / 2.0f, cm.y + alto, cm.z + largo));
            pared3.addPunto(new Punto(cm.x, cm.y + alto * 0.8f, cm.z + largo));

            Parte pared4 = new Parte();
            pared4.color = Color.LawnGreen;
            pared4.cm = new Punto(cm.x, cm.y, cm.z);
            pared4.addPunto(new Punto(cm.x, cm.y, cm.z));
            pared4.addPunto(new Punto(cm.x, cm.y, cm.z + largo));
            pared4.addPunto(new Punto(cm.x, cm.y + alto * 0.8f, cm.z + largo));
            pared4.addPunto(new Punto(cm.x, cm.y + alto * 0.8f, cm.z));

            Parte techo1 = new Parte();
            techo1.color = Color.Gray;
            techo1.cm = new Punto(cm.x, cm.y + alto * 0.8f, cm.z);
            techo1.addPunto(new Punto(cm.x, cm.y + alto * 0.8f, cm.z));
            techo1.addPunto(new Punto(cm.x + ancho / 2.0f, cm.y + alto, cm.z));
            techo1.addPunto(new Punto(cm.x + ancho / 2.0f, cm.y + alto, cm.z + largo));
            techo1.addPunto(new Punto(cm.x, cm.y + alto * 0.8f, cm.z + largo));

            Parte techo2 = new Parte();
            techo2.color = Color.Gray;
            techo2.cm = new Punto(cm.x + ancho, cm.y + alto * 0.8f, cm.z);
            techo2.addPunto(new Punto(cm.x + ancho, cm.y + alto * 0.8f, cm.z));
            techo2.addPunto(new Punto(cm.x + ancho / 2.0f, cm.y + alto, cm.z));
            techo2.addPunto(new Punto(cm.x + ancho / 2.0f, cm.y + alto, cm.z + largo));
            techo2.addPunto(new Punto(cm.x + ancho, cm.y + alto * 0.8f, cm.z + largo));


            Parte puerta = new Parte();
            puerta.color = Color.Brown;
            puerta.cm = new Punto(cm.x + ancho / 2.0f, cm.y, cm.z + largo);
            puerta.addPunto(new Punto(cm.x + ancho / 2.0f, cm.y, cm.z + largo + 0.01f));
            puerta.addPunto(new Punto(cm.x + ancho / 2.0f + ancho * 0.2f, cm.y, cm.z + largo + 0.01f));
            puerta.addPunto(new Punto(cm.x + ancho / 2.0f + ancho * 0.2f, cm.y + alto * 0.4f, cm.z + largo + 0.01f));
            puerta.addPunto(new Punto(cm.x + ancho / 2.0f, cm.y + alto * 0.4f, cm.z + largo + 0.01f));

            Parte ventana = new Parte();
            ventana.color = Color.Brown;
            ventana.cm = new Punto(cm.x, cm.y + alto * 0.2f, cm.z + largo / 2.0f - largo * 0.1f);
            ventana.addPunto(new Punto(cm.x - 0.01f, cm.y + alto * 0.2f, cm.z + largo / 2.0f - largo * 0.1f));
            ventana.addPunto(new Punto(cm.x - 0.01f, cm.y + alto * 0.2f, cm.z + largo / 2.0f + largo * 0.1f));
            ventana.addPunto(new Punto(cm.x - 0.01f, cm.y + alto * 0.4f, cm.z + largo / 2.0f + largo * 0.1f));
            ventana.addPunto(new Punto(cm.x - 0.01f, cm.y + alto * 0.4f, cm.z + largo / 2.0f - largo * 0.1f));


            addParte("Pared1", pared1);
            addParte("Pared2", pared2);
            addParte("Pared3", pared3);
            addParte("Pared4", pared4);
            addParte("Techo1", techo1);
            addParte("Techo2", techo2);
            addParte("Puerta", puerta);
            addParte("Ventana", ventana);
        }

    }
}
