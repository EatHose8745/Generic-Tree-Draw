using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generic_Tree
{
    public partial class TreeDisplay<T> : Form
    {
        private Random random = new Random();
        private Graphics graphics;
        Pen pen = new Pen(Color.Red);
        Brush brush = new SolidBrush(Color.Black);
        int drawRatio = 55;

        private char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();

        private Node<T> root;
        private DisplayNode<T> displayRoot;

        private List<DisplayNode<T>> displayNodes = new List<DisplayNode<T>>();

        public TreeDisplay()
        {
            InitializeComponent();
            TreeDrawEnvironment.Image = new Bitmap(TreeDrawEnvironment.Width, TreeDrawEnvironment.Height);
            graphics = Graphics.FromImage(TreeDrawEnvironment.Image);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            root = new Node<T>((T)Convert.ChangeType(random.Next(10), typeof(T)));
            displayRoot = new DisplayNode<T>(root, this.Width / 2 - 25, 10, 50);
            CreateIntegerTree(root);
            DrawTree(this.Width / 2 - 25, 10, 50, root, initalDraw: true);
            Console.WriteLine();
        }

        private void CreateIntegerTree(Node<T> root)
        {
            int iterations = random.Next(3);
            for (int i = 0; i < iterations; i++)
            {
                Node<T> temp = new Node<T>((T)Convert.ChangeType(random.Next(10), typeof(T)));
                root.AddChild(temp);
            }
            if (iterations == 0)
                return;
            CreateIntegerTree(root.Children[random.Next(root.Children.Count)]);
        }

        private void DrawTree(int x, int y, int ellipseSize, Node<T> root, bool initalDraw = false)
        {
            DisplayNode<T> displayNode;
            if (initalDraw)
            {
                displayNode = new DisplayNode<T>(root, x, y, ellipseSize);
                displayNodes.Add(displayNode);
            }
            else
            {
                displayNode = displayNodes.Find(n => n.Node == root);
                displayNode.X = x;
                displayNode.Y = y;
                displayNode.Size = ellipseSize;
            }
            graphics.DrawRectangle(pen, displayNode.X, displayNode.Y, displayNode.Size, displayNode.Size);
            graphics.DrawString(displayNode.Node.Data.ToString(), this.Font, brush, x + ellipseSize / 2 - displayNode.Node.Data.ToString().Length - 3, y + ellipseSize / 2 - 5);
            if (displayNode.DrawChildren == false)
            {
                return;
            }
            for (int i = 0; i < displayNode.Node.Children.Count; i++)
            {
                graphics.DrawLine(pen, x + ellipseSize / 2, y + ellipseSize, x - displayNode.Node.Children.Count * drawRatio + i * drawRatio * 2 + ellipseSize / 2, y + 100);
                DrawTree(x - displayNode.Node.Children.Count * drawRatio + i * drawRatio * 2, y + 100, ellipseSize, displayNode.Node.Children[i], initalDraw);
            }
        }

        private void TreeDisplay_SizeChanged(object sender, EventArgs e)
        {
            displayNodes.Clear();
            TreeDrawEnvironment.Size = this.Size;
            TreeDrawEnvironment.Image = new Bitmap(TreeDrawEnvironment.Width, TreeDrawEnvironment.Height);
            graphics = Graphics.FromImage(TreeDrawEnvironment.Image);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            DrawTree(this.Width / 2 - 25, 10, 50, root, true);
            GC.Collect();
        }

        private void TreeDisplay_Load(object sender, EventArgs e)
        {

        }

        private void TreeDrawEnvironment_DoubleClick(object sender, EventArgs e)
        {
            var cursorPos = TreeDrawEnvironment.PointToClient(Cursor.Position);
            DisplayNode<T> temp = displayNodes.Find(x => cursorPos.X >= x.X && cursorPos.X <= x.X + x.Size && cursorPos.Y >= x.Y && cursorPos.Y <= x.Y + x.Size);
            if (temp == null)
                return;
            int index = displayNodes.IndexOf(temp);
            temp.DrawChildren = temp.Node.HasChildren() ? !temp.DrawChildren : temp.DrawChildren;
            displayNodes[index] = temp;
            TreeDrawEnvironment.Image = new Bitmap(TreeDrawEnvironment.Width, TreeDrawEnvironment.Height);
            graphics = Graphics.FromImage(TreeDrawEnvironment.Image);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            DrawTree(this.Width / 2 - 25, 10, 50, root);
        }
    }
}
