
using Bul_Beni.Class;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bul_Beni.Interface
{
    public class ClearButton : IClearButtonImage
    {
        public Image Default_Image = Image.FromFile(Application.StartupPath+@"\resim\default.fw.png");
        public void Clear(List<Button> buttons)
        {
            for(int i=0; i<buttons.Count; i++)
            {
                var btn = Application.OpenForms["frmGame"].Controls.Find(buttons[i].Name, true)[0] as Button;
                btn.BackgroundImage = Default_Image;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        public bool Control(List<GeneratePath> generatePaths,Button Button_One, Button Button_Two)
        {
            var select_one_path = generatePaths.Where(x => x.FileButton1 == Button_One).Select(x => x.FilePath1).FirstOrDefault();
            var select_two_path = generatePaths.Where(x => x.FileButton1 == Button_Two).Select(x => x.FilePath1).FirstOrDefault();
            if (select_one_path == select_two_path)
                return true;
            else
                return false;
        }
    }
}
