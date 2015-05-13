using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayerArchitectureApp.BLL;
using LayerArchitectureApp.MODEL;

namespace LayerArchitectureApp
{
    public partial class LayerArchitectureUI : Form
    {
        public LayerArchitectureUI()
        {
            InitializeComponent();
        }

        PersonManager aManager = new PersonManager();
        private int id = 0;
        private void saveButton_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (nameTextBox.Text != string.Empty &&  ageTextBox.Text != string.Empty)
            {
                PersonClass aPerson = new PersonClass();
                string name = nameTextBox.Text;
                string age = ageTextBox.Text;
                aPerson.name = name;
                aPerson.age = age;
                msg = aManager.InsertIntoManager(aPerson);
                ShowAllPerson();
                MessageBox.Show(msg);
                
            }

        }

        private void LayerArchitectureAPP_Load(object sender, EventArgs e)
        {
            ShowAllPerson();
        }

        List<PersonClass>  personList = new List<PersonClass>();
        public void ShowAllPerson()
        {
            personListView.Items.Clear();
            personList.Clear();
            personList = aManager.GetAllPerson();

            foreach (var aPerson in personList)
            {
                ListViewItem item = new ListViewItem(aPerson.Id.ToString());
                item.SubItems.Add(aPerson.name);
                item.SubItems.Add(aPerson.age);

                personListView.Items.Add(item);
            }
        }

        private void personListView_DoubleClick(object sender, EventArgs e)
        {
            if (personListView.SelectedItems.Count>0)
            {
                ListViewItem firstListViewItem = personListView.SelectedItems[0];
                int personId = int.Parse(firstListViewItem.Text);
                PersonClass aPerson = aManager.GetPersonByID(personId);
                nameTextBox.Text = aPerson.name;
                ageTextBox.Text = aPerson.age;
                this.id = aPerson.Id;
            }
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string msg = "";
            PersonClass aPerson = new PersonClass();
            aPerson.name = nameTextBox.Text;
            aPerson.age = ageTextBox.Text;
            aPerson.Id = id;
            msg = aManager.Update(aPerson);
            ShowAllPerson();
            MessageBox.Show(msg);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string msg = "";
            PersonClass aPerson = new PersonClass();
            aPerson.name = nameTextBox.Text;
            aPerson.age = ageTextBox.Text;
            aPerson.Id = id;
            msg = aManager.Delete(aPerson);
            ShowAllPerson();
            MessageBox.Show(msg);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            personListView.Items.Clear();
            int count = 0;
            string name = searchTextBox.Text;

            foreach (PersonClass aPerson in personList)
            {
                if (aPerson.name.ToLower().Contains(name.ToLower()))
                {
                    ListViewItem item = new ListViewItem(aPerson.Id.ToString());
                    item.SubItems.Add(aPerson.name);
                    item.SubItems.Add(aPerson.age);

                    personListView.Items.Add(item);
                    count++;
                }
            }

            if (count == 0 )
            {
                MessageBox.Show("Not Found");
            }
        }
    }
}
