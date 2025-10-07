using System;
using System.IO;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Xml;
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
                try
                {
                    string filename = ofd.SafeFileName;
                    string filepath = ofd.FileName;
                    XDocument doc = XDocument.Load(filepath);
                    TreeNode rootNode = new TreeNode(doc.Root?.Name.LocalName);
                    rootNode.Tag = doc.Root;
                    elementsTreeView.Nodes.Add(rootNode);
                    AddXmlNodes(doc.Root, rootNode);
                    elementsTreeView.ExpandAll();
                    elementsTreeView.LabelEdit = true;

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
                catch(XmlException xmlEx)
                {
                    lblInfo.Text = "Soubor je prázdný";
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //save
            if (elementsTreeView.Nodes.Count == 0)
                return;

            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Uložit XML soubor",
                Filter = "XML Files (*.xml)|*.xml",
                DefaultExt = "xml"
            };

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TreeNode rootNode = elementsTreeView.Nodes[0];

                    if(rootNode.Tag is XElement rootElement)
                    {
                        XDocument newDoc = new XDocument(rootElement);
                        newDoc.Save(sfd.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba pøi ukládání {ex.Message}");
                }
            }
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
            lblInfo.Text = "";
        }

        private void AddXmlNodes(XElement element, TreeNode tn)
        {
            foreach (var child in element.Elements())
            {
                TreeNode childNode = new TreeNode(child.Name.LocalName);
                childNode.Tag = child;
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

        private void elementsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;

            TreeNode tn = e.Node;

            if (tn.Tag is XElement element)
            {
                int depth = GetDepth(element);
                int order = GetSiblingIndex(element);
                string attrs = string.Join(Environment.NewLine,
                    element.Attributes().Select(a => $"{a.Name}=\"{a.Value}\""));
                string txt = "";
                lblInfo.Text = $"Hloubka: {depth}\n" +
                         $"Poøadí mezi sourozenci: {order}\n" +
                         $"Atributy:\n{attrs}\n";
                if (!element.HasElements && !string.IsNullOrWhiteSpace(element.Value))
                {
                    txt = element.Value;
                    lblInfo.Text += $"Text: {txt}";
                }

            }
        }

        private int GetDepth(XElement element)
        {
            int depth = 1;
            XElement current = element;
            while (current.Parent != null)
            {
                depth++;
                current = current.Parent;
            }
            return depth;
        }

        private int GetSiblingIndex(XElement element)
        {
            if (element.Parent == null)
                return 1;

            var siblings = element.Parent.Elements().ToList();
            return siblings.IndexOf(element);
        }

        private void elementsTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null)
                return;

            if(e.Node?.Tag is XElement element)
            {
                XElement newElement = new XElement(e.Label, element.Attributes(), element.Nodes());
                element.ReplaceWith(newElement);
                e.Node.Tag = newElement;
            }
        }
    }
}
