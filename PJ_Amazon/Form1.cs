using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJ_Amazon
{
    public partial class Form1 : Form
    {
        APD65_63011212019Entities1 context = new APD65_63011212019Entities1();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var result1 = menuBindingSource.DataSource = context.Menus.Where((m) => m.Type_Menu == 1).OrderBy(m => m.Menu_Name).ToList();
            dataGridView4.DataSource = result1;
            var result2 = menuBindingSource1.DataSource = context.Menus.Where((m) => m.Type_Menu == 2).OrderBy(m => m.Menu_Name).ToList();
            dataGridView5.DataSource = result2;
            var result3 = menuBindingSource2.DataSource = context.Menus.Where((m) => m.Type_Menu == 3).OrderBy(m => m.Menu_Name).ToList();
            dataGridView6.DataSource = result3;
            var result4 = billBindingSource.DataSource = context.Bills.OrderByDescending(m => m.Bill_Id).ToList();
            dataGridView2.DataSource = result4;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            bill.Oder_Date = DateTime.Now;
            bill.TotalAmount = int.Parse(label5.Text);
            context.Bills.Add(bill);

            int change = context.SaveChanges();

            if (change == 1)
            {
                foreach (ListViewItem item in listView2.Items)
                {
                    Bill_Item billitem = new Bill_Item();
                    billitem.Bill_Id = bill.Bill_Id;
                    billitem.Menu_Id = int.Parse(item.SubItems[2].Text);
                    billitem.Price = int.Parse(item.SubItems[1].Text);

                    context.Bill_Items.Add(billitem);
                    context.SaveChanges();
                }
                //MessageBox.Show(" เพิ่มข้อมูล " + change + " สำเร็จ");
            }
            listView2.Items.Clear();
            label5.Text = 0.ToString();

            var result4 = billBindingSource.DataSource = context.Bills.OrderByDescending(m => m.Bill_Id).ToList();
            dataGridView2.DataSource = result4;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            label5.Text = 0.ToString();
        }

        private int calculateTotal(ListView.ListViewItemCollection items)
        {
            int sum = 0;
            foreach (ListViewItem item in items)
            {
                sum += int.Parse(item.SubItems[1].Text);
            }
            return sum;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var strid = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();

            int id = int.Parse(strid);

            var bill_item = billItemBindingSource.DataSource = context.Bill_Items
                .Where((b) => b.Bill_Id == id)
                .Select((s) => new { s.Price, s.Menu.Menu_Name })
                .ToList();
            dataGridView1.DataSource = bill_item;

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var idstr = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
            var result = context.Menus.Where(p => p.Menu_Name == idstr).First();

            string[] item = new string[]
            {
                result.Menu_Name,
                result.Price.ToString(),
                result.Menu_Id.ToString(),
            };
            listView2.Items.Add(new ListViewItem(item));
            int sum = calculateTotal(listView2.Items);
            label5.Text = sum.ToString();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var idstr = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
            var result = context.Menus.Where(p => p.Menu_Name == idstr).First();

            string[] item = new string[]
            {
                result.Menu_Name,
                result.Price.ToString(),
                result.Menu_Id.ToString(),
            };

            listView2.Items.Add(new ListViewItem(item));
            int sum = calculateTotal(listView2.Items);
            label5.Text = sum.ToString();
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var idstr = dataGridView6.SelectedRows[0].Cells[0].Value.ToString();
    
            var result = context.Menus.Where(p => p.Menu_Name == idstr).First();

            string[] item = new string[]
            {
                result.Menu_Name,
                result.Price.ToString(),
                result.Menu_Id.ToString(),
            };

            listView2.Items.Add(new ListViewItem(item));
            int sum = calculateTotal(listView2.Items);
            label5.Text = sum.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
