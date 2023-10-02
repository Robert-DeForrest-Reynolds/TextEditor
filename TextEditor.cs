using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class TextEditor : Form
    {
        public string[] ContentNames;
        public string DirectoryPath;
        public string UserFolder;
        public bool UserFolderExists;

        public TextEditor()
        {
            UserFolder = "UserFolder";
            UserFolderExists = Directory.Exists(UserFolder);

            if (!UserFolderExists)
            {
                Directory.CreateDirectory(UserFolder);
            }

            InitializeComponent();
        }

        public void Load_Directory_Items(string DirectoryPath)
        {
            ContentNames = Directory.GetFiles(DirectoryPath);

            foreach (string Content in ContentNames)
            {
                DirectoryListing.Items.Add(Path.GetFileName(Content));
            }
        }

        public void Load_User_Items()
        {
            string[] UserContent = Directory.GetFiles(UserFolder);
        }

        private void OpenDirectory(object sender, System.EventArgs e)
        {
            using (FolderBrowserDialog OpenFolder = new FolderBrowserDialog())
            {
                if (OpenFolder.ShowDialog() == DialogResult.OK)
                {
                    DirectoryPath = OpenFolder.SelectedPath;
                }
                else
                {
                    DirectoryPath = string.Empty;
                }
            }

            Load_Directory_Items(DirectoryPath);


        }
    }
}
