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


            //GL.Begin(PrimitiveType.Triangles);
            //foreach (Vector3 vertex in obj.Vertices)
            //{
            //    int index = obj.Vertices.IndexOf(vertex);
            //    GL.Vertex3(vertex);

            //    if (index < obj.Vertices.ToArray().Length - 2)
            //    {
            //        GL.Vertex3(obj.Vertices.ElementAt(index + 1));
            //        GL.Vertex3(obj.Vertices.ElementAt(index + 2));
            //    }
            //}
            //GL.End();
            GL.BindTexture(TextureTarget.Texture2D, tex.Id);

            GL.Begin(PrimitiveType.Triangles);
            foreach (int vertex in obj.TriFace)
            {
                GL.Vertex3(obj.Vertices.ElementAt(obj.TriFace.IndexOf(vertex)));
            }
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            foreach (int vertex in obj.QuadFace)
            {
                int index = obj.QuadFace.IndexOf(vertex);
                if (index < obj.Vertices.ToArray().Length)
                {
                    GL.Vertex3(obj.Vertices.ElementAt(obj.QuadFace.IndexOf(vertex)));
                }
            }
            GL.End();

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            GL.MatrixMode(MatrixMode.Modelview);

        }


    }
}
