using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Galereya
{
    public partial class Form1 : Form
    {
        private List<string> imagePaths = new List<string>();
        private List<string> imageTitles = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadImagesFromFile(openFileDialog.FileName);
            }

        }
        private void LoadImagesFromFile(string filePath)
        {
            listBox1.Items.Clear();
            imagePaths.Clear();
            imageTitles.Clear();

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    imagePaths.Add(parts[0]);
                    imageTitles.Add(parts[1]);
                    listBox1.Items.Add(parts[1]);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

                string saveFilePath = "selected_image.txt";
                AppendSelectedImageToFile(saveFilePath, listBox1.SelectedIndex);

                MessageBox.Show("Выбранное изображение добавлено в Galereya/bin/Debug/net8.0-windows/selected_images.txt", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AppendSelectedImageToFile(string filePath, int selectedIndex)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{imagePaths[selectedIndex]},{imageTitles[selectedIndex]}");
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.ImageLocation = imagePaths[listBox1.SelectedIndex];
                textBox1.Text = imageTitles[listBox1.SelectedIndex];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
