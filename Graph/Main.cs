using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly Graph graph = new Graph();

        /// <summary>
        /// Check if cursor is on matrix
        /// </summary>
        private bool onHoverMatrix = false;

        /// <summary>
        /// Location of cursor
        /// </summary>
        private int mouseX, mouseY;

        /// <summary>
        /// Check if LMB is pressed
        /// </summary>
        private bool onHold = false;

        /// <summary>
        /// Starting vertex
        /// </summary>
        private Point source = new Point();

        /// <summary>
        /// Destination/ending vertex
        /// </summary>
        private Point destination = new Point();

        public Form1()
        {
            InitializeComponent();
            panel2.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxGraph.BorderStyle = BorderStyle.FixedSingle;
            graph.MatrixZeros();
            Results.Font = new Font("Inconsolata", 10f);
            pictureBoxGraph.MouseDown += (s, e) =>
            {
                mouseX = e.X / 30;
                mouseY = e.Y / 30;

                if (e.Button == MouseButtons.Left)
                {
                    if (graph.Get(mouseX, mouseY) == null)
                    {
                        graph.Add(new Vertex(graph.Vertices.Count)
                        {
                            x = mouseX,
                            y = mouseY
                        });
                    }
                    else
                    {
                        source = graph.Get(mouseX, mouseY).Center;
                        destination = graph.Get(mouseX, mouseY).Center;
                        onHold = true;
                    }
                }

                else if (e.Button == MouseButtons.Right)
                {
                    graph.Remove(graph.Get(mouseX, mouseY));
                }

                pictureBoxGraph.Invalidate();
                pictureBoxMatrix.Invalidate();
            };

            pictureBoxGraph.MouseMove += (s, e) =>
            {
                int x = e.X / 30;
                int y = e.Y / 30;
                onHoverMatrix = false;
                if (e.Button == MouseButtons.Left)
                {
                    if (onHold == true)
                    {
                        destination.X = e.X;
                        destination.Y = e.Y;
                        pictureBoxGraph.Invalidate();
                    }
                }
            };

            tabPage1.MouseMove += (s, e) =>
            {
                onHoverMatrix = false;
            };

            pictureBoxGraph.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Vertex v1 = graph.Get(source.X / 30, source.Y / 30);
                    Vertex v2 = graph.Get(destination.X / 30, destination.Y / 30);
                    if (v2 != null && v1 != null && onHold == true && v1 != v2)
                    {
                        graph.Connect(v1, v2);
                    }
                }
                onHold = false;

                pictureBoxGraph.Invalidate();
                pictureBoxMatrix.Invalidate();
            };

            pictureBoxMatrix.MouseDown += (s, e) =>
            {
                mouseX = (e.X / 30) - 1;
                mouseY = (e.Y / 30) - 1;
                if (mouseX != mouseY && mouseX < graph.Vertices.Count && mouseY < graph.Vertices.Count && mouseX >= 0 && mouseY >= 0)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (ModifierKeys.HasFlag(Keys.Control))
                        {
                            for (int i = 1; i < 10; i++)
                            {
                                graph.Connect(graph.Vertices[mouseX], graph.Vertices[mouseY]);
                            }
                        }
                        graph.Connect(graph.Vertices[mouseX], graph.Vertices[mouseY]);
                    }
                    if (e.Button == MouseButtons.Right)
                    {
                        if (ModifierKeys.HasFlag(Keys.Control))
                        {
                            for (int i = 1; i < 10; i++)
                            {
                                graph.Disconnect(graph.Vertices[mouseX], graph.Vertices[mouseY]);
                            }
                        }
                        graph.Disconnect(graph.Vertices[mouseX], graph.Vertices[mouseY]);
                    }
                }
                pictureBoxMatrix.Invalidate();
                pictureBoxGraph.Invalidate();

            };

            pictureBoxMatrix.MouseMove += (s, e) =>
            {
                int x = (e.X / 30) - 1;
                int y = (e.Y / 30) - 1;

                if (x != y && graph.GetID(x) != null && graph.GetID(y) != null)
                {
                    source = graph.GetID(x).Location;
                    destination = graph.GetID(y).Location;
                    onHoverMatrix = true;
                }
                else
                {
                    onHoverMatrix = false;
                }

                pictureBoxGraph.Invalidate();
            };


            //Drawing a graph
            pictureBoxGraph.Paint += (s, e) =>
            {
                //Drawing a grid
                if (Grid.CheckState == CheckState.Checked)
                {
                    //Vertical
                    for (int i = 30; i < pictureBoxGraph.Width; i += 30)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(i, 0), new Point(i, pictureBoxGraph.Height));
                    }
                    //Horizontal
                    for (int i = 30; i < pictureBoxGraph.Height; i += 30)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(0, i), new Point(pictureBoxGraph.Width, i));
                    }
                }

                //Smoothing
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                //Drawing edges
                for (int i = 1; i < graph.Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (graph.Matrix[i, j] != 0)
                        {
                            e.Graphics.DrawLine(new Pen(Color.Tan, 2), graph.Vertices[i].Center, graph.Vertices[j].Center);
                            e.Graphics.DrawString(string.Format("{0}", graph.Matrix[i, j]), Font, new SolidBrush(Color.Black), (graph.GetID(i).Center.X + graph.GetID(j).Center.X) * 0.5f, (graph.GetID(i).Center.Y + graph.GetID(j).Center.Y) * 0.5f);
                        }
                    }
                }

                //Drawing edges if LMB is held
                if (onHold == true)
                {
                    e.Graphics.DrawLine(new Pen(Color.Red, 2) { DashPattern = new[] { 2f, 2f } }, source, destination);
                }

                //Drawing vertices
                foreach (Vertex v in graph)
                {
                    e.Graphics.FillEllipse(new SolidBrush(Color.Linen), new Rectangle(v.Location, new Size(30, 30)));
                    e.Graphics.DrawEllipse(new Pen(Color.Black), new Rectangle(v.Location, new Size(30, 30)));

                    e.Graphics.DrawString(string.Format("{0,3}", v.id + 1), Font, new SolidBrush(Color.Black), v.Location.X + 4, v.Location.Y + 9);
                }

                //Drawing if cursor is on matrix
                if (onHoverMatrix)
                {
                    Vertex v1 = graph.Get(source.X / 30, source.Y / 30);
                    Vertex v2 = graph.Get(destination.X / 30, destination.Y / 30);

                    if (graph.Matrix[v1.id, v2.id] != 0)
                    {
                        //If edge exist then change color
                        e.Graphics.DrawLine(new Pen(Color.SkyBlue, 2), v1.Center, v2.Center);
                    }
                    else
                    {
                        //If edge does not exist then dashed line
                        e.Graphics.DrawLine(new Pen(Color.SkyBlue, 2) { DashPattern = new[] { 2f, 2f } }, v1.Center, v2.Center);
                    }

                    //First vertex
                    e.Graphics.FillEllipse(new SolidBrush(Color.SkyBlue), new Rectangle(v1.Location, new Size(30, 30)));
                    e.Graphics.DrawEllipse(new Pen(Color.Black), new Rectangle(v1.Location, new Size(30, 30)));
                    e.Graphics.DrawString(string.Format("{0,3}", v1.id + 1), Font, new SolidBrush(Color.Black), v1.Location.X + 4, v1.Location.Y + 9);

                    //Second vertex
                    e.Graphics.FillEllipse(new SolidBrush(Color.SkyBlue), new Rectangle(v2.Location, new Size(30, 30)));
                    e.Graphics.DrawEllipse(new Pen(Color.Black), new Rectangle(v2.Location, new Size(30, 30)));
                    e.Graphics.DrawString(string.Format("{0,3}", v2.id + 1), Font, new SolidBrush(Color.Black), v2.Location.X + 4, v2.Location.Y + 9);
                }

            };

            //Drawing a matrix
            pictureBoxMatrix.Paint += (s, e) =>
            {
                //Resize pictureBox after adding a vertex
                Size size = new Size((30 * graph.Vertices.Count) + 40, (30 * graph.Vertices.Count) + 40);
                pictureBoxMatrix.Size = size;

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                for (int i = 0; i < graph.Vertices.Count; i++)
                {
                    e.Graphics.DrawString(string.Format("{0}", i + 1), Font, new SolidBrush(Color.Black), new Point(i * 30 + 40, 10));
                    e.Graphics.DrawString(string.Format("{0}", i + 1), Font, new SolidBrush(Color.Black), new Point(10, i * 30 + 40));
                    for (int j = 0; j < graph.Vertices.Count; j++)
                    {
                        Point x = new Point(30 + (30 * i), 30 + (30 * j));
                        //Drawing cells in matrix
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(x, new Size(30, 30)));
                        if (i != j)
                        {
                            //Values from matrix
                            e.Graphics.DrawString(string.Format("{0}", graph.Matrix[i, j]), Font, new SolidBrush(Color.Black), new Point(x.X + 10, x.Y + 10));
                        }
                        if (i == j)
                        {
                            //Inserting '-' in a diagonal
                            e.Graphics.DrawString(string.Format("-"), Font, new SolidBrush(Color.Black), new Point(x.X + 10, x.Y + 10));
                        }
                    }
                }
            };
        }

        private void Grid_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxGraph.Invalidate();
        }

        //Clear
        private void Reset_Click(object sender, EventArgs e)
        {
            VertexID.Value = 1;
            Results.Text = null;
            graph.Vertices.Clear();
            graph.MatrixZeros();
            pictureBoxGraph.Invalidate();
            pictureBoxMatrix.Invalidate();
        }

        private void Dijkstra_Click(object sender, EventArgs e)
        {
            Results.Text = null;
            int index = Convert.ToInt32(VertexID.Value);

            if (graph.GetID(index - 1) != null)
            {
                graph.Dijkstra(index - 1);

                foreach (Vertex v in graph.Vertices)
                {
                    if (v.id != index - 1)
                    {
                        string path = "";
                        int id = v.id;
                        while (id != index - 1)
                        {
                            if (graph.GetID(id).source_id != id)
                            {
                                path += (graph.GetID(id).source_id + 1) + " ";
                                id = graph.GetID(id).source_id;
                            }
                            else
                            {
                                break;
                            }

                        }

                        if (Math.Abs(v.min_cost) == int.MaxValue)
                        {
                            Results.Text += "The shortest path between vertices " + index + " and " + (v.id + 1) + " is infinity \n";
                        }
                        else
                        {
                            Results.Text += "The shortest path between vertices " + index + " and " + (v.id + 1) + " is " + v.min_cost + "\n";
                            Results.Text += "The path is: " + (v.id + 1) + " " + path + "\n";
                        }
                    }
                }
            }

            foreach (Vertex v in graph.Vertices)
            {
                v.source_id = v.id;
                v.min_cost = int.MaxValue;
                v.permanent = false;
            }

        }

        //Random graph
        private void Random_Click(object sender, EventArgs e)
        {
            //Reset graph and matrix
            graph.Vertices.Clear();
            graph.MatrixZeros();
            Results.Text = null;

            //Draw a number of vertices and their location
            Random random = new Random();
            Random randomCoord = new Random();
            for (int i = 0; i < random.Next(8, 10); i++)
            {
                int x = randomCoord.Next(1, pictureBoxGraph.Width) / 30;
                int y = randomCoord.Next(1, pictureBoxGraph.Height) / 30;
                if (graph.Get(x, y) == null)
                {
                    graph.Vertices.Add(new Vertex(graph.Vertices.Count)
                    {
                        x = x,
                        y = y
                    });
                }
            }

            //Draw edges
            for (int i = 0; i < random.Next(30, 50); i++)
            {
                Vertex v1 = graph.GetID(random.Next(0, graph.Vertices.Count));
                Vertex v2 = graph.GetID(random.Next(0, graph.Vertices.Count));
                if (v1 != v2)
                {
                    graph.Connect(v1, v2);
                }

            }

            pictureBoxGraph.Invalidate();
            pictureBoxMatrix.Invalidate();
        }
    }
}