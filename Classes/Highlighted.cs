using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

namespace Rush_Hour
{
    public abstract class Highlighted
    {
        protected bool IsHighlighted;

        abstract public void MouseOn();
        abstract public void MouseOff();
        abstract public void MouseClick();
        abstract public bool Contains(GeometryModel3D Model);
    }
}
