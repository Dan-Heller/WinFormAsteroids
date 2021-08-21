using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterfaceAsteroids
{
    public partial class StartWindow : Form
    {
        private Button start = new Button();
        

        public StartWindow()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            AcceptButton = start;
            start.Click += new EventHandler(EnterKeyPress);
        }

        

        private void EnterKeyPress(object sender, EventArgs e)
        {
           this.Close();
        }

        private void StartWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
