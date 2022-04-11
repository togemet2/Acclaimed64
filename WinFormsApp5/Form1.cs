using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Filter = "N64 ROM(*.z64;*.v64;*.n64;*.rom;*.bin)|*.z64;*.v64;*.n64;*.rom;*.bin|All files (*.*)|*.*";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string romh = openFileDialog1.FileName;
                    byte[] b = File.ReadAllBytes(romh);

                // Big Endian (.z64)
                if (b[0] == 0x80 && b[1] == 0x37 && b[2] == 0x12)
                {
                    BinaryWriter bwr = new BinaryWriter(File.OpenWrite(openFileDialog1.FileName));
                    int x = 0x3e;
                    {
                        bwr.BaseStream.Position = x;
                        bwr.Write((byte)0x50);
                    }
                    bwr.Close();
                }
                // Little Endian (.n64)
                if (b[0] == 0x40 && b[1] == 0x12 && b[2] == 0x37)
                {
                    BinaryWriter bwr = new BinaryWriter(File.OpenWrite(openFileDialog1.FileName));
                    int x = 0x3d;
                    {
                        bwr.BaseStream.Position = x;
                        bwr.Write((byte)0x50);
                    }
                    bwr.Close();
                }
                // Byte Swapped (.v64)
                else if (b[0] == 0x37 && b[1] == 0x80 && b[2] == 0x40)
                {
                    BinaryWriter bwr = new BinaryWriter(File.OpenWrite(openFileDialog1.FileName));
                    int x = 0x3f;
                    {
                        bwr.BaseStream.Position = x;
                        bwr.Write((byte)0x50);
                    }
                    bwr.Close();
                }
                // ABC Header, Big Endian (.z64) ; used in games such as Turok3
                if (b[59] == 0x41 && b[60] == 0x42 && b[61] == 0x43)
                {
                    BinaryWriter bwr = new BinaryWriter(File.OpenWrite(openFileDialog1.FileName));
                    int x = 0x3e;
                    {
                        bwr.BaseStream.Position = x;
                        bwr.Write((byte)0x4a);
                    }
                    bwr.Close();
                }
                // ABC Header, Little Endian (.n64) ; used in games such as Turok3
                if (b[62] == 0x43 && b[63] == 0x42)
                {
                    BinaryWriter bwr = new BinaryWriter(File.OpenWrite(openFileDialog1.FileName));
                    int x = 0x3d;
                    {
                        bwr.BaseStream.Position = x;
                        bwr.Write((byte)0x4a);
                    }
                    bwr.Close();
                }
                // ABC Header, Byte Swapped (.v64) ; used in games such as Turok3
                if (b[60] == 0x43 && b[61] == 0x42)
                {
                    BinaryWriter bwr = new BinaryWriter(File.OpenWrite(openFileDialog1.FileName));
                    int x = 0x3f;
                    {
                        bwr.BaseStream.Position = x;
                        bwr.Write((byte)0x4a);
                    }
                    bwr.Close();
                }
            }
        }
    }
}