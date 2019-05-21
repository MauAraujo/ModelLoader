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
        Textura2D tex;

        public ScreenGame(int ancho, int alto) : base(ancho, alto)
        { 
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.LoadIdentity();
            GL.MatrixMode(MatrixMode.Projection);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.Ortho(-35, 35, -35, 35, 35, -35);

            obj = Loader.FromFile("sword.obj");
            tex = CargarTextura.LoadTexture("metal.jpg");
            obj.TextureID = tex.Id;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Rotate(0.5f, 100, 100, 100);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color4.Cornsilk);
            GL.BindTexture(TextureTarget.Texture2D, tex.Id);
            
            foreach (List<int> vertex in obj.Faces)
            {
                if(vertex.Count == 3)
                {
                    GL.Begin(PrimitiveType.Triangles);
                    foreach (int index in vertex)
                    {
                        if(index < obj.Vertices.Count)
                        {
                            GL.Vertex3(obj.Vertices.ElementAt(index - 1));
                        }
                    }
                    GL.End();
                }
                if (vertex.Count == 4)
                {
                    GL.Begin(PrimitiveType.Quads);
                    foreach (int index in vertex)
                    {
                        GL.Vertex3(obj.Vertices.ElementAt(index - 1));
                    }
                    GL.End();
                }
            }
            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            GL.MatrixMode(MatrixMode.Modelview);

        }


    }
}
