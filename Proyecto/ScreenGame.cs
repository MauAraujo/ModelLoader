using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Proyecto
{
    class ScreenGame : GameWindow
    {
        ObjectModel obj;

        public ScreenGame(int ancho, int alto) : base(ancho, alto)
        { 
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.LoadIdentity();
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(-10, 10, -10, 10, 10, -10);
            obj = Loader.FromFile("nave.obj");
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            GL.Begin(PrimitiveType.Triangles);
            foreach (Vector3 vertex in obj.Vertices)
            {
                GL.Vertex3(vertex);
            }
            GL.End();
            
            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
        }


    }
}
