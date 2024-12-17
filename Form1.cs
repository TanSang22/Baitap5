using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitap5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
         
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        
    }

       

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            if (richTextBox1.SelectionFont != null)
            {
                string fontName = toolStripComboBox1.SelectedItem.ToString();
                Font currentFont = richTextBox1.SelectionFont;
                richTextBox1.SelectionFont = new Font(fontName, currentFont.Size, currentFont.Style);
            }
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                int fontSize = int.Parse(toolStripComboBox2.SelectedItem.ToString());
                Font currentFont = richTextBox1.SelectionFont;
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, fontSize, currentFont.Style);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
                ApplyFontStyle(FontStyle.Bold);
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ApplyFontStyle(FontStyle.Italic);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ApplyFontStyle(FontStyle.Underline);

        }
        private void ApplyFontStyle(FontStyle style)
        {
            if (richTextBox1.SelectionFont != null)
            {
                
                Font currentFont = richTextBox1.SelectionFont;

               
                FontStyle newFontStyle = currentFont.Style;

                if (currentFont.Style.HasFlag(style))
                {
                   
                    newFontStyle &= ~style;
                }
                else
                {
                    
                    newFontStyle |= style;
                }

                
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
       "Bạn có chắc chắn muốn tạo một trang mới? Nội dung hiện tại sẽ bị mất nếu chưa lưu.",
       "Xác nhận",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Warning
   );

            if (result == DialogResult.Yes)
            {
                
                richTextBox1.Clear();

                
                richTextBox1.Font = new Font("Tahoma", 14, FontStyle.Regular);

                MessageBox.Show("Đã tạo trang mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf",
                Title = "Save File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 1) 
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                }
                else if (saveFileDialog.FilterIndex == 2) 
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                }

                MessageBox.Show("File đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void taoVanBanMoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
       "Bạn có chắc chắn muốn tạo một trang mới? Nội dung hiện tại sẽ bị mất nếu chưa lưu.",
       "Xác nhận",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Warning
   );

            if (result == DialogResult.Yes)
            {
               
                richTextBox1.Clear();

                
                richTextBox1.Font = new Font("Tahoma", 14, FontStyle.Regular);

                MessageBox.Show("Đã tạo trang mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void moTapTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf",
                Title = "Open File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
             
                if (openFileDialog.FilterIndex == 1) 
                {
                    richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
                }
                else if (openFileDialog.FilterIndex == 2) 
                {
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                }

                MessageBox.Show("File đã được mở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void luuNoiDungVanBangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf",
                Title = "Save File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 1) 
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                }
                else if (saveFileDialog.FilterIndex == 2) 
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                }

                MessageBox.Show("File đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đóng trang? Nội dung hiện tại sẽ bị mất nếu chưa lưu.",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                this.Close(); 
            }

        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đóng trang? Nội dung hiện tại sẽ bị mất nếu chưa lưu.",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true; 
            }
            
        }

    }
}
