using Microsoft.Office.InfoPath;
using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using mshtml;

namespace MNB
{
    public partial class FormCode
    {
        
        public void InternalStartup()
        {
            EventManager.FormEvents.Loading += new LoadingEventHandler(FormEvents_Loading);
            EventManager.XmlEvents["/my:sajátMezők/my:Alapadatok/my:Csoport"].Changed += new XmlChangedEventHandler(Csoport_Changed);
        }

        public static string Name;
        public static string csoport;
        public static string SAP;
        public static string posta;
        public static string verzio;

        public void FormEvents_Loading(object sender, LoadingEventArgs e)
        {
            //Form1 form1 = new Form1();
            //form1.ShowDialog();


            //this.Application.Quit();
            //DataConnections["Version"].Execute();

            //string validVerison = DataSources["Version"].CreateNavigator().SelectSingleNode("dataroot/Verzio/Bankjegy", NamespaceManager).Value;
            //string currentVersion = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Version", NamespaceManager).Value;
            
            ////if (Convert.ToInt32(validVerison.ToString().Substring(3, 1)) == Convert.ToInt32(currentVersion.ToString().Substring(3, 1)))
            
            //if (validVerison == currentVersion)
            //{
            //    MessageBox.Show("érvényes\nvalid: " + validVerison.ToString().Substring(3, 1) + "\n\ncurrent: " + currentVersion.ToString().Substring(3, 1));
            //}
            //else
            //{
            //    MessageBox.Show("nem érvényes\nvalid: " + validVerison.ToString().Substring(3, 1) + "\n\ncurrent: " + currentVersion.ToString().Substring(3, 1));
            //}
        }

        public void Csoport_Changed(object sender, XmlEventArgs e)
        {
            DataConnections["Version"].Execute();

            string validVerison = DataSources["Version"].CreateNavigator().SelectSingleNode("dataroot/Verzio/Bankjegy", NamespaceManager).Value;
            string currentVersion = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Version", NamespaceManager).Value;

            if (validVerison == currentVersion)
            {
                int szam = 1;

                Name = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Name", NamespaceManager).Value;
                csoport = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Csoport", NamespaceManager).Value;
                verzio = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Version", NamespaceManager).Value;

                if (szam == 1)
                {
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                }
                szam = 2;
                mentes();
            }
            else
            {
                DialogResult dr_csc = MessageBox.Show("Megjelent az űrlap legújabb verziója!\n\nAmíg a frissítést nem végzed el, addig az adatokat sem tudod rögzíteni!", "Verziófrissítés szükséges!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void mentes()
        {
            //try
            //{
            MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:SAP", NamespaceManager).SetValue(Form1.formSAP);
            MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Posta", NamespaceManager).SetValue(Form1.posta);

                FileSubmitConnection fc = DataConnections["UpLoad"] as FileSubmitConnection;    // adatok Sharepoint-ba küldéshez deklaráció
                fc.Execute();                                                                   // adatok Sharepoint-ba küldése
                
                DialogResult dr6 = MessageBox.Show("A mentés sikeresen megtörtént!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Information );
                //this.Application.Quit();
            //}
            //catch
            //{
             //   MessageBox.Show("Az iktatószám mentése sikertelen volt, ellenőrizd a hálózati kapcsolatod!", "Figyelem:");
           // }

         

            
        }
    }
}
