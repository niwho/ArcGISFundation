using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geometry;

namespace ArcGISFoundation
{
    public partial class CreateShpFileForm : Form
    {
        private DataGridView excelDataGridViewX;
        private AxMapControl axMapControl;
        private string fileName;
        private string filePath;

        public CreateShpFileForm(AxMapControl _axMapControl, DataGridView _DataView)
        {
            axMapControl = _axMapControl;
            excelDataGridViewX = _DataView;
            InitializeComponent();
        }

        private void delFieldButtonX_Click(object sender, EventArgs e)
        {
            if (addFieldListBox.SelectedItem != null)
            {
                fieldListBox.Items.Add(addFieldListBox.SelectedItem);
                addFieldListBox.Items.Remove(addFieldListBox.SelectedItem);
            }
        }

        private void addFieldButtonX_Click(object sender, EventArgs e)
        {
            if (fieldListBox.SelectedItem != null)
            {
                addFieldListBox.Items.Add(fieldListBox.SelectedItem);
                fieldListBox.Items.Remove(fieldListBox.SelectedItem);
            }
        }

        private void CreateShpFileForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < excelDataGridViewX.Columns.Count; i++)
            {
                string HeaderString = excelDataGridViewX.Columns[i].HeaderText;
                xComboBoxEx.Items.Add(HeaderString);
                yComboBoxEx.Items.Add(HeaderString);
                fieldListBox.Items.Add(HeaderString);
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            try
            {
                IWorkspaceFactory pShpWksFact = new ShapefileWorkspaceFactory();
                IFeatureWorkspace pFeatWks;
                pFeatWks = (IFeatureWorkspace)pShpWksFact.OpenFromFile(filePath, 0);
                const string strShapeFieldName = "Shape";
                //定义属性字段
                IFields pFields = new Fields();
                IFieldsEdit pFieldsEdit;
                pFieldsEdit = pFields as IFieldsEdit;
                IField pField = new Field();
                IFieldEdit pFieldEdit = new Field() as IFieldEdit;
                pFieldEdit.Name_2 = strShapeFieldName;
                pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
                pField = pFieldEdit as IField;
                //定义几何属性
                IGeometryDef pGeomDef = new GeometryDef();
                IGeometryDefEdit pGeomDefEdit = new GeometryDef() as IGeometryDefEdit;
                pGeomDefEdit = pGeomDef as IGeometryDefEdit;
                switch (shpTypeComboBox.Text)
                {
                    case "Point":
                        pGeomDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
                        break;
                    case "Polyline":
                        pGeomDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
                        break;
                    case "Polygon":
                        pGeomDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                        break;
                }

                pGeomDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
                pGeomDefEdit.SpatialReference_2 = new UnknownCoordinateSystem() as ISpatialReference;
                pFieldEdit.GeometryDef_2 = pGeomDef;
                pFieldsEdit.AddField(pField);
                pFields = pFieldsEdit as IFields;
                IFeatureClass pFeatureClass;
                pFeatureClass = pFeatWks.CreateFeatureClass(fileName, pFields, null, null, 
                    esriFeatureType.esriFTSimple, strShapeFieldName, "");
                //添加属性字段
                for (int i = 0; i < addFieldListBox.Items.Count; i++)
                {
                    IField pfield = new Field();
                    IFieldEdit pfieldEdit = new Field() as IFieldEdit;
                    pfieldEdit.Name_2 = addFieldListBox.Items[i].ToString();
                    pfieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                    pfield = pfieldEdit as IField;
                    pFeatureClass.AddField(pfield);
                }
                //绘制点
                for (int i = 0; i < excelDataGridViewX.Rows.Count - 1; i++)
                {
                    DataGridViewRow dataRow = excelDataGridViewX.Rows[i];
                    double pointX, pointY;
                    pointX = double.Parse(dataRow.Cells[xComboBoxEx.Text].Value.ToString());
                    pointY = double.Parse(dataRow.Cells[yComboBoxEx.Text].Value.ToString());

                    IPoint pPoint = new ESRI.ArcGIS.Geometry.Point() as IPoint;
                    pPoint.PutCoords(pointX, pointY);
                    IFeature pFeature = pFeatureClass.CreateFeature();
                    pFeature.Shape = pPoint;
                    //为该点添加属性值
                    for (int j = 0; j < addFieldListBox.Items.Count; j++)
                    {
                        string fieldName = addFieldListBox.Items[j].ToString();
                        pFeature.set_Value(pFeature.Fields.FindField(fieldName), 
                            dataRow.Cells[fieldName].Value.ToString());
                    }
                    pFeature.Store();
                }
                //添加新建的数据至Map中
                axMapControl.AddShapeFile(filePath, fileName);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenExcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        private void saveFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "新建Shp文件";
                saveFileDialog1.Filter = "Shp文件(*.shp)|*.shp";
                saveFileDialog1.ShowDialog();

                string saveFilePath = saveFileDialog1.FileName;
                int i = saveFilePath.LastIndexOf(@"\");
                int length = saveFilePath.Length;
                filePath = Microsoft.VisualBasic.Strings.Left(saveFilePath, i + 1);
                filePathTextBox.Text = filePath;
                fileName = Microsoft.VisualBasic.Strings.Right(saveFilePath, length - i - 1);
                fileNameTextBox.Text = fileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void filePathTextBox_TextChanged(object sender, EventArgs e)
        {
            filePath = filePathTextBox.Text;
        }

        private void fileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            fileName = fileNameTextBox.Text;
        }

    }
}
