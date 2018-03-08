using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitware.VTK;
using System.Diagnostics;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Projekt2
{
    public partial class Form1 : Form
    {

        vtkRenderer renderer, readerinscription;
        vtkRenderWindow renderWindow, renderWindowinscription;
       
        public Form1() { InitializeComponent(); }

        private void button1_Click(object sender, EventArgs e)
        {
            vtkSTLReader reader = vtkSTLReader.New();
            string path = @"d:\Staz\projekt2\Projekt2\Projekt2\fibula.stl";
            reader.SetFileName(path);
            vtkPolyDataMapper Mapper = vtkPolyDataMapper.New();
            Mapper.SetInputConnection(reader.GetOutputPort());
            vtkActor Actor = vtkActor.New();
            Actor.SetMapper(Mapper);
            renderer.AddActor(Actor);
            reader.SetFileName(path);
            vtkPolyDataMapper Mapperinscription = vtkPolyDataMapper.New();
            Mapperinscription.SetInputConnection(reader.GetOutputPort());

            renderer.ResetCamera();
            renderWindow.GetInteractor().Render();

        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            string inscriptionpath = textBox1.Text;
            vtkVectorText text = vtkVectorText.New();
            text.SetText(inscriptionpath);
            //text.GetOutput().GetPoints().GetNumberOfPoints();

            //

            //vtkLinearExtrusionFilter extrude = vtkLinearExtrusionFilter.New();
            //extrude.SetInputConnection(text.GetOutputPort());
            //extrude.SetExtrusionTypeToNormalExtrusion();
            //extrude.SetVector(0, 0, 1);            
            //extrude.SetScaleFactor(0.5);

            //vtkTriangleFilter triangle = vtkTriangleFilter.New();
            //triangle.SetInputConnection(extrude.GetOutputPort());
            
            vtkDataSetMapper mapper = vtkDataSetMapper.New();
            mapper.SetInputConnection(text.GetOutputPort());
            
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);
            actor.GetProperty().SetColor(0.8900, 0.8100, 0.3400);
            actor.SetPosition(0, 0, 0);
            renderWindow.AddRenderer(renderer);
            renderer.AddActor(actor);
            renderer.ResetCamera();
            renderWindow.GetInteractor().Render();
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //string path= @"d:\Staz\projekt2\Projekt2\Projekt2\dokument.pdf";
            //FileStream fs = File.Create(path);
            //Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            //PdfWriter writer = PdfWriter.GetInstance(document, fs);
            //document.AddAuthor("KatarzynaWidawka");
            //document.Open();
            //document.Add(new Paragraph("Hello World!"));
            //document.Close();            
            //writer.Close();
            //fs.Close();

            //----------------------------------------------------------------

            vtkCylinderSource cylinder = vtkCylinderSource.New();
            cylinder.SetResolution(8);
            vtkPolyDataMapper cmapper = vtkPolyDataMapper.New();
            cmapper.SetInputConnection(cylinder.GetOutputPort());
            vtkActor cactor = vtkActor.New();
            cactor.SetMapper(cmapper);
            cactor.GetProperty().SetColor(1.0000, 0.3882, 0.2784);
            vtkSTLWriter stlwriter = vtkSTLWriter.New();
            stlwriter.SetFileName("object.stl");
            //stlwriter.Write();
            
            string path = @"d:\Staz\projekt2\Projekt2\Projekt2\dokument.pdf";
            FileStream fs = File.Create(path);
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.AddAuthor("KatarzynaWidawka");
            document.Open();
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(100, 400, 500, 800);
            document.Add(new Paragraph("Hello World!"));
           // document.Add(cactor);
            document.Close();
            writer.Close();
            fs.Close();  
   
        }
        private void renderWindowControl1_Load(object sender, EventArgs e)
        {




            renderWindow = renderWindowControl1.RenderWindow;
            renderer = renderWindowControl1.RenderWindow.GetRenderers().GetFirstRenderer();
            renderWindowinscription = renderWindowControl1.RenderWindow;
            readerinscription = renderWindowControl1.RenderWindow.GetRenderers().GetFirstRenderer();
                      

        }

      //actor 2d 
    

    }

 
}
