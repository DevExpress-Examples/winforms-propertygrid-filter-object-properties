using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraVerticalGrid.Events;

namespace PropertyFiltering {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.propertyGridControl1.SelectedObject = this.propertyGridControl1;
            this.propertyGridControl1.GetRowByFieldName("Size").Expanded = true;
            this.propertyGridControl1.GetRowByFieldName("Location").Expanded = true;
        }

        void propertyGridControl1_CustomPropertyDescriptors(object sender, CustomPropertyDescriptorsEventArgs e) {
            // Provide properties to be displayed at the root level
            if(e.Context.PropertyDescriptor == null) {
                PropertyDescriptorCollection filteredCollection = new PropertyDescriptorCollection(null);
                AddIfPropertyExist(e.Properties, filteredCollection, "Dock");
                AddIfPropertyExist(e.Properties, filteredCollection, "Size");
                AddIfPropertyExist(e.Properties, filteredCollection, "Location");
                AddIfPropertyExist(e.Properties, filteredCollection, "NonexistentProperty");
                e.Properties = filteredCollection;
            }
            //Provide nested properties for the Size property
            if(e.Context.PropertyDescriptor != null && e.Context.PropertyDescriptor.Name == "Size") {
                PropertyDescriptorCollection filteredCollection = new PropertyDescriptorCollection(null);
                AddIfPropertyExist(e.Properties, filteredCollection, "Height");
                e.Properties = filteredCollection;
            }
        }
        void AddIfPropertyExist(PropertyDescriptorCollection sourceCollection, PropertyDescriptorCollection targetCollection, string name) {
            PropertyDescriptor foundPropertyDescriptor = sourceCollection[name];
            if(foundPropertyDescriptor == null)
                return;
            targetCollection.Add(foundPropertyDescriptor);
        }
    }
}
