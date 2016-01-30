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
        IplImage[] 入力画像 = new IplImage[4];
        string[] ファイル名 = new string[4];
        IplImage テンプレ画像;
        IplImage 出力画像;

        //double[] camera_v = new double[] {  Math.Sin(deg2rad * camera_num), 0, Math.Cos(deg2rad * camera_num)  };
        double[,] light_v;//光源の向いてる方向のベクトル
        double[] camera_light_v=new double[4];//カメラとライトのなす角度(rad)

        double[,][] 表面角度=new double[640,480][];
        int[,] 鏡面反射番号=new int[640,480];

        public main()
        {
            InitializeComponent();
            ベクトル格納();
        }
        void ベクトル格納()
        {
            var deg2rad = Math.PI / 180.0;

            light_v = new double[,] 
            {   
                {   -Math.Cos(deg2rad*double.Parse(textBox_0b.Text)) * Math.Cos(deg2rad*double.Parse(textBox_0a.Text)),
                    -Math.Cos(deg2rad*double.Parse(textBox_0b.Text)) * Math.Sin(deg2rad*double.Parse(textBox_0a.Text)), 
                     Math.Sin(deg2rad*double.Parse(textBox_0b.Text))
                },

                {   -Math.Cos(deg2rad*double.Parse(textBox_1b.Text)) * Math.Cos(deg2rad*double.Parse(textBox_1a.Text)),
                    -Math.Cos(deg2rad*double.Parse(textBox_1b.Text)) * Math.Sin(deg2rad*double.Parse(textBox_1a.Text)), 
                     Math.Sin(deg2rad*double.Parse(textBox_1b.Text))
                },

                {   -Math.Cos(deg2rad*double.Parse(textBox_2b.Text)) * Math.Cos(deg2rad*double.Parse(textBox_2a.Text)),
                    -Math.Cos(deg2rad*double.Parse(textBox_2b.Text)) * Math.Sin(deg2rad*double.Parse(textBox_2a.Text)), 
                     Math.Sin(deg2rad*double.Parse(textBox_2b.Text))
                },

                {   -Math.Cos(deg2rad*double.Parse(textBox_3b.Text)) * Math.Cos(deg2rad*double.Parse(textBox_3a.Text)),
                    -Math.Cos(deg2rad*double.Parse(textBox_3b.Text)) * Math.Sin(deg2rad*double.Parse(textBox_3a.Text)), 
                     Math.Sin(deg2rad*double.Parse(textBox_3b.Text)) 
                },
            };
            for (int i = 0; i < 4; i++) Console.WriteLine("{0},{1},{2}", light_v[i, 0], light_v[i, 1], light_v[i, 2]);
            //カメラの回転角度を，光源ベクトルのy軸周りの逆回転とみなして調整
            var camera_num = double.Parse(textBox_camera.Text);
            double cos = Math.Cos(-deg2rad * camera_num),
                    sin = Math.Sin(-deg2rad * camera_num);
            for (int r = 0; r < 4; r++)
            {
                double x = light_v[r, 0],
                        z = light_v[r, 2];
                light_v[r, 0] = x * cos-z*sin;
                light_v[r, 2] = x * sin + z * cos;
            }
            for (int r = 0; r < 4; r++)//一1以上の数字に調整
                for (int c = 0; c < 3; c++) light_v[r, c] *= 10;

            for (int i = 0; i < 4; i++) Console.WriteLine("{0},{1},{2}", light_v[i, 0], light_v[i, 1], light_v[i, 2]);
            //for (int r = 0; r <4; r++)
            //{//カメラと光源のなす角度の計算
            //    double 内積=0;
            //    double norm_camera=0, norm_light=0;
            //    for (int c = 0; c < 3; c++)
            //    {
            //        内積 += camera_v[c] * light_v[r, c];
            //        norm_camera += camera_v[c] * camera_v[c];
            //        norm_light += light_v[r, c] * light_v[r, c];
            //    }
            //    camera_light_v[r] = Math.Acos(内積 / (norm_camera * norm_light));
            //    //Console.WriteLine(camera_light_v[r]*180.0/Math.PI);
            //}
 
        }
        void 表面角度計算()
        {
            IplImage 表面角度分布 = Cv.CreateImage(new CvSize(テンプレ画像.Width, テンプレ画像.Height), BitDepth.U8, 3);
            表面角度分布.Zero();
            表面角度分布.Not(表面角度分布);
            Console.WriteLine("表面角度計算開始");
            for (int y = 0; y < 入力画像[0].Height; y++)
            {
                for (int x = 0; x < 入力画像[0].Width; x++)
                {
                    if (Cv.Get2D(テンプレ画像, y, x).Val0 != 255)
                    {
                        鏡面反射番号取得(x, y);
                        画素値行列取得(x, y);

                        CvScalar color = new CvScalar(表面角度[x, y][0], 表面角度[x, y][1], 表面角度[x, y][2]);
                        表面角度分布.Set2D(y,x,color);
                        //Console.WriteLine("{0},{1},{2}", 表面角度[x, y][0], 表面角度[x, y][1], 表面角度[x, y][2]);
                    }
                }
            }
            Console.WriteLine("表面角度計算終了");
            pictureBoxIpl1.ImageIpl=表面角度分布;
        }
        void 鏡面反射番号取得(int x,int y)
        {
            double max_val = 0;
            int max_num = 0;
            for (int i = 0; i < 4; i++)
            {
                var val = Cv.Get2D(入力画像[i], y, x).Val0;
                if (val > max_val)
                {
                    max_val = val;
                    max_num = i;//一番輝度値の大きい画像の番号
                }
            }
            鏡面反射番号[x, y] = max_num;
        }
        void 画素値行列取得(int x, int y)
        {
            double[] I=new double[3];//輝度値ベクトル
            double[,] S=new double[3,3];//光源ベクトル
            double[,] S_;//光源ベクトルの逆行列
            double detS;//Sの行列式
            double [] N=new double[3];//法線ベクトル
            int num = 0;
            for (int i = 0; i < 4; i++)
            {
                if (i != 鏡面反射番号[x, y])
                {
                    I[num]=Cv.Get2D(入力画像[i],y,x).Val0;
                    for (int c = 0; c < 3;c++) S[num, c]=light_v[i, c];
                    num++;
                }
            }
            //detA=a11a22a33+a21a32a13+a31a12a23-a11a32a23-a31a22a13-a21a12a33
            detS=S[0,0]*S[1,1]*S[2,2]+S[1,0]*S[2,1]*S[0,2]+S[2,0]*S[0,1]*S[1,2]
                 -S[0,0]*S[2,1]*S[1,2]-S[2,0]*S[1,1]*S[0,2]-S[1,0]*S[0,1]*S[2,2];
            //Console.WriteLine("detS={0}",detS);
            S_ = new double[3, 3] 
                {   { S[1,1]*S[2,2]-S[1,2]*S[2,1], S[0,2]*S[2,1]-S[0,1]*S[2,2], S[0,1]*S[1,2]-S[0,2]*S[1,1]},
                    { S[1,2]*S[2,0]-S[1,0]*S[2,2], S[0,0]*S[2,2]-S[0,2]*S[2,0], S[0,2]*S[1,0]-S[0,0]*S[1,2]},
                    { S[1,0]*S[2,1]-S[1,1]*S[2,0], S[0,1]*S[2,0]-S[0,0]*S[2,1], S[0,0]*S[1,1]-S[0,1]*S[1,0]}
                };
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++) S_[r, c] /= detS;

            //逆行列をかけて法線ベクトル計算
            for (int r = 0; r < 3; r++)
            {
                N[r] = 0;
                for (int c = 0; c < 3; c++) N[r] += S_[r, c] * I[c];
            }
            行列の正規化(ref N, 255);
            表面角度[x, y] = new double[3] {N[0],N[1],N[2]};
        }
        void 行列の正規化(ref double[] array,double val)
        {
            double norm = Math.Sqrt(array[0] * array[0] + array[1] * array[1] + array[2] * array[2]);
            for (int i = 0; i < 3; i++) array[i] *= val / norm;
 
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
                // ファイル名をタイトルバーに設定
                this.Text = dialog.FileNames[0];

                pictureBoxIpl1.ImageIpl = 入力画像[0];
            }
        }
        private void Click_テンプレ(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = false,  // 複数選択の可否
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
                    テンプレ画像 = new IplImage(file.value, LoadMode.Color);
                }
                // ファイル名をタイトルバーに設定
                this.Text = dialog.FileNames[0];
                pictureBoxIpl1.ImageIpl = テンプレ画像;
            }
        }
        private void Click_実行(object sender, EventArgs e)
        {
            表面角度計算();
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
