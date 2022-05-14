using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casa6.model;
using Casa6.objetos;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Casa6
{
    class Game : GameWindow
    {

        Escenario escenario;

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.Black);


            escenario = new Escenario();
            
            Casa casa = new Casa(5, 5, 5, 0, 0, 0);
            Casa casa1 = new Casa(5, 5, 5, 10, 0, 0);

            casa.serializar("Casa.txt");
            casa1.serializar("Casa1.txt");
            

            Casa c1 = Objeto.desserializar<Casa>("Casa.txt");
            c1.init();
            Casa c2 = Objeto.desserializar<Casa>("Casa1.txt");
            c2.init();

            escenario.addObjeto("casa", c1);
            escenario.addObjeto("casa1", c2);

            base.OnLoad(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(VertexBufferObject);
            base.OnUnload(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.LoadIdentity();

            float gg = 0.8f * 3.1416f / 180.0f;

            //escenario.rotar(gg, 0, 0);
            escenario.getObjeto("casa").trasladar(0.1f, 0, 0);
            escenario.getObjeto("casa").rotar(0, 0, gg);
            
            //escenario.getObjeto("casa1").rotar(0, gg, 0);



            escenario.dibujar(Matrix4.Identity);



            Context.SwapBuffers();
            base.OnRenderFrame(e);

        }


        protected override void OnResize(EventArgs e)
        {
            float d = 30;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-d, d, -d, d, -d, d);
            //GL.Frustum(-80, 80, -80, 80, 4, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            base.OnResize(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == 'l' || e.KeyChar == 'L')
            {
                Console.WriteLine("");
            }
        }

    }
}
