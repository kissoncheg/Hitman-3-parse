using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using CsvHelper;
using CsvHelper.Configuration;
using Hitman_3_parse.Model;

namespace Hitman_3_parse
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        List<Item> list = new List<Item>();
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt|*.txt";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            list.Clear();
            try
            {
                using (var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var sr = new StreamReader(fs, Encoding.Default))
                    {

                        string str = sr.ReadLine();
                        long id = 0;
                        while (str != null)
                        {
                            var item = new Item();
                            item.Parse(str, ref id);
                            str = sr.ReadLine();
                            list.Add(item);
                        }


                    }
                }

                using (var fs = new FileStream(Application.StartupPath + "\\tmp.bin", FileMode.Create, FileAccess.ReadWrite))
                {
                    var xsr = new BinaryFormatter();
                    xsr.Serialize(fs, list);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка записи: " + exception.Message, "Внимание!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
            dataGridView1.Rows.Clear();
           

            foreach (var pair in list.SelectMany(item => item.SubStrings))
            {
                dataGridView1.Rows.Add(pair.Key, pair.Value.English, pair.Value.Russian);
            }
        }

        private void экспортCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Count == 0)
            {
                MessageBox.Show("Загрузить файл перевода", "Вниание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv|*.csv";
            if(sfd.ShowDialog()!=DialogResult.OK) return;
            //try
            //{
            //    using (var fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.ReadWrite))
            //    {
            //        using (var sw = new StreamWriter(fs, Encoding.Default))
            //        {
            //            sw.WriteLine("Id;English;Russian");
            //            foreach (var pair in list.SelectMany(item => item.SubStrings))
            //            {
            //                sw.WriteLine($"{pair.Key};{pair.Value.English};{pair.Value.Russian}");
            //            }
            //        }
            //    }
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show("Ошибка: " + exception.Message, "Внимание!", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //}
            using (var fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
            using (var reader = new StreamWriter(fs,Encoding.Default))
            using (var csv = new CsvWriter(reader, CultureInfo.CurrentCulture))
            {
                
                //csv.Configuration.Delimiter = ";";
                csv.WriteRecords(list.SelectMany(item => item.SubStrings).Select(pair => new ItemCsv { Id = pair.Key, English = pair.Value.English, Russian = pair.Value.Russian }));
            }

            MessageBox.Show("Экспорт завершен");
        }

        private void импортCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv|*.csv";
            if(ofd.ShowDialog() != DialogResult.OK) return;
            using (var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(fs,Encoding.Default))
            using (var csv = new CsvReader(reader,CultureInfo.CurrentCulture))
            {
                
                //csv.Configuration.Delimiter = ";";
                var itemcsv_ = new ItemCsv();
                List<ItemCsv> listItemParse = new List<ItemCsv>();
                var records = csv.EnumerateRecords(itemcsv_);
                foreach (ItemCsv itemCsv in records)
                {
                    if(string.IsNullOrEmpty(itemCsv.Russian)) continue;
                    //listItemParse.Add(new ItemCsv{Id = itemCsv.Id,English = itemCsv.English,Russian = itemCsv.Russian});
                    var item = list.FirstOrDefault(x => x.SubStrings.Any(y => y.Key == itemCsv.Id));
                    if (item != null)
                    {
                        item.SubStrings[itemCsv.Id].Russian = itemCsv.Russian;
                    }
                }
                
            }
            using (var fs = new FileStream(Application.StartupPath + "\\tmp.bin", FileMode.Create, FileAccess.ReadWrite))
            {
                var xsr = new BinaryFormatter();
                xsr.Serialize(fs, list);
            }
            dataGridView1.Rows.Clear();
            foreach (var pair in list.SelectMany(item => item.SubStrings))
            {
                dataGridView1.Rows.Add(pair.Key, pair.Value.English, pair.Value.Russian);
            }

        }

        private void экспортTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt|*.txt";
            if(sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                using (var fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                using (var sw = new StreamWriter(fs, Encoding.Default))
                {
                    foreach (Item item in list)
                    {
                        sw.WriteLine(item.GetString());
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка записи: " + exception.Message, "Внимание!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\tmp.bin"))
            {
                try
                {
                    using (var fs = new FileStream(Application.StartupPath + "\\tmp.bin", FileMode.Open, FileAccess.Read))
                    {
                        var xsr = new BinaryFormatter();
                        list = (List<Item>)xsr.Deserialize(fs);
                        dataGridView1.Rows.Clear();
                        foreach (var pair in list.SelectMany(item => item.SubStrings))
                        {
                            dataGridView1.Rows.Add(pair.Key, pair.Value.English, pair.Value.Russian);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Ошибка загрузки файла: " + exception.Message, "Внимание!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                
            }
        }
    }
}
