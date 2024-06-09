using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_layer.Utilities
{
    public static class clsPublicUtilities
    {
        public static void ErrorMessage(string  message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
        }

        public static void WarningMessage(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        public static void InformationMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }


        public static DirectoryInfo GetParentDirectory()
        {
            string currentDirectory = Environment.CurrentDirectory.ToString();
            var parentPath = Directory.GetParent(currentDirectory);
            parentPath = Directory.GetParent(parentPath.ToString()); // now the parent path in DVLD_Presentation_layer
            return parentPath;
        }
    }
}
