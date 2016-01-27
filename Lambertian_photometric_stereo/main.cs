using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp;
using MathNet;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lambertian_photometric_stereo
{
    public partial class main : Form
    {
        public static IplImage[] 入力画像 = new IplImage[4];
        string[] ファイル名 = new string[4];
        public static IplImage 出力画像;
        public static Boolean is4Image = false;

        DenseMatrix camera_v, light0_v, light1_v, light2_v, light3_v;

        public main()
        {
            InitializeComponent();
            ベクトル計算();
        }
        void ベクトル計算()
        {
            var camera_num = double.Parse(textBox_camera.Text);
            var deg2rad = Math.PI / 180.0;
            camera_v = DenseMatrix.OfArray(new double[,] { { Math.Sin(deg2rad * camera_num), 0, Math.Cos(deg2rad * camera_num) } });

            light0_v = DenseMatrix.OfArray(new double[,] { { -Math.Cos(deg2rad*double.Parse(textBox_0b.Text)) * Math.Cos(deg2rad*double.Parse(textBox_0a.Text)),
                                                             -Math.Cos(deg2rad*double.Parse(textBox_0b.Text)) * Math.Sin(deg2rad*double.Parse(textBox_0a.Text)), 
                                                              Math.Sin(deg2rad*double.Parse(textBox_0b.Text)), } });
            light1_v = DenseMatrix.OfArray(new double[,] { { -Math.Cos(deg2rad*double.Parse(textBox_1b.Text)) * Math.Cos(deg2rad*double.Parse(textBox_1a.Text)),
                                                             -Math.Cos(deg2rad*double.Parse(textBox_1b.Text)) * Math.Sin(deg2rad*double.Parse(textBox_1a.Text)), 
                                                              Math.Sin(deg2rad*double.Parse(textBox_1b.Text)), } });
            light2_v = DenseMatrix.OfArray(new double[,] { { -Math.Cos(deg2rad*double.Parse(textBox_2b.Text)) * Math.Cos(deg2rad*double.Parse(textBox_2a.Text)),
                                                             -Math.Cos(deg2rad*double.Parse(textBox_2b.Text)) * Math.Sin(deg2rad*double.Parse(textBox_2a.Text)), 
                                                              Math.Sin(deg2rad*double.Parse(textBox_2b.Text)), } });
            light3_v = DenseMatrix.OfArray(new double[,] { { -Math.Cos(deg2rad*double.Parse(textBox_3b.Text)) * Math.Cos(deg2rad*double.Parse(textBox_3a.Text)),
                                                             -Math.Cos(deg2rad*double.Parse(textBox_3b.Text)) * Math.Sin(deg2rad*double.Parse(textBox_3a.Text)), 
                                                              Math.Sin(deg2rad*double.Parse(textBox_3b.Text)), } });

            Console.WriteLine(camera_v);
            Console.WriteLine(light0_v);
            Console.WriteLine(light1_v);
            Console.WriteLine(light2_v);
            Console.WriteLine(light3_v);
 
        }
        private void Click_開く(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (入力画像[i] != null) 入力画像[i].Dispose();
                入力画像[i] = Cv.CreateImage(new CvSize(640, 480), BitDepth.U8, 1);
            }
            if (出力画像 != null)
            {
                出力画像.Dispose();
                出力画像 = Cv.CreateImage(new CvSize(640, 480), BitDepth.U8, 1);
            }
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = true,  // 複数選択の可否
                Filter =  // フィルタ
                "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名をすべて表示する
                foreach (var file in dialog.FileNames.Select((value, index) => new { value, index }))
                {
                    入力画像[file.index] = new IplImage(file.value, LoadMode.GrayScale);
                    ファイル名[file.index]=dialog.SafeFileNames[file.index];
                }
                if (dialog.FileNames.Length == 4) is4Image = true;
                else is4Image = false;
                // ファイル名をタイトルバーに設定
                this.Text = dialog.FileNames[0];

                pictureBoxIpl1.ImageIpl = 入力画像[0];
            }
        }

        private void Click_radio0(object sender, EventArgs e)//ラジオボタンは選択された時にのみクリックイベントが発生
        {
            pictureBoxIpl1.RefreshIplImage(入力画像[0]);
            this.Text = ファイル名[0];
        }

        private void Click_radio1(object sender, EventArgs e)
        {
            pictureBoxIpl1.RefreshIplImage(入力画像[1]);
            this.Text = ファイル名[1];
        }

        private void Click_radio2(object sender, EventArgs e)
        {
            pictureBoxIpl1.RefreshIplImage(入力画像[2]);
            this.Text = ファイル名[2];
        }

        private void Click_radio3(object sender, EventArgs e)
        {
            pictureBoxIpl1.RefreshIplImage(入力画像[3]);
            this.Text = ファイル名[3];
        }
        
 
    }
}
