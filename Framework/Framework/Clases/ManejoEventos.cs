using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Framework
{
    public class ManejoEventos
    {
        public event FormEditedEventHandler FormEditedEvent;

        public ManejoEventos()
        {
            
        }


        public void FireEventFormEdited(bool pEditedParam)
        {
            EditedEventArgument e = new EditedEventArgument();
            e.formEdited = pEditedParam;
            if (FormEditedEvent != null)
            {
                FormEditedEvent(this, e);
            }
            e = null;
        }


    }
}
