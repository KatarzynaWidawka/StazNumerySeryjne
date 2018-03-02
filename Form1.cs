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

namespace Projekt2
{
    public partial class Form1 : Form
    {

        vtkRenderer renderer, readerinscription;
        vtkRenderWindow renderWindow, renderWindowinscription;
        vtkRenderWindowInteractor interactor; //picking menager
        vtkPicker pick = vtkPicker.New();
        vtkPropPicker propPicker = vtkPropPicker.New();
        
        


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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            vtkTextActor3D text3d = vtkTextActor3D.New();
            string inscriptionpath = textBox1.Text;

            text3d.SetInput(inscriptionpath);
            text3d.GetTextProperty().SetColor(1.0, 0.0, 0.0);
            text3d.GetTextProperty().SetFontSize(10);
            text3d.GetTextProperty().SetVerticalJustification(5);

            readerinscription.AddActor(text3d);
            renderWindow.GetInteractor().Render();

            renderer.ResetCamera();
            renderWindow.GetInteractor().Render();

        }
        private void renderWindowControl1_Load(object sender, EventArgs e)
        {
            renderWindow = renderWindowControl1.RenderWindow;
            renderer = renderWindowControl1.RenderWindow.GetRenderers().GetFirstRenderer();
            renderWindowinscription = renderWindowControl1.RenderWindow;
            readerinscription = renderWindowControl1.RenderWindow.GetRenderers().GetFirstRenderer();

            //vtkSeedWidget seed= new vtkSeedWidget();
            //seed.SetRepresentation(seedReprezentation.GetPointer());
            //seed.SetInteractor(seed.GetPointer());
            //seed.EnabledOn();
            
            //napis 3D
            //nałożenie napisu na kość vtk CellPicker
            //wygenerowanie pdf 3D libharou 
            //Transformacja płaszczyzny jak dobrać równanie aby zmienić płaszczyznę na prostokątną z "rombowej "
            //Wpis na bloga 

            
        }

        
    

    }

       
}
