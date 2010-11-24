using System;
using System.Collections.Generic;
using System.Text;
using Paletizer.rs.esteh;

namespace Paletizer
{
    public class itemWrap
    {
        public wsItem item;

        public itemWrap(wsItem itm)
        {
            item = itm;
        }

        public override string ToString()
        {
            if (item.comment != null)
                return item.code + " " + item.comment.Trim().ToUpper() + " " + item.name;
            else
                return item.code + " " + item.name;
        }
    }
}
