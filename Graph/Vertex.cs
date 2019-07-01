using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class Vertex : IComparable<Vertex>
    {
        public int id { get; set; }
        public int source_id { get; set; }
        public int min_cost { get; set; }

        public bool permanent { get; set; }

        public int x { get; set; }
        public int y { get; set; }

        public int CompareTo(Vertex other)
        {
            return id.CompareTo(other.id);
        }

        public Vertex(int id)
        {

            this.id = id;
            min_cost = int.MaxValue;
            permanent = false;
        }

        //Size of vertex - 30, radius - 15

        /// <summary>
        /// Center of vertex
        /// </summary>
        public Point Center { get { return new Point(x * 30 + 15, y * 30 + 15); } }

        /// <summary>
        /// Location of vertex
        /// </summary>
        public Point Location { get { return new Point(x * 30, y * 30); } }


    }
}
