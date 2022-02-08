using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MixCharts
{
    public partial class Form1 : Form
    {
        private List<IceCreamStat> icecreamStats = new List<IceCreamStat>();
        private object[,] contingencyTable = null;
        Panel[] panels = new Panel[3]; 

        public Form1()
        {
            InitializeComponent();

            Panel p1 = new Panel();
            p1.Name = "P2";
            p1.BackColor = Color.LightSteelBlue;
            p1.BorderStyle = BorderStyle.FixedSingle;
            p1.Width = pictureBox1.Width / 2;
            p1.Dock = DockStyle.Left;
            pictureBox1.Controls.Add(p1);
            panels[1] = p1;

            Panel p3 = new Panel();
            p3.Name = "P3";
            p3.BackColor = Color.LightSteelBlue;
            p3.BorderStyle = BorderStyle.FixedSingle;
            p3.Width = pictureBox1.Width / 2;
            p3.Dock = DockStyle.Right;
            pictureBox1.Controls.Add(p3);
            panels[2] = p3;

            Panel p0 = new Panel();
            p0.Name = "P1";
            p0.BackColor = Color.LightCyan;
            p0.BorderStyle = BorderStyle.FixedSingle;
            p0.Height = 250;
            p0.Dock = DockStyle.Top;
            pictureBox1.Controls.Add(p0);
            panels[0] = p0;
        }

        // Eventi
        // --------------------------------------------------------------
        private void btnLoadCSV2_Click(object sender, EventArgs e)
        {
            LoadCSVGelati();
            ShowTable2();
            FillYearCombo();
        }

        private void btnContingencyTable_Click(object sender, EventArgs e)
        {
            contingencyTable = CreateContingencyTable();
            if (contingencyTable != null)
            {
                int i = 0;
                Graphics g = panels[i].CreateGraphics();
                DrawContingencyTable(g, i);
            }
        }

        private void btnBarChart_Click(object sender, EventArgs e)
        {
            int i = 2;
            Graphics g = panels[i].CreateGraphics();
            DrawBarChart(g, i);
        }

        private void btnScatterChart_Click(object sender, EventArgs e)
        {
            int i = 1;
            Graphics g = panels[i].CreateGraphics();
            DrawScatterChart(g, i);
        }


        // Metodi
        // --------------------------------------------------------------
        private void LoadCSVGelati()
        {
            string[] data;
            icecreamStats = new List<IceCreamStat>();

            var lines = File.ReadAllLines(@"Dati\IceCreams.csv").Skip(1);
            foreach (var line in lines)
            {
                try
                {
                    CultureInfo culture = new CultureInfo("us-US");
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        data = line.Split(',');

                        // Aggiunge un elemento della classe alla collezione
                        icecreamStats.Add(new IceCreamStat()
                        {
                            Data = DateTime.Parse(data[0].Trim(), culture),
                            Temperatura = double.Parse(data[1].Trim(), culture),
                            Quantita = double.Parse(data[2].Trim(), culture),
                            Anno = DateTime.Parse(data[0].Trim(), culture).Year,
                            Mese = DateTime.Parse(data[0].Trim(), culture).Month,
                            Periodo = DateTime.Parse(data[0].Trim(), culture).ToString("yyyy-MM")
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore.\n\nError message: {ex.Message}\n\n" + $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void FillYearCombo()
        {
            if (icecreamStats.Count == 0)
                return;

            var anni = icecreamStats.GroupBy(x => x.Anno).Select(x => x.FirstOrDefault()).OrderBy(x => x.Anno).Select(x => x.Anno).ToList();

            cmbAnno.Items.Clear();
            foreach (var anno in anni)
                cmbAnno.Items.Add(anno.ToString());

            cmbAnno.SelectedIndex = 0;
        }

        private void ShowTable2()
        {
            if (icecreamStats.Count == 0)
                return;

            dataGridView2.DataSource = icecreamStats;
        }

        private object[,] CreateContingencyTable()
        {
            object[,] matrix = null;

            if (icecreamStats.Count == 0)
                return matrix;

            var data = icecreamStats;   //.Where(x => x.Anno == int.Parse(cmbAnno.SelectedItem.ToString())).ToList();

            var anni = data.GroupBy(x => x.Anno).Select(x => x.FirstOrDefault()).OrderBy(x => x.Anno).Select(x => x.Anno).ToArray();
            var mesi = data.GroupBy(x => x.Mese).Select(x => x.FirstOrDefault()).OrderBy(x => x.Mese).Select(x => x.Mese).ToArray();

            var ct = (from f in icecreamStats
                      group f by new { f.Anno, f.Mese } into grp
                      where grp.Count() > 0
                      select new
                      {
                          Anno = grp.Key.Anno,
                          Mese = grp.Key.Mese,
                          Quantita = grp.Sum(x => x.Quantita)
                      }).ToList();

            matrix = new object[mesi.Count() + 1, anni.Count() + 1];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = "0";
                }
            }
            matrix[0, 0] = "mese/Anno";

            foreach (var anno in anni)
            {
                var pos = Array.IndexOf(anni, anno);
                matrix[0, pos + 1] = anno;
            }

            int i = 1;
            int j = 0;
            int posX;
            int posY;

            foreach (var anno in anni)
            {
                posY = Array.IndexOf(anni, anno);
                matrix[i, posY + 1] = 0;
            }

            foreach (var item in ct)
            {
                posX = Array.IndexOf(mesi, item.Mese);
                posY = Array.IndexOf(anni, item.Anno);
                matrix[posX + 1, 0] = item.Mese;
                matrix[posX + 1, posY + 1] = double.Parse(matrix[posX + 1, posY + 1].ToString()) + item.Quantita;
                i++;
            }

            return matrix;
        }

        private void DrawContingencyTable(Graphics G, int iPanel)
        {
            if (contingencyTable == null || G == null)
                return;

            var panel = panels[iPanel];

            G.Clear(panel.BackColor);

            int X = 0;
            int Y = 20;
            int distanceX = 80;
            int distanceY = 15;

            for (int i = 0; i < contingencyTable.GetLength(0); i++)
            {
                for (int j = 0; j < contingencyTable.GetLength(1); j++)
                {
                    Point p = new Point(X, Y);
                    G.DrawString(contingencyTable[i, j].ToString().PadLeft(8), new Font("Courier New", 10, FontStyle.Regular), new SolidBrush(Color.Black), p);

                    X += distanceX;
                }

                X = 0;
                Y += distanceY;
            }
        }

        private void DrawBarChart(Graphics G, int iPanel)
        {
            if (icecreamStats.Count == 0 || G == null)
                return;

            var data = (from f in icecreamStats
                        group f by new { f.Mese } into grp
                        where grp.Count() > 0
                        select new
                        {
                            Mese = grp.Key.Mese,
                            Valore = grp.Sum(x => Math.Truncate(x.Quantita) / 1000)
                        }).ToList();

            var panel = panels[iPanel];

            G.Clear(panel.BackColor);
            SolidBrush color = new SolidBrush(Color.FromArgb(200, 0, 0));

            var nbItems = icecreamStats.GroupBy(x => x.Anno).Select(x => x.FirstOrDefault()).ToList().Count();

            var maxh = (int)data.Max(x => x.Valore);
            int w = (panel.Width / data.Count);
            int i = 0;
            foreach (var item in data)
            {
                var mean = Math.Truncate(item.Valore / nbItems);
                int x = w * i + 5;      
                int h = Convert.ToInt32(item.Valore);
                int y = maxh - h + panel.Height - panel.Top;
                
                G.FillRectangle(color, x, y, w, h);
                G.DrawRectangle(Pens.Black, x, y, w, h);
                G.DrawLine(Pens.Black, new Point(x, y + h - (int)mean), new Point(x + w, y + h - (int)mean));
                i++;
                G.DrawString(item.Mese.ToString(), new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), new Point(x + 15 , y + h));
                G.DrawString(Math.Round(item.Valore, 0).ToString() + "K", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), new Point(x, y));
                G.DrawString(mean.ToString()+"K", new Font("Courier New", 10, FontStyle.Regular), new SolidBrush(Color.Black), new Point(x, y + h - (int)mean - 15));
            }
        }

        private void DrawScatterChart(Graphics G, int iPanel)
        {
            if (icecreamStats.Count == 0 || G == null)
                return;

            var data = icecreamStats.Where(x => x.Anno == int.Parse(cmbAnno.SelectedItem.ToString())).ToList();

            var quantita = data.OrderByDescending(x => x.Quantita).ToList();
            var temperature = data.OrderBy(x => x.Temperatura).ToList();

            var panel = panels[iPanel];

            G.Clear(panel.BackColor);
            SolidBrush backcolor = new SolidBrush(Color.White);
            SolidBrush plotcolor = new SolidBrush(Color.Firebrick);
            Pen pen = new Pen(Color.Black);
            Pen pen2 = new Pen(Color.LightGray);

            int offsetX = 60;
            int offsetY = 25;
            int stepY = 25;
            int stepX = 35;

            int X = panel.Left + offsetX;
            int Y = offsetY;
            int W = temperature.Count * stepX;
            int H = quantita.Count * stepY;
            int markerWidth = 3;
            int plotSize = 8;

            G.FillRectangle(backcolor, new Rectangle(X, Y, W, H));
            G.DrawRectangle(pen, new Rectangle(X, Y, W, H));

            Point p;
            // Markers Y
            for (int i = 1; i < quantita.Count; i += 1)
            {
                G.DrawLine(pen, new Point(X - markerWidth, Y + i * stepY), new Point(X + markerWidth, Y + i * stepY));
                G.DrawLine(pen2, new Point(X + markerWidth, Y + i * stepY), new Point(X + W, Y + i * stepY));
                p = new Point(X - markerWidth - offsetX + 10, Y + i * stepY - markerWidth * 2);
                G.DrawString(quantita[i].Quantita.ToString(), new Font("Courier New", 8, FontStyle.Regular), new SolidBrush(Color.Black), p);
            }
            // Markers X
            for (int i = 1; i < temperature.Count; i += 1)
            {
                G.DrawLine(pen, new Point(X + i * stepX, Y + H - markerWidth), new Point(X + i * stepX, Y + H + markerWidth));
                G.DrawLine(pen2, new Point(X + i * stepX, Y + markerWidth), new Point(X + i * stepX, Y + H));
                p = new Point(X + i * stepX - offsetX + 50, Y + H + markerWidth * 2);
                G.DrawString(temperature[i].Temperatura.ToString(), new Font("Courier New", 8, FontStyle.Regular), new SolidBrush(Color.Black), p);
            }

            // plot Valori
            foreach (var item in data)
            {
                var q = Array.IndexOf(quantita.ToArray(), quantita.Where(x => x.Quantita == item.Quantita).FirstOrDefault());
                var t = Array.IndexOf(temperature.ToArray(), temperature.Where(x => x.Temperatura == item.Temperatura).FirstOrDefault());
                p = new Point(X + t * stepX, Y + q * stepY);
                G.FillEllipse(plotcolor, p.X, p.Y, plotSize, plotSize);
            }
        }
    }
}
