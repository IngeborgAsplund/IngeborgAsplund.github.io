using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJackSimple
{
    public partial class SavedGames : Form
    {
        public SavedGames()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Property for old saves listbox this is filled by the gameboard acessing the saveandloadmanager
        /// </summary>
        public ListBox SavesList
        {
            get { return lstOldSaves; }
            set { lstOldSaves = value; }
        }
    }
}
