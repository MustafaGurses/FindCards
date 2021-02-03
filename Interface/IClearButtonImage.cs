using Bul_Beni.Class;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bul_Beni.Interface
{
    internal interface IClearButtonImage
    {
        void Clear(List<Button> Buttons);
        bool Control(List<GeneratePath> generatePaths,Button Button_One, Button Button_Two);
    }
}
