using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace come334_hw
{
    // Aslıhan Erkan
    // 20180301032

    public partial class Form1 : Form
    {
        string root;
        List<Department> listOfDep = new List<Department>();
        List<ListViewItem> list1 = new List<ListViewItem>();
        Department Dep;
        Certificate Cerf;
        Employee pers;  
        ListViewItem tempItem;


        public Form1()
        {
            InitializeComponent();
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView node = sender as TreeView;
            textBox1.Text = node.SelectedNode.FullPath;
            textBox3.Text = node.SelectedNode.FullPath;
        }


        private void button1_Click(object sender, EventArgs e) //New button in department section
        {
            if (treeView1.SelectedNode.Tag.ToString() == "company")
            {
                textBox2.Clear();  
            }

            else
            {
                MessageBox.Show("You must select the company to add a new department.", "Warning!");
            }
                    
        }

        private void button2_Click(object sender, EventArgs e) //Edit department button
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {

                MessageBox.Show("You must select a department to edit.", "Warning!");

            }

            else
            {
                if (treeView1.SelectedNode.Tag.ToString() == "department")
                {
                    textBox2.Text = treeView1.SelectedNode.Text;
                }

                else
                {
                    MessageBox.Show("You must select a department to edit.", "Warning!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //Remove department button
        {
            if (treeView1.SelectedNode.Tag.ToString() == "department")
            {
                treeView1.SelectedNode.Remove();
            }

            else
            {
                MessageBox.Show("You must select a department to delete.", "Warning!");
            }
        }

        private void button4_Click(object sender, EventArgs e) //Save department button
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter a department name.", "Warning!");
            }
            else
            {
                if (treeView1.SelectedNode.Tag.ToString() == "company")
                {

                    treeView1.SelectedNode.Nodes.Add(textBox2.Text).Tag = "department";
                }

                else if (treeView1.SelectedNode.Tag.ToString() == "department")
                {
                    treeView1.SelectedNode.Name = textBox2.Text;
                    treeView1.SelectedNode.Text = textBox2.Text;

                }
                else
                {
                    MessageBox.Show("You can not add or edit personnel in this section.");
                }
            }

            treeView1.ExpandAll();
        }


        private void button5_Click(object sender, EventArgs e) //New button in personnel section
        {
            if (treeView1.SelectedNode.Tag.ToString() == "department")
            {
                textBox4.Clear();
                listView1.Items.Clear();
               
            }

            else
            {
                MessageBox.Show("You must select a department to add a new employee.", "Warning!");
            }
        }

        private void button6_Click(object sender, EventArgs e) //Edit employee button
        {
            if (treeView1.SelectedNode.Tag.ToString() != "employee")
            {
                MessageBox.Show("Please select an employee to edit.");
            }
            else
            {
                textBox4.Text = listOfDep[treeView1.SelectedNode.Parent.Index].departmentEmployeeList[treeView1.SelectedNode.Index].nameOfEmployee;
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {

                    if (comboBox1.Items[i].ToString() == listOfDep[treeView1.SelectedNode.Parent.Index].departmentEmployeeList[treeView1.SelectedNode.Index].favLang)
                    {
                        comboBox1.SelectedIndex = i;
                    }
                }
                ReListView();
            }
        }

        private void button7_Click(object sender, EventArgs e) //Remove employee button
        {
            if (treeView1.SelectedNode.Tag.ToString() == "employee")
            {
                treeView1.SelectedNode.Remove();
            }
            else
            {
                MessageBox.Show("You must select an employee to delete.", "Warning!");
            }
        }

        private void button8_Click(object sender, EventArgs e) //Add certificate button
        {
            if (treeView1.SelectedNode.Tag.ToString() != "employee")
            {
                MessageBox.Show("Please save the new employee first.");
            }
            else
            {
                if (string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Please select department or personel.");
                }

                else
                {
                    if (string.IsNullOrEmpty(textBox5.Text))
                    {
                        MessageBox.Show("Please enter a title.");
                    }
                    else
                    {
                        Cerf = new Certificate();
                        Cerf.title = textBox5.Text;
                        Cerf.year = comboBox2.Text.ToString();
                        listOfDep[treeView1.SelectedNode.Parent.Index].departmentEmployeeList[treeView1.SelectedNode.Index].certificatesOfEmployee.Add(Cerf);
                        ReListView();
                    }

                }
            }


        }

        private void button9_Click(object sender, EventArgs e) //Save personnel button
        {

           
                if (string.IsNullOrEmpty(textBox3.Text))
                {

                    MessageBox.Show("Please select a node.", "Warning!");

                }

                else if (treeView1.SelectedNode.Tag.ToString() == "employee")
                {
                    treeView1.SelectedNode.Name = textBox4.Text;
                    treeView1.SelectedNode.Text = textBox4.Text;

                }

                else if (treeView1.SelectedNode.Tag.ToString() == "department")
                {
                    if (string.IsNullOrEmpty(textBox4.Text))
                    {
                        MessageBox.Show("Please enter an employee name.", "Warning!");
                    }
                    else if (comboBox1.SelectedItem == null)
                    {
                        MessageBox.Show("Please select favorite language.", "Warning!");
                    }
                    else
                    {
                        AddEmployee(textBox4.Text, comboBox1.SelectedItem.ToString(), listOfDep[treeView1.SelectedNode.Index]);
                        treeView1.SelectedNode.Nodes.Add(textBox4.Text).Tag = "employee";
                    }

                
            }

            listView1.Items.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            root = "MZG A.Ş.";
            treeView1.Nodes.Add(root).Tag = "company";
            treeView1.Nodes[0].Nodes.Add("Yönetim").Tag = "department";
            treeView1.Nodes[0].Nodes[0].Nodes.Add("Zahid Gürbüz").Tag = "employee";
            treeView1.Nodes[0].Nodes.Add("Yazılım").Tag = "department";

            AddDepartment("Yönetim");
            AddEmployee("Zahid Gürbüz", "C#", listOfDep[0]);
            AddDepartment("Yazılım");

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            treeView1.ExpandAll();
        }

        private void AddDepartment(string dname)
        {
            Dep = new Department();
            Dep.nameOfDepartment = dname;
            listOfDep.Add(Dep);
        }
        private void AddEmployee (string name, string flang, Department dept)
        {
            pers = new Employee();
            pers.nameOfEmployee = name;
            pers.favLang = flang;
            dept.departmentEmployeeList.Add(pers);

        }

        private void ReListView()
        {

            list1.Clear();
            listView1.Items.Clear();

            for (int i = 0; i < listOfDep[treeView1.SelectedNode.Parent.Index].departmentEmployeeList[treeView1.SelectedNode.Index].certificatesOfEmployee.Count; i++)
            {
                tempItem = new ListViewItem(listOfDep[treeView1.SelectedNode.Parent.Index].departmentEmployeeList[treeView1.SelectedNode.Index].certificatesOfEmployee[i].title);
                tempItem.SubItems.Add(listOfDep[treeView1.SelectedNode.Parent.Index].departmentEmployeeList[treeView1.SelectedNode.Index].certificatesOfEmployee[i].year);
                tempItem.SubItems.Add("Delete / Sil");
                list1.Add(tempItem);

            }
            listView1.Items.AddRange(list1.ToArray());
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
