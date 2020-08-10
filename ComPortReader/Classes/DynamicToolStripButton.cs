using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace ComPortReader.Classes
{
    class DynamicToolStripButton
    {
        ToolStripDropDownButton dropDownBtn;
        ZedGraphControl zgc;
        LineItem curve;
        internal ToolStripMenuItem button;
        /// <summary>
        ///  Object for creating dynamicly the dropdownitem button with event to hide curves on ZedGraphControl.
        /// </summary>
        /// <param name="curve">curve that will be added to the memory and will be hidden or shown depending on the state of the button</param>
        /// <param name="zgc">graph to which curve is painted onto</param>
        /// <param name="dropDownBtn">the dropdown button that contains that button</param>
        internal DynamicToolStripButton(LineItem curve, ZedGraphControl zgc, ToolStripDropDownButton dropDownBtn)
        {
            
            this.dropDownBtn = dropDownBtn;
            this.zgc = zgc;
            this.curve = curve;
            button = (ToolStripMenuItem)dropDownBtn.DropDownItems.Add(curve.Label.Text, null, DynamicButton_Click);
            button.Checked = true;
        }
        private void DynamicButton_Click(object sender, EventArgs e)
        {
            if (!button.Checked)
            {
                zgc.GraphPane.CurveList.Add(curve);
                zgc.GraphPane.CurveList.Draw(zgc.CreateGraphics(), zgc.GraphPane, 1.0f);
            }
            else zgc.GraphPane.CurveList.Remove(curve);
            GraphProcessing.UpdateGraph(zgc);
            button.Checked = !button.Checked;
        }
    }
}
