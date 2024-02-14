using System;
using System.Windows.Forms;

namespace WinFormLoginSample {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void menuExit_Click(object sender, EventArgs e) {
            MessageBox.Show("bye~");
            Close();
        }

        private void menuSample_Click(object sender, EventArgs e) {
            MessageBox.Show("sample!");
        }
    }
}
