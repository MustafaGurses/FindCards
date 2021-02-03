using GameObject;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bul_Beni.Class
{
    public class SetPath
    {
        List<Object> Objects;

        public SetPath()
        {
            Objects = new ObjectTransaction(Application.StartupPath).list();
            fileAndButton = new List<GeneratePath>();
        }
        List<GeneratePath> fileAndButton;
        public List<GeneratePath> Set(List<Button> buttons)
        {
            for(int i=0; i<buttons.Count; i++)
            {
                var btn = Application.OpenForms["frmGame"].Controls.Find(buttons[i].Name, true)[0] as Button;
                fileAndButton.Add(new GeneratePath(Objects[i].FileName1, btn));
            }
            return fileAndButton;
        }
    }
}
