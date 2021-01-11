using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoUI
{
    public static class UserProfile
    {
        public static User CurrentUser { get; set; }
        public static Form CurrentForm { get; set; }
        public static DataGridView CurrentDGV { get; set; }
        public static IconButton CurrentBtn { get; set; }
    }
}
