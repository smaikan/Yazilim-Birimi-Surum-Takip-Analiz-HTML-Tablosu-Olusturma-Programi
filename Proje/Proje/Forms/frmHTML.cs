using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proje.Forms
{
    public partial class frmHTML : Form
    {
        public Boolean all = true;
        string HTML;
        List<List<DataRow>> GroupList;
        DataTable dbdt;
        public frmHTML( ref DataTable dbdt)
        {
            InitializeComponent();
            this.dbdt = dbdt;
            int colCount = dbdt.Columns.Count;
            if (dbdt.Rows.Count > 0)
            {
               GroupList = new List<List<DataRow>>();
                GroupedCode(dbdt);
                HTMLCODE(GroupList);
            }
            else { }
            }

        void HTMLCODE(List<List<DataRow>> GroupList)
        {
            List<string> typelist = new List<string>();
            List<string> desclist = new List<string>();


            foreach (List<DataRow> version in GroupList)
            {
                string name;
                string head;
                string team = version[0]["teams"].ToString().ToLower();
                string date = Convert.ToDateTime(version[0]["updateTime"]).ToString("dd MMMM yyyy", new CultureInfo("tr-TR"));
                string v = version[0]["version"].ToString().ToLower();
                int isyeni = 0;
                int ishata = 0;

                switch (team)
                {
                    case "web":
                        name = "online";
                        head = "--WEB--";
                        break;

                    case "erp":
                        name = "erp";
                        head = "--ERP--";
                        break;

                    case "mobil":
                        name = "mobil";
                        head = "--MOBIL--";
                        break;

                    default:
                        name = "TANIMLANMAYAN EKİP İSMİ";
                        head = "--TANIMLANMAYAN EKİP--";
                        break;

                }

                HTML += $"\r\n{head}\r\n<table class='{name}-tablo-genel'>\r\n<tr>\r\n<td>";

                
                typelist.Clear();
                desclist.Clear();
                foreach (DataRow row in version)
                {
                    typelist.Add(row["type"].ToString().Trim());
                    desclist.Add(row["description"].ToString().Trim());
                }


                string text = "";
                var uniqueItems = typelist.Distinct().ToList();
                if (uniqueItems.Count == 1)
                {
                    if (typelist[0].ToString().ToLower() == "yeni")
                    {
                        text = "Yeni özellikler eklendi.";
                    }
                    else
                    {
                        text = "Hata düzeltmeleri yapıldı.";
                    }
                }
                else {
                    text = "Yeni özellikler eklendi, hata düzeltmeleri yapıldı.";
                }

                HTML += string.Format(@"
<table border=""0"" cellpadding=""0"" cellspacing=""0"">
 <tr>
  <td colspan=2 class=""{0}-versiyon-satir-1-hucre-1"">{1}</td>
   </tr>
   <tr class=""{0}-versiyon-satir-2"">
     <td class=""{0}-versiyon-satir-2-hucre-1"">{2}</td>
     <td class=""{0}-versiyon-satir-2-hucre-2"">{3}</td>
   </tr>
</table>
 <br />
", name, v, date, text);
                
                
                for (int i = 0; i < desclist.Count; i++)
                {
                    string description = desclist[i].ToString();
                    int satir = i + 1;
                    if (text != "Yeni özellikler eklendi, hata düzeltmeleri yapıldı.")
                    {
                        if (typelist[0].ToString().ToLower() == "yeni")
                        {
                            if (isyeni == 0)
                            {
                                HTML += $"<table border='0' cellpadding='0' cellspacing='0'>\r\n <tr>\r\n<td colspan=2 class='{name}-yenilikler-satir-1-hucre-1'>Yeni Özellikler</td>\r\n\t</tr>";
                            }
                            isyeni += 1;
                            HTML += string.Format(@"  
 <tr class='{0}-yenilikler-satir-2'>
   <td class='{0}-yenilikler-satir-2-hucre-1'>{1}</td>
   <td class='{0}-yenilikler-satir-2-hucre-2'>{2}</td>
  </tr>", name, isyeni, description);
                        }
                        else
                        {
                            if (ishata == 0)
                            {
                                HTML += $"<table border='0' cellpadding='0' cellspacing='0'>\r\n<tr>\r\n<td colspan=2 class='{name}-yenilikler-satir-1-hucre-1'>Hata Düzeltmeleri</td>\r\n\t</tr>";
                            }
                            ishata += 1;
                            HTML += string.Format(@"  
 <tr class='{0}-yenilikler-satir-2'>
   <td class='{0}-yenilikler-satir-2-hucre-1'>{1}</td>
   <td class='{0}-yenilikler-satir-2-hucre-2'>{2}</td>
  </tr>", name, ishata, description);
                        }
                    }
                    else
                    {

                        if (typelist[i].ToString().ToLower() == "yeni")
                        {
                            if (isyeni==0)
                            {
                                HTML += $"<table border='0' cellpadding='0' cellspacing='0'>\r\n <tr>\r\n<td colspan=2 class='{name}-yenilikler-satir-1-hucre-1'>Yeni Özellikler</td>\r\n\t</tr>";
                                                            
                            }
                            isyeni += 1;
                            HTML += string.Format(@"  
 <tr class='{0}-yenilikler-satir-2'>
   <td class='{0}-yenilikler-satir-2-hucre-1'>{1}</td>
   <td class='{0}-yenilikler-satir-2-hucre-2'>{2}</td>
  </tr>", name, isyeni, description);
                        }
                        if (typelist[i].ToString().ToLower() == "hata")
                        {
                            if (ishata == 0)
                            {
                                HTML += $"</table>\r\n<br/>\r\n<table border='0' cellpadding='0' cellspacing='0'>\r\n <tr>\r\n<td colspan=2 class='{name}-yenilikler-satir-1-hucre-1'>Hata Düzeltmeleri</td>\r\n\t</tr>";
                                
                            }
                            ishata += 1;
                            HTML += string.Format(@"  
 <tr class='{0}-yenilikler-satir-2'>
   <td class='{0}-yenilikler-satir-2-hucre-1'>{1}</td>
   <td class='{0}-yenilikler-satir-2-hucre-2'>{2}</td>
  </tr>", name, ishata, description);
                        }
                    }
                }
                HTML += "</table>\r\n </td>\r\n </tr>\r\n </table> \r\n\r\n<br/><br/><br/>";
                htmltext.Text += HTML;
                HTML = "";
            }

            htmltext.Multiline = true;
            htmltext.WordWrap = true;
            htmltext.ScrollBars = ScrollBars.Vertical;
            htmltext.Height = 800;
            htmltext.TabStop = false;

        }
        public void GroupedCode(DataTable dbdt)
        {
            var gruplar = dbdt.AsEnumerable()
                       .GroupBy(row => row.Field<string>("version"));
            foreach (var group in gruplar)
            {
                List<DataRow> grupListesi = group.ToList();
                GroupList.Add(grupListesi);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(htmltext.Text);


            MessageBox.Show("Metin panoya kopyalandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmHTML_Load(object sender, EventArgs e)
        {

        }

       

       
    }
}
