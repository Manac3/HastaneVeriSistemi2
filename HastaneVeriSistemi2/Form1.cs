using System.Data;
using System.Xml;

namespace HastaneVeriSistemi2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Doldur();
            Getir();
        }

       

        public void Doldur()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("HastaneVeriSistemi.xml");
            try
            {
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            catch (IndexOutOfRangeException)
            {
                lbl_bildirim.Text = "XML Dosyasý boþ olduðundan gösterilecek veri bulunamadý.";
            }
        }

        public void Getir()
        {
            XmlReader xmlFile;
            xmlFile = XmlReader.Create("HastaneVeriSistemi.xml", new XmlReaderSettings());
            DataSet ds = new DataSet();
            DataView dv;
            ds.ReadXml(xmlFile);
            dv = new DataView(ds.Tables[0], "Unvan < =  " + txt_Unvan_filtre.Text + "", "", DataViewRowState.CurrentRows);
            dv.ToTable().WriteXml("Yeni.xml");

            dataGridView2.DataSource = dv.ToTable();
        }

       
    }
}