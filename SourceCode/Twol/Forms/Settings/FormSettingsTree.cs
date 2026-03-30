using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace Twol
{
    public partial class FormSettingsTree : Form
    {
        private readonly FormGPS mf = null;
        private string userFilePath;

        public FormSettingsTree(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void FormSettingsTree_Load(object sender, EventArgs e)
        {
            userFilePath = Path.Combine(RegistrySettings.baseDirectory, "User.XML");
            LoadTreeFromXml(treeViewUser);
            userFilePath = Path.Combine(RegistrySettings.baseDirectory, "Vehicles", RegistrySettings.vehicleFileName + ".XML");
            LoadTreeFromXml(treeViewVehicle);
            userFilePath = Path.Combine(RegistrySettings.baseDirectory, "Tools", RegistrySettings.toolFileName + ".XML");
            LoadTreeFromXml(treeViewTool);
        }

        private void LoadTreeFromXml(TreeView targetTreeView)
        {
            targetTreeView.BeginUpdate();
            targetTreeView.Nodes.Clear();

            if (!File.Exists(userFilePath))
            {
                targetTreeView.Nodes.Add(new TreeNode("User.XML not found"));
                targetTreeView.EndUpdate();
                return;
            }

            try
            {
                var document = XDocument.Load(userFilePath);
                if (document.Root != null)
                {
                    targetTreeView.Nodes.Add(CreateNode(document.Root));
                    targetTreeView.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                var errorNode = new TreeNode("Error loading XML");
                errorNode.Nodes.Add(new TreeNode(ex.Message));
                targetTreeView.Nodes.Add(errorNode);
            }
            finally
            {
                targetTreeView.EndUpdate();
            }
        }

        private static TreeNode CreateNode(XElement element)
        {
            var node = new TreeNode(BuildNodeLabel(element));

            foreach (var child in element.Elements())
            {
                if (IsValueChildOfSetting(element, child))
                {
                    continue;
                }

                node.Nodes.Add(CreateNode(child));
            }

            return node;
        }

        private static string BuildNodeLabel(XElement element)
        {
            var displayName = element.Attribute("name")?.Value ?? element.Name.LocalName;
            var valueText = element.HasElements ? ExtractValueFromChildren(element) : element.Value.Trim();

            return string.IsNullOrEmpty(valueText)
                ? displayName
                : $"{displayName}: {valueText}";
        }

        private static string ExtractValueFromChildren(XElement element)
        {
            var valueElement = element.Elements()
                .FirstOrDefault(e => e.Name.LocalName.Equals("value", StringComparison.OrdinalIgnoreCase) && !e.HasElements);

            return valueElement?.Value.Trim() ?? string.Empty;
        }

        private static bool IsValueChildOfSetting(XElement parent, XElement child)
        {
            return parent.Name.LocalName.Equals("setting", StringComparison.OrdinalIgnoreCase)
                && child.Name.LocalName.Equals("value", StringComparison.OrdinalIgnoreCase)
                && !child.HasElements;
        }
    }
}