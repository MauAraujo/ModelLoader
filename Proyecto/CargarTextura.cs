using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

namespace Proyecto
{

    public class CargarTextura
    {
        public CargarTextura()
        {
        }

        public static Textura2D LoadTexture(string direccion)
        {
            if (!File.Exists(direccion))
            {
                throw new FileNotFoundException("Archivo no encontrado " + direccion + ".");
            }

            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bmp = new Bitmap(direccion);

            BitmapData datos = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                                   ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                datos.Width, datos.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, datos.Scan0);

            bmp.UnlockBits(datos);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMagFilter.Linear);

            return new Textura2D(id, bmp.Width, bmp.Height);
        }
    }
}
