






using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace collisincontrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //verileri alıyoruz
            int x1, x2, y1, y2, en1, en2, boy1, boy2, r1,r2,  z1, z2;
                string selected = comboBox1.SelectedItem.ToString();
                string selected2 = comboBox2.SelectedItem.ToString();
            x1 = Convert.ToInt32(textBox1.Text);    
            x2= Convert.ToInt32(textBox2.Text); 
            y1= Convert.ToInt32(textBox4.Text);
            y2= Convert.ToInt32(textBox5.Text);
            z1= Convert.ToInt32(textBox3.Text);
            z2= Convert.ToInt32(textBox6.Text);
            en1= Convert.ToInt32(textBox7.Text);
            en2= Convert.ToInt32(textBox8.Text);
            boy1 = Convert.ToInt32(textBox9.Text);
            boy2= Convert.ToInt32(textBox10.Text);
            r1= Convert.ToInt32(textBox11.Text);
            r2= Convert.ToInt32(textBox12.Text);
            //comboboxlarda seçili öğe var mı diye bakıyoruz
             
             if (selected == "nokta" && selected2 == "dörtgen")
                    {

                         Graphics grafik = this.CreateGraphics();
                         grafik.DrawRectangle(Pens.Black, x2, y2, en2, boy2);
                         grafik.DrawEllipse(Pens.Red, x1, y1, 5, 5);
                        if (x1 >= x2 && x1 <= x2 + boy2 && y2 >= y1 && y1 <= y2 + en2)//matematiksel işlemin kontrolü
                        {
                            MessageBox.Show(" nokta ve dörtgen çarpışıyor");

                        }

                        else
                        {
                            MessageBox.Show(" nokta ve dörtgen çarpmıyor");

                        }


                    }
             else if (selected == "dörtgen" && selected2 == "dörtgen")
                    {

                         Graphics grafik = this.CreateGraphics();
                         grafik.DrawRectangle(Pens.Black, x2, y2, en2, boy2);
                          grafik.DrawRectangle(Pens.Blue,x1,y1,en1, boy2);  
                        int solken = x1; int solken2 = x2;
                        int sagken = x1 + en1; int sagken2 = x2 + en2;
                        int ust = y1; int alt = y1 + boy1;
                        int ust2 = y2; int alt2 = y2 + boy2; //gerekli verileri alıp matematiksel olarak dörtgen çarpışma denetimi
                        if (solken < sagken2 && sagken > solken2 && ust < alt2 && alt > ust2)
                        {
                            MessageBox.Show("dörtgenler çarpışıyor");

                        }
                        else
                        {
                            MessageBox.Show("dörtgenler çarpışmıyor");
                        }

                    }
             else if (selected == "çember " && selected2 == "çember")
                    {


                         Graphics grafik = this.CreateGraphics();
                         grafik.DrawEllipse(Pens.Red, x1, y1, r1, r1);
                         grafik.DrawEllipse(Pens.Blue, x2, y2, r2, r2);
                         float xuzaklık = x2 - x1;
                         float yuzaklık = y2 - y1;
                        // çember çember kesişiyormu
                        if (Math.Sqrt((xuzaklık * xuzaklık) + (yuzaklık * yuzaklık)) < (r1 + r2))
                        {
                            MessageBox.Show("çemberler çarpışıyor");
                        }
                        else
                        {
                            MessageBox.Show("çemberler çarpışmıyor");
                        }
                    }
             else if (selected == "nokta " && selected2 == "çember")
                    {

                        Graphics grafik = this.CreateGraphics();
                        grafik.DrawEllipse(Pens.Red, x1, y1, 5, 5);
                        grafik.DrawEllipse(Pens.Blue, x2, y2, r2, r2);
                        float xuzaklık = x2 - x1;
                        float yuzaklık = y2 - y1;
                        double mesafe = Math.Sqrt((xuzaklık * xuzaklık) + (yuzaklık * yuzaklık));
                        if (mesafe < r2)
                        {
                            MessageBox.Show("nokta ve çember çarpışıyor");
                        }
                        else
                        {
                            MessageBox.Show("nokta ve çember çarpışmıyor");
                        }

                    }
             else if (selected == "dörtgen " && selected2 == "çember ")
                    {
                         Graphics grafik = this.CreateGraphics();
                         grafik.DrawEllipse(Pens.Blue, x2, y2, r2, r2);
                         grafik.DrawRectangle(Pens.Blue, x1, y1, en1, boy2);
                        double solken = x1;
                        double sagken = x1 + en1;
                        double ust = y1;
                        double alt = y1 + boy1;
                        double cemx = Math.Abs(x2 - x1 - en1 / 2);
                        double cemy = Math.Abs(y2 - y2 - boy1 / 2);
                        // cember dörtgen çarpışıyor mu bakıyoruz

                        if (cemx > (en1 / 2 + r2) || cemy > (boy1 / 2 + r2))
                        {
                            MessageBox.Show("Dörtgen ve çember çakışmadı");
                        }
                        else if (cemx <= (en1 / 2) || cemy <= (boy1 / 2))
                        {
                            MessageBox.Show("Dörtgen ve çember çarpıştı");
                        }
                        else
                        {
                            double kose = Math.Pow(cemx - en1 / 2, 2) + Math.Pow(cemy - boy1 / 2, 2);
                            // çember köşeye gelince oluşan durum kontrolü
                            if (kose <= Math.Pow(r2, 2))
                            {
                                MessageBox.Show("Dörtgen ve çember çarpıştı");
                            }
                            else
                            {
                                MessageBox.Show("Dörtgen ve çember çakışmadı");
                            }
                        }

                    }
             else if (selected == "nokta " && selected2 == "küre")
                    {

                         Graphics grafik = this.CreateGraphics();
                         grafik.DrawEllipse(Pens.Red, x1, y1, 5, 5);
                         grafik.DrawEllipse(Pens.Blue, x2, y2, r2, r2);
                         //noktanı kürenin merkezinbe olan uzaklığı
                         double uzaklık = Math.Sqrt(Math.Pow(x2 - x2, 2) + Math.Pow(y1 - y2, 2) + Math.Pow(z1 - z2, 2));
                        //nokta küre çarpışıyor mu bakıyoruz

                        if (uzaklık <= r2)
                        {
                            MessageBox.Show("nokta ve küre çarpışıyor");
                        }
                        else
                        {
                            MessageBox.Show("nokta bve küre çarpışmıyor");
                        }

                    }
             else if (selected == "nokta " && selected2 == "dikdörtgenler prizması")
                    {
                        // dikdörgenin merkez noktasını belirliyoruz
                        float yarımen = en2 / 2;
                        float yarımboy = boy2 / 2;
                        float yarımder = r2 / 2;
                        float merkezx = x2 + yarımen;
                        float merkezy = y2 + yarımboy;
                        float merkezz = z2 + yarımder;


                        if (x1 >= x2 && x1 <= x2 + en2 && y1 >= y2 && y1 <= y2 + boy2 && z1 >= z2 && z1 <= z2 + r2)
                        {
                            MessageBox.Show("nokta ve dikdörtgenler prizması çarpışıyor");
                        }
                        else
                        {
                            MessageBox.Show("nokta ve dikdörtgenler prizması çarpışmıyor");
                        }

                    }
             else if (selected == "nokta" && selected2 == "silindir")
                    {
                        //silindirin merkez noktasını belirliyoruz yarıçap ile aradaki mesafeyi kullanarak çarpışma denetimi yapıyoruz
                        double merkez = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(z1 - z2, 2));
                        if (merkez <= r2)
                        {
                            MessageBox.Show("nokta ve silindir çarpışıyor");
                        }
                        else
                        {
                            MessageBox.Show("nokta ve silindir çarpışmıyor");
                        }
                    }
             else if (selected == "silindir " && selected2 == "silindir")
                    {
                        //silindirin merkezi belirlenir
                        double merkez = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
                        //silindir silindir  çarpışıyor mu bakıyoruz
                        if (merkez <= r1 + r2 && Math.Abs(y2 - y1) <= (boy1 + boy2) / 2)
                        {
                            MessageBox.Show("silindir silindir çarpışıyor");
                        }
                        else
                        {
                            MessageBox.Show("silindir silindir çarpışmıyor");

                        }
                    }
             else if (selected == "küre" && selected2 == "küre")
                    {
                         Graphics grafik = this.CreateGraphics();
                         grafik.DrawEllipse(Pens.Red, x1, y1, r1, r1);
                         grafik.DrawEllipse(Pens.Blue, x2, y2, r2, r2);
                         //kürenin merkez noktası belirlenir
                         double merkez = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
                        //küre küre çarpışıyor mu bakıyoruz

                        if (merkez <= r1 + r2)
                        {
                            MessageBox.Show("küreler çarpışıyor");
                        }
                        else
                        {
                            MessageBox.Show("küreler çarpışmıyor");
                        }
                    }
             else if (selected == "silindir" && selected2 == "küre")
                    {
                        double merkez = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) + Math.Pow(z1 - z2, 2));
                        //Küre silindir  çarpışıyor mu bakıyoruz

                        if (merkez <= r1 + r2 && z2 >= 0 && z2 <= boy1)
                        {
                            MessageBox.Show("silindir ve küre çarpışıyor");
                        }
                        else
                        {
                            MessageBox.Show("silindir ve küre çarpışmıyor");
                        }

                    }
             else if (selected == "yüzey" && selected2 == "küre")
                    {
                         Graphics grafik = this.CreateGraphics();
                         grafik.DrawEllipse(Pens.Blue, x2, y2, r2, r2);
                         Pen pen = new Pen(Color.Black, 2);
                         grafik.DrawLine(pen, new Point(417, 0), new Point(417, 480));
                         grafik.DrawLine(pen, new Point(0, 276), new Point(820, 276));
                         // X ekseninde kesiyor mu?
                         if (Math.Abs(x2) <= r2)
                        {
                            MessageBox.Show("Küre x ekseninde kesiyor");
                        }

                        // Y ekseninde kesiyor mu?
                        if (Math.Abs(y2) <= r2)
                        {
                            MessageBox.Show("Küre y ekseninde kesiyor");
                        }

                        // Z ekseninde kesiyor mu?
                        if (Math.Abs(z2) <= r2)
                        {
                            MessageBox.Show("Küre z ekseninde kesiyor");
                        }
                    }
             else if (selected == "yüzey" && selected2 == "silindir")
                    {
                         Graphics grafik = this.CreateGraphics();
                         Pen pen = new Pen(Color.Black, 2);
                         grafik.DrawLine(pen, new Point(417, 0), new Point(417, 480));
                        grafik.DrawLine(pen, new Point(0, 276), new Point(820, 276));
                         if (Math.Abs(x2) <= r2 && Math.Abs(y2) <= boy2 / 2)
                        {
                            MessageBox.Show("Silindir x yüzeyi ile kesiyor");
                        }

                        // Y yüzeyi ile kesiyor mu?
                        if (Math.Abs(y2) <= r2 && Math.Abs(x2) <= boy2 / 2)
                        {
                            MessageBox.Show("Silindir y yüzeyi ile kesiyor");
                        }

                        // Z yüzeyi ile kesiyor mu?
                        if (Math.Abs(z2) <= r2 && Math.Abs(x2) <= boy2 / 2)
                        {
                            MessageBox.Show("Silindir z yüzeyi ile kesiyor");
                        }
                    }
             else if (selected == "yüzey" && selected2 == "dikdörtgenler prizması")
                    {
                           Graphics grafik = this.CreateGraphics();
                            Pen pen = new Pen(Color.Black, 2);
                             grafik.DrawLine(pen, new Point(417, 0), new Point(417, 480));
                            grafik.DrawLine(pen, new Point(0, 276), new Point(820, 276));
                            // X yüzeyi ile kesiyor mu?
                         if (Math.Abs(x2) <= en2 / 2)
                        {
                            MessageBox.Show("Dikdörtgen prizma x yüzeyi ile kesiyor");
                        }

                        // Y yüzeyi ile kesiyor mu?
                        if (Math.Abs(y2) <= boy2 / 2)
                        {
                            MessageBox.Show("Dikdörtgen prizma y yüzeyi ile kesiyor");
                        }

                        // Z yüzeyi ile kesiyor mu?
                        if (Math.Abs(z2) <= r2 / 2)
                        {
                            MessageBox.Show("Dikdörtgen prizma z yüzeyi ile kesiyor");
                        }
                    }
             else if (selected == "küre" && selected2 == "dikdörtgenler prizması")
                    {
                        double merkez = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
                        //küre dikdörtgen prizması çarpışıyor mu bakıyoruz

                        if (merkez <= r1)
                        {
                            MessageBox.Show("cisimler çarpışyor");
                        }
                        else // en yakın bir point belirledik 
                        {
                            double enyakınX = Math.Max(Math.Min(x1, x2 + en2 / 2), x2 - en2 / 2);
                            double enyakınY = Math.Max(Math.Min(y1, y2 + boy2 / 2), y2 - boy2 / 2);
                            double enyakınZ = Math.Max(Math.Min(z1, z2 + r2 / 2), z2 - r2 / 2);

                            double enyakın = Math.Sqrt(Math.Pow(x1 - enyakınX, 2) + Math.Pow(y1 - enyakınY, 2) + Math.Pow(z1 - enyakınZ, 2));
                            // dikdörtgen prizmasının küreye en yakın noktasını kullanarak çarpışma denetimi
                            if (enyakın <= r1)
                            {
                                Console.WriteLine("Küre ve dikdörtgen prizma birbirleriyle çarpışıyor");
                            }
                            else
                            {
                                MessageBox.Show("dikdörtgenler prizması ve küre çarpışmıyor");
                            }
                        }

                    }                
             else if (selected == "dikdörtgenler prziması " && selected2 == "dikdörtgenler prizması")
                    {
                        //dikdörtgen prizması dikdörtgen prizması çarpışıyor mu bakıyoruz
                        if (x1 + en1 >= x2 && x1 <= x2 + en2 && y1 + boy1 >= y2 && y1 <= y2 + boy2 && z1 + r1 >= z2 && z1 <= z2 + r2)
                        {
                            MessageBox.Show("İki dikdörtgen prizma birbirleriyle çarpışıyor");
                        }
                        else
                        {
                            MessageBox.Show("İki dikdörtgen prizma birbirleriyle çarpışmıyor");
                        }

                    }
               
            





        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }
        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
