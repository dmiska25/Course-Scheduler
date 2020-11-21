using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class_Scheduler.Objects;

namespace Class_Scheduler.Forms.MiscellaneousForms
{
    public partial class PriorityViewer<T> : Form
    {
        //variables
        private List<T> _nonPrioritizedItems;
        private List<T> _priorityList;

        //field
        public List<T> PriorityList { get { return new List<T>(_priorityList); } }


        public PriorityViewer(IEnumerable<T> items, List<T> prioritizedItems)
        {
            InitializeComponent();
            updateLists(items, prioritizedItems);
        }

        private void PriorityViewer_Load(object sender, EventArgs e)
        {

        }

        private void moveRightButton_Click(object sender, EventArgs e)
        {
            int index;
            if (itemList1.SelectedIndex != -1)
                index = itemList1.SelectedIndex;
            else
                return;
            itemList2.Items.Add(itemList1.Items[index]);
            itemList1.Items.RemoveAt(index);
            _priorityList.Add(_nonPrioritizedItems[index]);
            _nonPrioritizedItems.RemoveAt(index);
        }

        private void moveLeftButton_Click(object sender, EventArgs e)
        {
            int index;
            if (itemList2.SelectedIndex != -1)
                index = itemList2.SelectedIndex;
            else
                return;
            itemList1.Items.Add(itemList2.Items[index]);
            itemList2.Items.RemoveAt(index);
            _nonPrioritizedItems.Add(_priorityList[index]);
            _priorityList.RemoveAt(index);
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            int index;
            if (itemList2.SelectedIndex == -1 ||
                itemList2.SelectedIndex == 0)
                return;
            index = itemList2.SelectedIndex;

            var itemName = itemList2.Items[index-1];
            itemList2.Items[index - 1] = itemList2.Items[index];
            itemList2.Items[index] = itemName;

            var item = _priorityList[index - 1];
            _priorityList[index - 1] = _priorityList[index];
            _priorityList[index] = item;
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            int index;
            if (itemList2.SelectedIndex == -1 ||
                itemList2.SelectedIndex == itemList2.Items.Count - 1)
                return;
            index = itemList2.SelectedIndex;

            var itemName = itemList2.Items[index];
            itemList2.Items[index] = itemList2.Items[index + 1];
            itemList2.Items[index + 1] = itemName;

            var item = _priorityList[index];
            _priorityList[index] = _priorityList[index + 1];
            _priorityList[index + 1] = item;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //helper methods
        public void updateLists(IEnumerable<T> items, List<T> prioritizedItems)
        {
            //verify consistency ie. ensure prioritizedItems is a subset of items
            if (!prioritizedItems.All(i => items.Contains(i)))
                throw new Exception("Prioritized Items list is not consistent with items List!");

            //create nonPrioritizedItems array and copy the priorityList over
            _nonPrioritizedItems = new List<T>(items);
            _nonPrioritizedItems.RemoveAll(i => prioritizedItems.Contains(i));

            _priorityList = prioritizedItems;

            itemList1.Items.Clear();
            foreach(var item in _nonPrioritizedItems)
            {
                itemList1.Items.Add(item.ToString());
            }

            itemList2.Items.Clear();
            foreach(var item in _priorityList)
            {
                itemList2.Items.Add(item.ToString());
            }
        }


    }
}
