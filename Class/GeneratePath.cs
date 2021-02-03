using System.Drawing;
using System.Windows.Forms;

namespace Bul_Beni.Class
{
    public class GeneratePath
    {
        private string FilePath;
        private Button FileButton;
        public GeneratePath(string filePath, Button fileButton)
        {
            FilePath1 = filePath;
            FileButton1 = fileButton;
            //FileButton1.BackgroundImage = Image.FromFile(FilePath1);
        }

        public string FilePath1 { 
            get => FilePath;
            set => FilePath = value; 
        }
        public Button FileButton1 
        {
            get => FileButton;
            set => FileButton = value; 
        }
    }
}
