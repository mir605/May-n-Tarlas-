using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mayın_Tarlası
{
    public partial class Form1 : Form
    {

        Random random = new Random();
        int puan = 0;

        //Tahtanın ebatı
        int[,] ButtonValue = new int[7, 9];
        public Form1()  

        
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonCreator();

        }

        public void ButtonCreator()
        {
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < 7; i++)
            {
                for (int j=0; j <9; j++)
                {
                    Button button = new Button();
                    button.Text = string.Empty;

                    int randomDeger = random.Next(0, 2);
                    button.Tag = randomDeger;
                    button.BackColor = Color.BlueViolet;
                    button.Size = new System.Drawing.Size(34, 34);


                    flowLayoutPanel1.Controls.Add(button);
                    button.Click += ButtonClicker;

                    ButtonValue[i, j] = randomDeger;
                }
            }

        }
      

       


        public void ButtonClicker(object sender, EventArgs e)
        {
            
            Button clickedButton = sender as Button;

            if(clickedButton!= null)
            {
                int value = (int)clickedButton.Tag;
                //sıfıra tıklanınca oyun biter buton kırmızıya döner.
                if(value==0)
                {
                    clickedButton.BackColor = Color.Red;
                    
                    MessageBox.Show($"Oyunu kaybettiniz çünkü mayına bastınız\n Puanınız: {puan}");
                    puan = 0;
                    //oyun tahtası sıfırlanır
                    flowLayoutPanel1.Controls.Clear();
                    PuanEkleyici();

                }

                //butonun değeri 1 ise rengi yeşile çevir puanı 1 arttır
                if(value==1) 
                {
                    clickedButton.BackColor = Color.Green;
                    
                    puan++;
                    PuanEkleyici();//puanı güncelle
                }
               
                
            }
        }

       


      

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        public void PuanEkleyici()
        {
            label1.Text = "Puan: " + puan.ToString();
        }

    }
}
