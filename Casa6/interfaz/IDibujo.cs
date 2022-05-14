using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casa6.interfaz
{
    public interface IDibujo
    {
        void dibujar(Matrix4 m);
        void rotar(float x, float y, float z);
        void ampliar(float x, float y, float z);
        void trasladar(float x, float y, float z);
        void dispose();
    }
}
