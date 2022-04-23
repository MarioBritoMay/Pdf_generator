using System;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;



namespace Pdf_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //añadimos las columnas del datagridview
            dgvProductos.Columns.Add("cantidad", "cantidad");
            dgvProductos.Columns.Add("Descripción", "Descripción");
            dgvProductos.Columns.Add("Precio unitario", "precio unitario");
            dgvProductos.Columns.Add("importe", "importe");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int indice_fila = dgvProductos.Rows.Add();
            DataGridViewRow fila = dgvProductos.Rows[indice_fila];//Añadimos una fila
            // Le asignamos valores a las celdas agarrandolos de los textbox
            fila.Cells["cantidad"].Value = txtCantidad.Text;
            fila.Cells["Descripción"].Value = txtDescripción.Text;
            fila.Cells["Precio unitario"].Value = txtPrecio.Text;
            fila.Cells["importe"].Value = decimal.Parse(txtCantidad.Text) * decimal.Parse(txtPrecio.Text);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            //le damos nombre al documento y en el añadimos el tipo de documento añadiendole la extension .pdf
            saveFile.FileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf";

            String HtmlPage_content = "<Table border=1><tr><td> Hola mundo </td></tr></table>"; // contenido del PDF

            if (saveFile.ShowDialog() == DialogResult.OK) // mostrar ventana de dialogo si la respuesta es correcta
            {
                using (FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))// crea el archivo de memoria
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25); //da las caracteristicas al documento
                    PdfWriter writter = PdfWriter.GetInstance(pdfDoc, stream);     // nos va permitir escribir el contenido        
                    pdfDoc.Open();// abrimos el documento
                    pdfDoc.Add(new Phrase(""));// añadimos el contenido

                    using (StringReader sr = new StringReader(HtmlPage_content))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writter, pdfDoc, sr);
                    }

                    pdfDoc.Close();// cerramos documento
                    stream.Close();// cerramos espacio de memoria
                }
            }
        }
      

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        
    }
}