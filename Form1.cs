using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Data.Linq;
using System.Windows.Forms;
using Microsoft.Office.InfoPath;

namespace MNB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public XmlDocument doc;         // Postalista elérhetõsége
        public XmlNodeList postalista;  // postalista változó
        //public string chkbox1 = "Nem";
        public string TIG;              // Területi igazgatóság azonosító - SAP betöltéshez
        public static string formSAP;
        public static string posta;
        //public string eredmeny;
        //public string chkBox_allapot;   // 0: Letiltva 1: Írható
        public string adatchk;            // 0: OK 1:Hiba
        public string K_1;
        public string M_1;
        public string K_2;
        public string M_2;
        public string K_3;
        public string M_3;
        public string K_4;
        public string M_4;
        public string K_5;
        public string M_5;
        public string K_6;
        public string M_6;
        public string K_7;
        public string M_7;
        public string K_8;
        public string M_8;
        public string K_9;
        public string M_9;
        public string K_10;
        public string M_10;

        public string boxChk4 = " ";
        public string boxChk5 = " ";
        public string boxChk51 = " ";
        public string boxChk7 = " ";
        public string boxChk6 = " ";
        public string boxChk12 = " ";
        public string boxChk11 = " ";
        public string boxChk17 = " ";
        public string boxChk16 = " ";
        public string boxChk22 = " ";
        public string boxChk21 = " ";
        public string boxChk32 = " ";
        public string boxChk31 = " ";
        public string boxChk37 = " ";
        public string boxChk36 = " ";
        public string boxChk42 = " ";
        public string boxChk41 = " ";






        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument(); // Ez máûködik, 
            //doc.Load(@"C:\Teszt_adat\Postalista.xml");//Server.MapPath("regis.xml"));
            doc.Load(@"\\teamweb2\sites\TMEK\manager\Connections\Postalista.xml");

            XmlNodeList postalista;
            XmlNode root = doc.DocumentElement;
            postalista = root.SelectNodes("descendant::Postalista[contains(Igazgatóság, 'Igazgatóság')]");//Nyugat-magyarországi Területi Igazgatóság']");
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();

            foreach (XmlNode posta in postalista)
            {
                comboBox1.Items.Add(posta.FirstChild.InnerText);
            }

            if (comboBox2.Text == "")
            {
                checkBox1.Checked = false;
                //button3.Enabled = false;
            }
            else
            {
                //button3.Enabled = false;
            }

            if (textBox1.Text.Length != 8)      // HA a SAP szám nem 8 karakter hosszúságú
            {
                chkbox_letiltas();
                button1.Enabled = false;
            }
            else
            {
                chkbox_engedelyezes();
                button1.Enabled = true;
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                //doc.Load(@"C:\Teszt_adat\Postalista.xml");
                doc.Load(@"\\teamweb2\sites\TMEK\manager\Connections\Postalista.xml");
                postalista = doc.DocumentElement.SelectNodes("descendant::Postalista[Név='" + comboBox1.Text + "']");
                foreach (XmlNode posta in postalista)
                {
                    textBox3.Text = posta.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText;
                    //textBox4.Text = posta.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText;
                }


                if (textBox3.Text == "Központi Területi Igazgatóság")
                {
                    XmlDocument doc_sap = new XmlDocument();
                    //doc_sap.Load(@"C:\Teszt_adat\SAP\SAP_KTIG.xml");
                    doc_sap.Load(@"\\teamweb2\sites\TMEK\manager\Connections\SAP_KTIG.xml");
                    TIG = "SAP_KTIG";

                    XmlNodeList sapTIG = doc_sap.DocumentElement.SelectNodes("descendant::" + TIG + "[PostaNev='" + comboBox1.Text + "']");
                    comboBox2.Items.Clear();
                    textBox1.Clear();
                    textBox2.Clear();

                    foreach (XmlNode sap in sapTIG)
                    {
                        comboBox2.Items.Add(sap.FirstChild.NextSibling.NextSibling.NextSibling.InnerText);
                    }
                }
                else if (textBox3.Text == "Nyugat-magyarországi Területi Igazgatóság")
                {
                    XmlDocument doc_sap = new XmlDocument();
                    //doc_sap.Load(@"C:\Teszt_adat\SAP\SAP_NYMTIG.xml");
                    doc_sap.Load(@"\\teamweb2\sites\TMEK\manager\Connections\SAP_NYMTIG.xml");
                    TIG = "SAP_NYMTIG";

                    XmlNodeList sapTIG = doc_sap.DocumentElement.SelectNodes("descendant::" + TIG + "[PostaNev='" + comboBox1.Text + "']");
                    comboBox2.Items.Clear();
                    textBox1.Clear();
                    textBox2.Clear();

                    foreach (XmlNode sap in sapTIG)
                    {
                        comboBox2.Items.Add(sap.FirstChild.NextSibling.NextSibling.NextSibling.InnerText);
                    }
                }
                else if (textBox3.Text == "Kelet-magyarországi Területi Igazgatóság")
                {
                    XmlDocument doc_sap = new XmlDocument();
                    //doc_sap.Load(@"C:\Teszt_adat\SAP\SAP_KMTIG.xml");
                    doc_sap.Load(@"\\teamweb2\sites\TMEK\manager\Connections\SAP_KMTIG.xml");
                    TIG = "SAP_KMTIG";

                    XmlNodeList sapTIG = doc_sap.DocumentElement.SelectNodes("descendant::" + TIG + "[PostaNev='" + comboBox1.Text + "']");
                    comboBox2.Items.Clear();
                    textBox1.Clear();
                    textBox2.Clear();


                    foreach (XmlNode sap in sapTIG)
                    {
                        comboBox2.Items.Add(sap.FirstChild.NextSibling.NextSibling.NextSibling.InnerText);
                    }
                }

                if (comboBox1.Text.Contains("irendeltség") ||
                    comboBox1.Text.Contains("partner"))
                {
                    comboBox2.DropDownStyle = ComboBoxStyle.DropDown;
                    textBox1.ReadOnly = false;
                    textBox2.ReadOnly = false;
                    comboBox2.Text = "";
                    textBox1.Text = "00000000";
                    textBox2.Text = "";
                }
                else
                {
                    comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox2.Text = "";
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox1.Text = "";
                    textBox2.Text = "";
                }

                if (comboBox1.Text != "" && textBox1.Text == "") // comboBox2.Text == "")
                {
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }

                //textBox1.Text = comboBox2.Items.Count.ToString(); // Megszámolja hány dolgozó van adott postán
            }
            catch (System.Exception)
            {

                DialogResult dr03 = MessageBox.Show("Az adatkapcsolatot létrehozása során hiba lépett fel, ezért a rögzítés nem lehetséges! A megoldásra két lehetõség van:\n\n" +
                "1. Zárd be az alkalmazást, majd egy késõbbi idõpontban ismét próbáld meg a rögzítést.\n\n" +
                "2. Bontsd a VPN kapcsolatot, majd ismét kapcsolódj és próbáld meg a rögzítést!", "Adatkapcsolati hiba!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //checkBox1.Checked = false;

            //if (comboBox2.Text == "")
            //{
            //    button3.Visible = false;
            //    button3.Enabled = false;
            //}
            //else
            //{
            //    button3.Visible = true;
            //    button3.Enabled = true;
            //}

            if (textBox3.Text == "Központi Területi Igazgatóság")
            {
                XmlDocument doc_sap = new XmlDocument();
                doc_sap.Load(@"\\teamweb2\sites\TMEK\manager\Connections\SAP_KTIG.xml");
                TIG = "SAP_KTIG";
                XmlNodeList munkavallaloSAP = doc_sap.DocumentElement.SelectNodes("descendant::" + TIG + "[PostaNev='" + comboBox1.Text + "']" + "[DolgozoNev='" + comboBox2.Text + "']" + "[SZTSZ!='" + textBox1.Text + "']");

                foreach (XmlNode mv_sap in munkavallaloSAP)
                {
                    textBox1.Text = mv_sap.FirstChild.InnerText.ToString();
                    textBox2.Text = mv_sap.LastChild.InnerText;
                }
            }
            else if (textBox3.Text == "Nyugat-magyarországi Területi Igazgatóság")
            {
                XmlDocument doc_sap = new XmlDocument();
                //doc_sap.Load(@"C:\Teszt_adat\SAP\SAP_NYMTIG.xml");
                doc_sap.Load(@"\\teamweb2\sites\TMEK\manager\Connections\SAP_NYMTIG.xml");
                TIG = "SAP_NYMTIG";
                XmlNodeList munkavallaloSAP = doc_sap.DocumentElement.SelectNodes("descendant::" + TIG + "[PostaNev='" + comboBox1.Text + "']" + "[DolgozoNev='" + comboBox2.Text + "']" + "[SZTSZ!='" + textBox1.Text + "']");

                foreach (XmlNode mv_sap in munkavallaloSAP)
                {
                    textBox1.Text = mv_sap.FirstChild.InnerText.ToString();
                    textBox2.Text = mv_sap.LastChild.InnerText;
                }
            }
            else if (textBox3.Text == "Kelet-magyarországi Területi Igazgatóság")
            {
                XmlDocument doc_sap = new XmlDocument();
                doc_sap.Load(@"\\teamweb2\sites\TMEK\manager\Connections\SAP_KMTIG.xml");
                TIG = "SAP_KMTIG";
                XmlNodeList munkavallaloSAP = doc_sap.DocumentElement.SelectNodes("descendant::" + TIG + "[PostaNev='" + comboBox1.Text + "']" + "[DolgozoNev='" + comboBox2.Text + "']" + "[SZTSZ!='" + textBox1.Text + "']");

                foreach (XmlNode mv_sap in munkavallaloSAP)
                {
                    textBox1.Text = mv_sap.FirstChild.InnerText.ToString();
                    textBox2.Text = mv_sap.LastChild.InnerText;
                }
            }

            if (textBox1.Text == "")
            {
                textBox2.Text = "";
            }
        }

        private void chkbox_letiltas()
        {
            if (textBox1.Text.Length != 8)
            {
                checkBox1.Enabled = false;
                checkBox1.Checked = false;
                checkBox2.Enabled = false;
                checkBox2.Checked = false;
                checkBox3.Enabled = false;
                checkBox3.Checked = false;
                checkBox4.Enabled = false;
                checkBox4.Checked = false;
                checkBox5.Enabled = false;
                checkBox5.Checked = false;
                checkBox6.Enabled = false;
                checkBox6.Checked = false;
                checkBox7.Enabled = false;
                checkBox7.Checked = false;
                checkBox8.Enabled = false;
                checkBox8.Checked = false;
                checkBox9.Enabled = false;
                checkBox9.Checked = false;
                checkBox10.Enabled = false;
                checkBox10.Checked = false;
                checkBox11.Enabled = false;
                checkBox11.Checked = false;
                checkBox12.Enabled = false;
                checkBox12.Checked = false;
                checkBox13.Enabled = false;
                checkBox13.Checked = false;
                checkBox14.Enabled = false;
                checkBox14.Checked = false;
                checkBox15.Enabled = false;
                checkBox15.Checked = false;
                checkBox16.Enabled = false;
                checkBox16.Checked = false;
                checkBox17.Enabled = false;
                checkBox17.Checked = false;
                checkBox18.Enabled = false;
                checkBox18.Checked = false;
                checkBox19.Enabled = false;
                checkBox19.Checked = false;
                checkBox20.Enabled = false;
                checkBox20.Checked = false;
                checkBox21.Enabled = false;
                checkBox21.Checked = false;
                checkBox22.Enabled = false;
                checkBox22.Checked = false;
                checkBox23.Enabled = false;
                checkBox23.Checked = false;
                checkBox24.Enabled = false;
                checkBox24.Checked = false;
                checkBox25.Enabled = false;
                checkBox25.Checked = false;
                //checkBox28.Enabled = false;
                //checkBox28.Checked = false;
                //checkBox30.Enabled = false;
                //checkBox30.Checked = false;
                //checkBox31.Enabled = false;
                //checkBox31.Checked = false;
                //checkBox32.Enabled = false;
                //checkBox32.Checked = false;
                //checkBox33.Enabled = false;
                //checkBox33.Checked = false;
                //checkBox34.Enabled = false;
                //checkBox34.Checked = false;
                //checkBox35.Enabled = false;
                //checkBox35.Checked = false;
                //checkBox36.Enabled = false;
                //checkBox36.Checked = false;
                //checkBox37.Enabled = false;
                //checkBox37.Checked = false;
                //checkBox38.Enabled = false;
                //checkBox38.Checked = false;
                //checkBox39.Enabled = false;
                //checkBox39.Checked = false;
                //checkBox40.Enabled = false;
                //checkBox40.Checked = false;
                //checkBox41.Enabled = false;
                //checkBox41.Checked = false;
                //checkBox42.Enabled = false;
                //checkBox42.Checked = false;
                //checkBox43.Enabled = false;
                //checkBox43.Checked = false;
                //checkBox44.Enabled = false;
                //checkBox44.Checked = false;
                //checkBox45.Enabled = false;
                //checkBox45.Checked = false;
                //checkBox48.Enabled = false;
                //checkBox48.Checked = false;
                //checkBox50.Enabled = false;
                //checkBox50.Checked = false;
                //checkBox51.Enabled = false;
                //checkBox51.Checked = false;
            }
        }

        private void chkbox_engedelyezes()
        {
            if (textBox1.Text.Length == 8)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                //checkBox4.Enabled = true;
                //checkBox5.Enabled = true;
                //checkBox6.Enabled = true;
                //checkBox7.Enabled = true;
                checkBox8.Enabled = true;
                checkBox9.Enabled = true;
                checkBox10.Enabled = true;
                //checkBox11.Enabled = true;
                //checkBox12.Enabled = true;
                checkBox13.Enabled = true;
                checkBox14.Enabled = true;
                checkBox15.Enabled = true;
                //checkBox16.Enabled = true;
                //checkBox17.Enabled = true;
                checkBox18.Enabled = true;
                checkBox19.Enabled = true;
                checkBox20.Enabled = true;
                //checkBox21.Enabled = true;
                //checkBox22.Enabled = true;
                checkBox23.Enabled = true;
                checkBox24.Enabled = true;
                checkBox25.Enabled = true;
                //checkBox28.Enabled = true;
                ////checkBox29.Enabled = true;
                //checkBox30.Enabled = true;
                ////checkBox31.Enabled = true;
                ////checkBox32.Enabled = true;
                //checkBox33.Enabled = true;
                //checkBox34.Enabled = true;
                //checkBox35.Enabled = true;
                ////checkBox36.Enabled = true;
                ////checkBox37.Enabled = true;
                //checkBox38.Enabled = true;
                //checkBox39.Enabled = true;
                //checkBox40.Enabled = true;
                ////checkBox41.Enabled = true;
                ////checkBox42.Enabled = true;
                //checkBox43.Enabled = true;
                //checkBox44.Enabled = true;
                //checkBox45.Enabled = true;
                ////checkBox46.Enabled = true;
                ////checkBox47.Enabled = true;
                //checkBox48.Enabled = true;
                //checkBox50.Enabled = true;
                //checkBox51.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)   //SAP szám
        {
            try
            {
                if (textBox4.Text.Contains(textBox1.Text) && textBox4.Text.Length > 8 && textBox1.Text.Length == 8)
                {
                    DialogResult dr04 = MessageBox.Show("Erre a kezelõre már rögzítettél adatokat!", "Adatrögzítési hiba!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox2.SelectedIndex = -1;
                    textBox1.Text = "";
                    textBox2.Text = "";

                }
                else
                {
                    if (textBox1.Text.Length == 8)
                    {
                        //textBox4.Text = "1";
                        chkbox_engedelyezes();
                        button1.Enabled = true;
                    }
                    else
                    {
                        //textBox4.Text = "0";
                        chkbox_letiltas();
                        button1.Enabled = false;
                    }
                }
            }
            catch
            {
               
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
                checkBox3.Checked = false;
                checkBox3.Enabled = false;
                K_1 = "Igen";
            }
            else
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                K_1 = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                checkBox3.Checked = false;
                checkBox3.Enabled = false;
                K_1 = "Nem";
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                K_1 = "";
            }
        }
        

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                checkBox1.Checked = false;
                checkBox1.Enabled = true;
                checkBox2.Checked = false;
                checkBox2.Enabled = true;
                checkBox4.Checked = false;
                checkBox4.Enabled = false;
                checkBox5.Checked = false;
                checkBox5.Enabled = false;
                //checkBox51.Checked = false;
                //checkBox51.Enabled = false;
                K_1 = "";
            }
            else
            {
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                //checkBox51.Enabled = true;
                K_1 = "Részben";
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                checkBox9.Checked = false;
                checkBox9.Enabled = false;
                checkBox10.Checked = false;
                checkBox10.Enabled = false;
                K_2 = "Igen";
            }
            else
            {
                checkBox9.Enabled = true;
                checkBox10.Enabled = true;
                K_2 = "";
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                checkBox8.Checked = false;
                checkBox8.Enabled = false;
                checkBox10.Checked = false;
                checkBox10.Enabled = false;
                K_2 = "Nem";
            }
            else
            {
                checkBox8.Enabled = true;
                checkBox10.Enabled = true;
                K_2 = "";
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == false)
            {
                checkBox7.Checked = false;
                checkBox7.Enabled = false;
                checkBox6.Checked = false;
                checkBox6.Enabled = false;
                checkBox8.Checked = false;
                checkBox8.Enabled = true;
                checkBox9.Checked = false;
                checkBox9.Enabled = true;
                K_2 = "";
            }
            else
            {
                checkBox7.Enabled = true;
                checkBox6.Enabled = true;
                checkBox8.Enabled = false;
                checkBox9.Enabled = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                K_2 = "Részben";
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == false)
            {
                checkBox12.Checked = false;
                checkBox12.Enabled = false;
                checkBox11.Checked = false;
                checkBox11.Enabled = false;
                checkBox13.Checked = false;
                checkBox13.Enabled = true;
                checkBox14.Checked = false;
                checkBox14.Enabled = true;
                K_3 = "";
            }
            else
            {
                checkBox12.Enabled = true;
                checkBox11.Enabled = true;
                checkBox13.Enabled = false;
                checkBox14.Enabled = false;
                K_3 = "Részben";
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked == false)
            {
                checkBox17.Checked = false;
                checkBox17.Enabled = false;
                checkBox16.Checked = false;
                checkBox16.Enabled = false;
                checkBox18.Checked = false;
                checkBox18.Enabled = true;
                checkBox19.Checked = false;
                checkBox19.Enabled = true;
                K_4 = "";
            }
            else
            {
                checkBox17.Enabled = true;
                checkBox16.Enabled = true;
                checkBox18.Enabled = false;
                checkBox19.Enabled = false;
                K_4 = "Részben";
            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked == false)
            {
                checkBox22.Checked = false;
                checkBox22.Enabled = false;
                checkBox21.Checked = false;
                checkBox21.Enabled = false;
                checkBox25.Checked = false;
                checkBox25.Enabled = true;
                checkBox23.Checked = false;
                checkBox23.Enabled = true;
                K_5 = "";
            }
            else
            {
                checkBox22.Enabled = true;
                checkBox21.Enabled = true;
                checkBox25.Enabled = false;
                checkBox23.Enabled = false;
                K_5 = "Részben";
            }
        }

       

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                checkBox14.Checked = false;
                checkBox14.Enabled = false;
                checkBox15.Checked = false;
                checkBox15.Enabled = false;
                K_3 = "Igen";
            }
            else
            {
                checkBox14.Enabled = true;
                checkBox15.Enabled = true;
                K_3 = "";
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                checkBox13.Checked = false;
                checkBox13.Enabled = false;
                checkBox15.Checked = false;
                checkBox15.Enabled = false;
                K_3 = "Nem";
            }
            else
            {
                checkBox13.Enabled = true;
                checkBox15.Enabled = true;
                K_3 = "";
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked == true)
            {
                checkBox19.Checked = false;
                checkBox19.Enabled = false;
                checkBox20.Checked = false;
                checkBox20.Enabled = false;
                K_4 = "Igen";
            }
            else
            {
                checkBox19.Enabled = true;
                checkBox20.Enabled = true;
                K_4 = "";
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked == true)
            {
                checkBox18.Checked = false;
                checkBox18.Enabled = false;
                checkBox20.Checked = false;
                checkBox20.Enabled = false;
                K_4 = "Nem";
            }
            else
            {
                checkBox18.Enabled = true;
                checkBox20.Enabled = true;
                K_4 = "";
            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked == true)
            {
                checkBox23.Checked = false;
                checkBox23.Enabled = false;
                checkBox24.Checked = false;
                checkBox24.Enabled = false;
                K_5 = "Igen";
            }
            else
            {
                checkBox23.Enabled = true;
                checkBox24.Enabled = true;
                K_5 = "";
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == true)
            {
                checkBox25.Checked = false;
                checkBox25.Enabled = false;
                checkBox24.Checked = false;
                checkBox24.Enabled = false;
                K_5 = "Nem";
            }
            else
            {
                checkBox25.Enabled = true;
                checkBox24.Enabled = true;
                K_5 = "";
            }
        }

        //private void checkBox30_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox30.Checked == true)
        //    {
        //        checkBox28.Checked = false;
        //        checkBox28.Enabled = false;
        //        K_6 = "Igen";
        //    }
        //    else
        //    {
        //        checkBox28.Enabled = true;
        //        K_6 = "";
        //    }
        //}

        //private void checkBox28_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox28.Checked == true)
        //    {
        //        checkBox30.Checked = false;
        //        checkBox30.Enabled = false;
        //        K_6 = "Nem";
        //    }
        //    else
        //    {
        //        checkBox30.Enabled = true;
        //        K_6 = "";
        //    }
        //}

        //private void checkBox35_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox35.Checked == true)
        //    {
        //        checkBox33.Checked = false;
        //        checkBox33.Enabled = false;
        //        checkBox34.Checked = false;
        //        checkBox34.Enabled = false;
        //        K_7 = "Igen";
        //    }
        //    else
        //    {
        //        checkBox33.Enabled = true;
        //        checkBox34.Enabled = true;
        //        K_7 = "";
        //    }
        //}

        //private void checkBox33_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox33.Checked == true)
        //    {
        //        checkBox35.Checked = false;
        //        checkBox35.Enabled = false;
        //        checkBox34.Checked = false;
        //        checkBox34.Enabled = false;
        //        K_7 = "Nem";
        //    }
        //    else
        //    {
        //        checkBox35.Enabled = true;
        //        checkBox34.Enabled = true;
        //        K_7 = "";
        //    }
        //}

        //private void checkBox34_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox34.Checked == false)
        //    {
        //        checkBox32.Checked = false;
        //        checkBox32.Enabled = false;
        //        checkBox31.Checked = false;
        //        checkBox31.Enabled = false;
        //        checkBox35.Checked = false;
        //        checkBox35.Enabled = true;
        //        checkBox33.Checked = false;
        //        checkBox33.Enabled = true;
        //        K_7 = "";
                
        //    }
        //    else
        //    {
        //        checkBox32.Enabled = true;
        //        checkBox31.Enabled = true;
        //        checkBox35.Enabled = false;
        //        checkBox33.Enabled = false;
        //        K_7 = "Részben";
        //    }
        //}

        //private void checkBox40_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox40.Checked == true)
        //    {
        //        checkBox38.Checked = false;
        //        checkBox38.Enabled = false;
        //        checkBox39.Checked = false;
        //        checkBox39.Enabled = false;
        //        K_8 = "Igen";
        //    }
        //    else
        //    {
        //        checkBox38.Enabled = true;
        //        checkBox39.Enabled = true;
        //        K_8 = "";
        //    }
        //}

        //private void checkBox38_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox38.Checked == true)
        //    {
        //        checkBox40.Checked = false;
        //        checkBox40.Enabled = false;
        //        checkBox39.Checked = false;
        //        checkBox39.Enabled = false;
        //        K_8 = "Nem";
        //    }
        //    else
        //    {
        //        checkBox40.Enabled = true;
        //        checkBox39.Enabled = true;
        //        K_8 = "";
        //    }
        //}

        //private void checkBox39_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox39.Checked == false)
        //    {
        //        checkBox37.Checked = false;
        //        checkBox37.Enabled = false;
        //        checkBox36.Checked = false;
        //        checkBox36.Enabled = false;
        //        checkBox40.Checked = false;
        //        checkBox40.Enabled = true;
        //        checkBox38.Checked = false;
        //        checkBox38.Enabled = true;
        //        K_8 = "";
        //    }
        //    else
        //    {
        //        checkBox37.Enabled = true;
        //        checkBox36.Enabled = true;
        //        checkBox40.Enabled = false;
        //        checkBox38.Enabled = false;
        //        K_8 = "Részben";
        //    }
        //}

        //private void checkBox45_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox45.Checked == true)
        //    {
        //        checkBox43.Checked = false;
        //        checkBox43.Enabled = false;
        //        checkBox44.Checked = false;
        //        checkBox44.Enabled = false;
        //        K_9 = "Igen";
        //    }
        //    else
        //    {
        //        checkBox43.Enabled = true;
        //        checkBox44.Enabled = true;
        //        K_9 = "";
        //    }
        //}

        //private void checkBox43_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox43.Checked == true)
        //    {
        //        checkBox45.Checked = false;
        //        checkBox45.Enabled = false;
        //        checkBox44.Checked = false;
        //        checkBox44.Enabled = false;
        //        K_9 = "Nem";
        //    }
        //    else
        //    {
        //        checkBox45.Enabled = true;
        //        checkBox44.Enabled = true;
        //        K_9 = "";
        //    }
        //}

        //private void checkBox44_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox44.Checked == false)
        //    {
        //        checkBox42.Checked = false;
        //        checkBox42.Enabled = false;
        //        checkBox41.Checked = false;
        //        checkBox41.Enabled = false;
        //        checkBox45.Checked = false;
        //        checkBox45.Enabled = true;
        //        checkBox43.Checked = false;
        //        checkBox43.Enabled = true;
        //        K_9 = "";
        //    }
        //    else
        //    {
        //        checkBox42.Enabled = true;
        //        checkBox41.Enabled = true;
        //        checkBox45.Enabled = false;
        //        checkBox43.Enabled = false;
        //        K_9 = "Részben";
        //    }
        //}

        //private void checkBox50_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox50.Checked == true)
        //    {
        //        checkBox48.Checked = false;
        //        checkBox48.Enabled = false;
        //        K_10 = "Igen";
        //    }
        //    else
        //    {
        //        checkBox48.Enabled = true;
        //        K_10 = "";
        //    }
        //}

        //private void checkBox48_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox48.Checked == true)
        //    {
        //        checkBox50.Checked = false;
        //        checkBox50.Enabled = false;
        //        K_10 = "Nem";
        //    }
        //    else
        //    {
        //        checkBox50.Enabled = true;
        //        K_10 = "";
        //    }
        //}

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > DateTime.Now)
            {
                DialogResult ds = MessageBox.Show("Az ellenõrzés napja nem lehet nagyobb a mai napnál!", "Adatrögzítési hiba!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                boxChk4 = ",A";                                        
            }
            else
            {
                boxChk4 = "";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                boxChk5 = ",B";
            }
            else
            {
                boxChk5 = "";
            }
        }

        //private void checkBox51_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox51.Checked == true)
        //    {
        //        boxChk51 = ",C";
        //    }
        //    else
        //    {
        //        boxChk51 = "";
        //    }
        //}

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                boxChk7 = ",A";
            }
            else
            {
                boxChk7 = "";
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                boxChk6 = ",B";
            }
            else
            {
                boxChk6 = "";
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                boxChk12 = ",A";
            }
            else
            {
                boxChk12 = "";
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                boxChk11 = ",B";
            }
            else
            {
                boxChk11 = "";
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == true)
            {
                boxChk17 = ",A";
            }
            else
            {
                boxChk17 = "";
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked == true)
            {
                boxChk16 = ",B";
            }
            else
            {
                boxChk16 = "";
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked == true)
            {
                boxChk22 = ",A";
            }
            else
            {
                boxChk22 = "";
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked == true)
            {
                boxChk21 = ",B";
            }
            else
            {
                boxChk21 = "";
            }
        }

        //private void checkBox32_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox32.Checked == true)
        //    {
        //        boxChk32 = ",A";
        //    }
        //    else
        //    {
        //        boxChk32 = "";
        //    }
        //}

        //private void checkBox31_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox31.Checked == true)
        //    {
        //        boxChk31 = ",B";
        //    }
        //    else
        //    {
        //        boxChk31 = "";
        //    }
        //}

        //private void checkBox37_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox37.Checked == true)
        //    {
        //        boxChk37 = ",A";
        //    }
        //    else
        //    {
        //        boxChk37 = "";
        //    }
        //}

        //private void checkBox36_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox36.Checked == true)
        //    {
        //        boxChk36 = ",B";
        //    }
        //    else
        //    {
        //        boxChk36 = "";
        //    }
        //}

        //private void checkBox42_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox42.Checked == true)
        //    {
        //        boxChk42 = ",A";
        //    }
        //    else
        //    {
        //        boxChk42 = "";
        //    }
        //}

        //private void checkBox41_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox41.Checked == true)
        //    {
        //        boxChk41 = ",B";
        //    }
        //    else
        //    {
        //        boxChk41 = "";
        //    }
        //}

        private void megjegyzes_osszerako()
        {
            if (boxChk4.Trim().Length > 0 || boxChk5.Trim().Length > 0 || boxChk51.Trim().Length > 0)
            {
                M_1 = string.Concat(boxChk4.Trim(), boxChk5.Trim(), boxChk51.Trim()).Substring(1, string.Concat(boxChk4.Trim(), boxChk5.Trim(), boxChk51.Trim()).Length - 1);
            }
            else
            {
                M_1 = string.Empty;
            }

            if (boxChk7.Trim().Length > 0 || boxChk6.Trim().Length > 0)
            {
                M_2 = string.Concat(boxChk7.Trim(), boxChk6.Trim()).Substring(1, string.Concat(boxChk7.Trim(), boxChk6.Trim()).Length - 1);
            }
            else
            {
                M_2 = string.Empty;
            }


            if (boxChk12.Trim().Length > 0 || boxChk11.Trim().Length > 0)
            {
                M_3 = string.Concat(boxChk12.Trim(), boxChk11.Trim()).Substring(1, string.Concat(boxChk12.Trim(), boxChk11.Trim()).Length - 1);
            }
            else
            {
                M_3 = string.Empty;
            }

            if (boxChk17.Trim().Length > 0 || boxChk16.Trim().Length > 0)
            {
                M_4 = string.Concat(boxChk17.Trim(), boxChk16.Trim()).Substring(1, string.Concat(boxChk17.Trim(), boxChk16.Trim()).Length - 1);
            }
            else
            {
                M_4 = string.Empty;
            }

            if (boxChk22.Trim().Length > 0 || boxChk21.Trim().Length > 0)
            {
                M_5 = string.Concat(boxChk22.Trim(), boxChk21.Trim()).Substring(1, string.Concat(boxChk22.Trim(), boxChk21.Trim()).Length - 1);
            }
            else
            {
                M_5 = string.Empty;
            }

            if (boxChk32.Trim().Length > 0 || boxChk31.Trim().Length > 0)
            {
                M_7 = string.Concat(boxChk32.Trim(), boxChk31.Trim()).Substring(1, string.Concat(boxChk32.Trim(), boxChk31.Trim()).Length - 1);
            }
            else
            {
                M_7 = string.Empty;
            }

            if (boxChk37.Trim().Length > 0 || boxChk36.Trim().Length > 0)
            {
                M_8 = string.Concat(boxChk37.Trim(), boxChk36.Trim()).Substring(1, string.Concat(boxChk37.Trim(), boxChk36.Trim()).Length - 1);
            }
            else
            {
                M_8 = string.Empty;
            }

            if (boxChk42.Trim().Length > 0 || boxChk41.Trim().Length > 0)
            {
                M_9 = string.Concat(boxChk42.Trim(), boxChk41.Trim()).Substring(1, string.Concat(boxChk42.Trim(), boxChk41.Trim()).Length - 1);
            }
            else
            {
                M_9 = string.Empty;
            }
        }

        private void adatellenorzes()
        {
            try
            {
                if (K_1.Length == 0 || K_1 == "Részben" && M_1.Trim().Length == 0 ||
                    K_2.Length == 0 || K_2 == "Részben" && M_2.Trim().Length == 0 ||
                    K_3.Length == 0 || K_3 == "Részben" && M_3.Trim().Length == 0 ||
                    K_4.Length == 0 || K_4 == "Részben" && M_4.Trim().Length == 0 ||
                    K_5.Length == 0 || K_5 == "Részben" && M_5.Trim().Length == 0)
                    //K_6.Length == 0 ||
                    //K_7.Length == 0 || K_7 == "Részben" && M_7.Trim().Length == 0 ||
                    //K_8.Length == 0 || K_8 == "Részben" && M_8.Trim().Length == 0 ||
                    //K_9.Length == 0 || K_9 == "Részben" && M_9.Trim().Length == 0 ||
                    //K_10.Length == 0)
                {
                    DialogResult ds2 = MessageBox.Show("Nem minden kérdésre adtál választ!\n\nAmíg a hiányosságot nem javítod, a mentés nem lehetséges!", "Adatrögzítési hiba!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    adatchk = "1";
                }
                else
                {
                    adatchk = "0";
                }
            }
            catch
            {
                DialogResult ds2 = MessageBox.Show("Nem minden kérdésre adtál választ!\n\nAmíg a hiányosságot nem javítod, a mentés nem lehetséges!", "Adatrögzítési hiba!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                adatchk = "1";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            megjegyzes_osszerako();
            adatellenorzes();

            //MessageBox.Show("K_1: " + K_1 + "\n" +
            //                "M_1: " + M_1 + "\n" +
            //                "K_2: " + K_2 + "\n" +
            //                "M_2: " + M_2 + "\n" +
            //                "K_3: " + K_3 + "\n" +
            //                "M_3: " + M_3 + "\n" +
            //                "K_4: " + K_4 + "\n" +
            //                "M_4: " + M_4 + "\n" +
            //                "K_5: " + K_5 + "\n" +
            //                "M_5: " + M_5 + "\n" +
            //                "K_6: " + K_6 + "\n" +
            //                "K_7: " + K_7 + "\n" +
            //                "M_7: " + M_7 + "\n" +
            //                "K_8: " + K_8 + "\n" +
            //                "M_8: " + M_8 + "\n" +
            //                "K_9: " + K_9 + "\n" +
            //                "M_9: " + M_9 + "\n" +
            //                FormCode.csoport + "\n" +
            //                FormCode.Name + "\n" +
            //                "K_10: " + K_10);


            if (adatchk == "0")
            {
                
                DialogResult ds4 = MessageBox.Show("Biztos, hogy el szeretnéd menteni az adatokat?\n\nTovábblépés esetén az elmentett adatokban már nem lehet módosítani!", "Figyelem!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ds4 == DialogResult.Yes)
                {
                    sharepointba_iras();    //MessageBox.Show("itt fut le a mentés....");

                    DialogResult ds3 = MessageBox.Show("Az adatok mentése sikeresen megtörtént!\n\nSzeretnél további munkavállalóra is adatot rögzíteni?", "Figyelem!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (ds3 == DialogResult.Yes)
                    {
                        formSAP = string.Concat(textBox1.Text, "_", formSAP);

                        if (formSAP.Substring(formSAP.Length-1, 1) == "_")
                        {
                            formSAP = formSAP.Substring(0, formSAP.Length-1);
                        }

                        textBox4.Text = string.Concat(textBox1.Text, ",", textBox4.Text);
                        comboBox2.SelectedIndex = -1;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        

                        if (comboBox1.Text.Contains("irendeltség") ||
                            comboBox1.Text.Contains("partner"))
                        {
                            comboBox2.DropDownStyle = ComboBoxStyle.DropDown;
                            textBox1.ReadOnly = false;
                            textBox2.ReadOnly = false;
                            comboBox2.Text = "";
                            textBox1.Text = "00000000";
                            textBox2.Text = "";
                        }

                        chkbox_letiltas();
                    }
                    else
                    {
                        formSAP = string.Concat(textBox1.Text, "_", formSAP);
                        if (formSAP.Substring(formSAP.Length-1, 1) == "_")
                        {
                            formSAP = formSAP.Substring(0, formSAP.Length - 1);
                        }

                        posta = comboBox1.Text;
                        Close();
                    }
                }
            }
        }


        private void sharepointba_iras()
        {

            teamweb2.Lists listService = new teamweb2.Lists();
            listService.Credentials = System.Net.CredentialCache.DefaultCredentials;
            listService.Url = "http://teamweb2/sites/TMEK/adatszolg/_vti_bin/Lists.asmx";
            System.Xml.XmlNode ndListView = listService.GetListAndView("MNB_Hianyos_bankjegyeo_adatai", "");
            string strListID = ndListView.ChildNodes[0].Attributes["Name"].Value;
            string strViewID = ndListView.ChildNodes[1].Attributes["Name"].Value;

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement batchElement = doc.CreateElement("Batch");
            batchElement.SetAttribute("OnError", "Continue");
            batchElement.SetAttribute("ListVersion", "1");
            batchElement.SetAttribute("ViewName", strViewID);

            string datum = dateTimePicker1.Text;

                batchElement.InnerXml = "<Method ID='4' Cmd='New'>" +
                    "<Field Name='Title'>" + comboBox1.Text + "</Field>" +
                    "<Field Name='Datum'>" + Convert.ToDateTime(dateTimePicker1.Text).ToShortDateString() + "</Field>" +
                    "<Field Name='Csoport'>" + FormCode.csoport + "</Field>" +
                    "<Field Name='SAP'>" + textBox1.Text + "</Field>" +
                    "<Field Name='K_1'>" + K_1 + "</Field>" +
                    "<Field Name='K_2'>" + K_2 + "</Field>" +
                    "<Field Name='K_3'>" + K_3 + "</Field>" +
                    "<Field Name='K_4'>" + K_4 + "</Field>" +
                    "<Field Name='K_5'>" + K_5 + "</Field>" +
                    "<Field Name='K_6'>" + K_6 + "</Field>" +
                    "<Field Name='K_7'>" + K_7 + "</Field>" +
                    "<Field Name='K_8'>" + K_8 + "</Field>" +
                    "<Field Name='K_9'>" + K_9 + "</Field>" +
                    "<Field Name='K_10'>" + K_10 + "</Field>" +
                    "<Field Name='M_1'>" + M_1 + "</Field>" +
                    "<Field Name='M_2'>" + M_2 + "</Field>" +
                    "<Field Name='M_3'>" + M_3 + "</Field>" +
                    "<Field Name='M_4'>" + M_4 + "</Field>" +
                    "<Field Name='M_5'>" + M_5 + "</Field>" +
                    "<Field Name='M_6'>" + M_6 + "</Field>" +
                    "<Field Name='M_7'>" + M_7 + "</Field>" +
                    "<Field Name='M_8'>" + M_8 + "</Field>" +
                    "<Field Name='M_9'>" + M_9 + "</Field>" +
                    "<Field Name='Verzio'>" + FormCode.verzio.ToString() + "</Field>" +
                    "<Field Name='M_10'>" + M_10 + "</Field></Method>";

                try
                {
                    
                    {
                        listService.UpdateListItems(strListID, batchElement);
                    }
                }

                catch
                {
                    //MessageBox.Show(e.ToString());
                    MessageBox.Show("Hiba az adatmentéskor!\n\nLépj kapcsolatba a feladat felelõsével! (Filó Norbert, Oroszné Ster Mária)");
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(FormCode.SAP.ToString());
        }

    }
}