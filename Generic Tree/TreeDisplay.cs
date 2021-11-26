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
    public partial class TreeDisplay : Form
    {
        private Random random = new Random();
        private Graphics graphics;
        Pen pen = new Pen(Color.Red);
        Brush brush = new SolidBrush(Color.Black);
        int drawRatio = 55;

        private Node<int> root;

        public TreeDisplay()
        {
            InitializeComponent();
            TreeDrawEnvironment.Image = new Bitmap(TreeDrawEnvironment.Width, TreeDrawEnvironment.Height);
            graphics = Graphics.FromImage(TreeDrawEnvironment.Image);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            root = new Node<int>(random.Next(10));
            CreateIntegerTree(root);
            DrawTree(this.Width / 2 - 25, 10, 50, root);
            Console.WriteLine();
        }

        private void CreateIntegerTree(Node<int> root)
        {
            int iterations = random.Next(10);
            for (int i = 0; i < iterations; i++)
            {
                root.AddChild(new Node<int>(random.Next(10)));
            }
            if (iterations == 0)
                return;
            CreateIntegerTree(root.Children[random.Next(root.Children.Count)]);
        }

        private void DrawTree(int x, int y, int ellipseSize, Node<int> root)
        {
            graphics.DrawRectangle(pen, x, y, ellipseSize, ellipseSize);
            graphics.DrawString(root.Data.ToString(), this.Font, brush, x + ellipseSize / 2 - root.Data.ToString().Length - 3, y + ellipseSize / 2 - 5);
            for (int i = 0; i < root.Children.Count; i++)
            {
                graphics.DrawLine(pen, x + ellipseSize / 2, y + ellipseSize, x - root.Children.Count * drawRatio + i * drawRatio * 2 + ellipseSize / 2, y + 100);
                DrawTree(x - root.Children.Count * drawRatio + i * drawRatio * 2, y + 100, ellipseSize, root.Children[i]);
            }
        }

        private void TreeDisplay_SizeChanged(object sender, EventArgs e)
        {
            TreeDrawEnvironment.Size = this.Size;
            TreeDrawEnvironment.Image = new Bitmap(TreeDrawEnvironment.Width, TreeDrawEnvironment.Height);
            graphics = Graphics.FromImage(TreeDrawEnvironment.Image);
            DrawTree(this.Width / 2 - 25, 10, 50, root);
        }
    }
}
