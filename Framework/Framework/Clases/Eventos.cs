using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Framework
{

    public delegate void FormEditedEventHandler(object sender, EditedEventArgument e);

    public class EditedEventArgument : EventArgs
    {
        public bool formEdited { get; set; }
    }
}
