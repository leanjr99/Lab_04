using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_04
{
    public partial class lab04Form : Form
    {
        public lab04Form()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem.PerformClick();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textoRichTextBox.Rtf = string.Empty;
        }

        private void textoRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Definir a barra de titulos da OpenFileDialog
            openFileDialog1.Title = "Abrir arquivo";
            //Limpar o endereço que aparece por padrão
            openFileDialog1.FileName = "";
            //Inicializa sempre no disco especificado
            openFileDialog1.InitialDirectory = "C:\\";
            //Exibe apenas arquivos com extensão rtf
            openFileDialog1.Filter = "Arquivos RTF|*;rtf";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Define o objeto para leitura do arquivo
                System.IO.StreamReader leitor = new(openFileDialog1.FileName);
                //Descarrega o conteúdo no arquivo na richTextBox1
                textoRichTextBox.Rtf = leitor.ReadToEnd();
                //Fecha o objeto de leitura do arquivo
                leitor.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Definir a barra de títulos
            saveFileDialog1.Title = "Salvar";
            //Limpeza de endereço padrão
            saveFileDialog1.FileName = "";
            //Define pasta de abertura
            saveFileDialog1.InitialDirectory = "C:\\";
            //Permite apenas o salvamento em extensão especifica
            saveFileDialog1.Filter = "Arquivos RTF|*rtf";

            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                System.IO.StreamWriter sw = new(saveFileDialog1.FileName);
                sw.Write(textoRichTextBox.Rtf);
                sw.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(textoRichTextBox.SelectedRtf);
                textoRichTextBox.SelectedRtf = "";
            }
            catch (Exception)
            {

                MessageBox.Show("Selecione para recortar");
            }
            
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textoRichTextBox.SelectedRtf);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textoRichTextBox.SelectedRtf = Clipboard.GetText();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textoRichTextBox.SelectAll();
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                textoRichTextBox.SelectionFont = fontDialog1.Font;
            }
            
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                textoRichTextBox.SelectionColor = colorDialog1.Color;
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem.PerformClick();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.PerformClick();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem.PerformClick();

        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem.PerformClick();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem.PerformClick();
        }
    }
}
