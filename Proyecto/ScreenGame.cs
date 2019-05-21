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
            GL.Ortho(-15, 15, -15, 15, 15, -15);
            obj = Loader.FromFile("AirDrone.obj");
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Rotate(10.5f, 10.5f, 10.5f, 10.5f);
            GL.Begin(PrimitiveType.Triangles);
            foreach (Vector3 vertex in obj.Vertices)
            {
                int index = obj.Vertices.IndexOf(vertex);
                GL.Vertex3(vertex);

                if(index < obj.Vertices.ToArray().Length - 2)
                {
                    GL.Vertex3(obj.Vertices.ElementAt(index + 1));
                    GL.Vertex3(obj.Vertices.ElementAt(index + 2));
                }
            }
            GL.End();

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
        }


    }
}
