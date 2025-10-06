using System.IO;
using System.Xml.Linq;

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
                string filename = ofd.SafeFileName;
                string filepath = ofd.FileName;
                XDocument doc = XDocument.Load(filepath);

                //add a root
                TreeNode rootNode = new TreeNode(doc.Root?.Name.LocalName);
                elementsTreeView.Nodes.Add(rootNode);
                AddXmlNodes(doc.Root, rootNode);
                elementsTreeView.ExpandAll();

                int maxDepth = GetMaxDepth(doc.Root);
                int maxChildren = doc.Descendants().Select(x => x.Elements().Count()).DefaultIfEmpty(0).Max();
                int minAttrs = doc.Descendants().Select(x => x.Attributes().Count()).DefaultIfEmpty(0).Min();
                int maxAttrs = doc.Descendants().Select(x => x.Attributes().Count()).DefaultIfEmpty(0).Max();

                lblFilename.Text = $"Název souboru: {filename}";
                lblMaxDepth.Text = $"Maximální hloubka: {maxDepth}";
                lblChildren.Text = $"Maximální poèet pøímých potomkù: {maxChildren}";
                lblMinAttrs.Text = $"Minimální poèet atributù: {minAttrs}";
                lblMaxAttrs.Text = $"Maximální poèet atributù: {maxAttrs}";
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //save
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //close
            elementsTreeView.Nodes.Clear();
            lblFilename.Text = "";
            lblMaxDepth.Text = "";
            lblChildren.Text = "";
            lblMinAttrs.Text = "";
            lblMaxAttrs.Text = "";
        }

        private void AddXmlNodes(XElement element, TreeNode tn)
        {
            foreach (var child in element.Elements())
            {
                TreeNode childNode = new TreeNode(child.Name.LocalName);
                tn.Nodes.Add(childNode);
                AddXmlNodes(child, childNode);
            }
        }

        private int GetMaxDepth(XElement element)
        {
            if (!element.Elements().Any())
                return 1;
            return 1 + element.Elements().Max(e => GetMaxDepth(e));
        }

        private void lblMaxDepth_Click(object sender, EventArgs e)
        {

        }
    }
}
