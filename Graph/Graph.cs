using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp1
{
    internal class Graph : IEnumerable
    {
        public int[,] Matrix = new int[30, 30];

        /// <summary>
        /// Set matrix to zeros
        /// </summary>
        public void MatrixZeros()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = 0;
                }
            }
        }

        public List<Vertex> Vertices = new List<Vertex>();

        public IEnumerator GetEnumerator()
        {
            return Vertices.GetEnumerator();
        }

        /// <summary>
        /// Add new vertex
        /// </summary>
        /// <param name="v"></param>
        public void Add(Vertex v)
        {
            if (v.id < 30)
            {
                Vertices.Add(v);
            }

        }

        /// <summary>
        /// Return vertex with coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Vertex Get(int x, int y)
        {
            return (from v in Vertices where v.x == x && v.y == y select v).FirstOrDefault();
        }

        /// <summary>
        /// Return vertex with ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Vertex GetID(int id)
        {
            return (from v in this.OfType<Vertex>() where v.id == id select v).FirstOrDefault();
        }

        /// <summary>
        /// Delete vertex
        /// </summary>
        /// <param name="v"></param>
        public void Remove(Vertex v)
        {
            Vertices.Remove(v);
            Vertices.Sort();
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i].id = i;
            }

            if (v != null)
            {
                MatrixRefactor(v.id);
            }
        }

        /// <summary>
        /// Connect two vertices
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void Connect(Vertex v1, Vertex v2)
        {
            if (Matrix[v1.id, v2.id] < 1000)
            {
                Matrix[v1.id, v2.id] += 1;
                Matrix[v2.id, v1.id] += 1;
            }
        }

        /// <summary>
        /// Delete edge or decrease weight by 1
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void Disconnect(Vertex v1, Vertex v2)
        {
            if (Matrix[v1.id, v2.id] > 1)
            {
                Matrix[v1.id, v2.id]--;
                Matrix[v2.id, v1.id]--;
            }
            else if (Matrix[v1.id, v2.id] == 1)
            {
                Matrix[v1.id, v2.id] = 0;
                Matrix[v2.id, v1.id] = 0;
            }
        }

        /// <summary>
        /// Refactoring the matrix after deleting
        /// </summary>
        /// <param name="v"></param>
        public void MatrixRefactor(int v)
        {
            for (int i = v; i < Matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = Matrix[i + 1, j];
                    Matrix[j, i] = Matrix[j, i + 1];
                }

            }
        }

        /// <summary>
        /// Dijkstra algorithm
        /// </summary>
        /// <param name="id"></param>
        public void Dijkstra(int id)
        {
            Vertex start = GetID(id);

            start.min_cost = 0;
            start.permanent = true;
            start.source_id = start.id;

            for (int i = 0; i < Vertices.Count; i++)
            {
                int cost = int.MaxValue;
                int index = 0;

                foreach (Vertex v in Vertices)
                {
                    if (v.permanent == false)
                    {
                        if (Matrix[start.id, v.id] != 0)
                        {
                            if (start.min_cost + Matrix[start.id, v.id] < v.min_cost)
                            {
                                v.min_cost = start.min_cost + Matrix[start.id, v.id];
                                v.source_id = start.id;
                            }
                        }

                        if (v.min_cost < cost)
                        {
                            cost = v.min_cost;
                            index = v.id;
                        }
                    }

                }

                GetID(index).permanent = true;
                start = GetID(index);
            }

        }

    }
}
