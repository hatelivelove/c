using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string Buff { get; set; }
        public string BuffOper { get; set; }
        public bool Calculated = false;
        public string FixBuff;
        private string ExecuteOperation(string number)
        {
            switch (BuffOper)
            {
                case "+":
                    return (Convert.ToSingle(FixBuff) + Convert.ToSingle(number)).ToString();
                case "-":
                    return (Convert.ToSingle(FixBuff) - Convert.ToSingle(number)).ToString();

                default:
                    return null;
            }
            
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            if (BuffOper == null)
            {
                if (btn.Text =="," && labelResult.Text.Contains(",")) { return; }
                labelResult.Text += btn.Text;
                labelBuffer.Text = labelResult.Text;
            }
            else 
            {
                if (Calculated == false)
                {
                    if (Buff == null && btn.Text == ",") { Buff = "0,"; }
                    if (Buff != null && Buff.Contains(",") && btn.Text == ",") { return; }
                    
                    Buff += btn.Text;
                    
                    labelResult.Text += btn.Text;
                    labelBuffer.Text = ExecuteOperation(Buff);
                }
                else
                {

                    labelResult.Text = btn.Text;
                    labelBuffer.Text = btn.Text;
                    Calculated = false;
                    BuffOper = null;
                }
            }
        }
        private void buttonCalc_Click(object sender, EventArgs e) { 
        
            labelResult.Text = labelBuffer.Text;
            Calculated = true;
            Buff = null;
            FixBuff = null;
            
        }
        private void buttonOperation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "+/-")
            {
                if (Buff == null || FixBuff == null || labelResult.Text.Length < Buff.Length) { return; }
                int tmp = (Convert.ToSingle(Buff) > 0) ? 1 : 0;
                labelResult.Text = labelResult.Text.Remove(labelResult.Text.Length - Buff.Length - tmp);
                labelBuffer.Text = (Convert.ToSingle(FixBuff) - Convert.ToSingle(Buff)).ToString();
                if (Convert.ToSingle(Buff) <= 0)//разобраться с нулём
                {
                    Buff = (Convert.ToSingle(Buff) * (-1)).ToString();
                    labelResult.Text += "+" + Buff;
                }
                else if(tmp == 1)
                {
                    Buff = (Convert.ToSingle(Buff) * (-1)).ToString();
                    labelResult.Text += Buff;
                }
                else { return; }
                
            }
            else
            {
                labelResult.Text = labelResult.Text + btn.Text;
                Buff = null;
                Calculated = false;
                FixBuff = labelBuffer.Text;
                BuffOper = btn.Text;
            }
        }
        private void buttonFloat_Click(object sender, EventArgs e)
        {

        }

        
    }
}
