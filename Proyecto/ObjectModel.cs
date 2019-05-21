using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace Proyecto
{
    class ObjectModel
    {
        List<Vector3> vertices = new List<Vector3>();
        public List<Vector3> Vertices { get => vertices; set => vertices = value; }

        public void ProcessFile(String filecontents)
        {
            List<String> lines = new List<String> (filecontents.Split('\n'));
            Vector3 vector = new Vector3();

            foreach(String line in lines)
            {
                if(line.StartsWith("v "))
                {
                    String temp = line.Substring(2);
                    String[] vertparts = temp.Split(' ');
                    float.TryParse(vertparts[0], out vector.X);
                    float.TryParse(vertparts[1], out vector.Y);
                    float.TryParse(vertparts[2], out vector.Z);
                    Vertices.Add(vector);
                }
            }
        }
    }
}
