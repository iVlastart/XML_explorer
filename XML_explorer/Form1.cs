namespace XML_explorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //open
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Open XML File",
                Filter = "XML Files (*.xml)|*.xml",
                DefaultExt = "xml",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                MessageBox.Show($"Selected file: {filePath}");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //save
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //close
        }
    }
}
