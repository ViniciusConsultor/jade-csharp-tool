using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;

namespace Jade
{
    public partial class StaForm : DevExpress.XtraEditors.XtraUserControl
    {
        public StaForm()
        {
            InitializeComponent();
        }

        private void StaForm_Load(object sender, EventArgs e)
        {
            ChartTitle title = new ChartTitle();
            title.Text = "编辑新闻发布量统计";
            chartControl1.Titles.Clear();
            chartControl1.Titles.Add(title);

            Series series1 = new Series("王伟伟", ViewType.Line);
            series1.ArgumentScaleType = ScaleType.DateTime;
            var i = 1;
            series1.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 10 }));
            series1.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 12 }));
            series1.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 14 }));
            series1.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 17 }));
            series1.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 21 }));
            series1.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 26 }));
            series1.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 29 }));
            series1.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 30 }));
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((PointSeriesView)series1.View).PointMarkerOptions.Kind = MarkerKind.Triangle;

            i = 1;
            Series series2 = new Series("王雨", ViewType.Line);
            series2.ArgumentScaleType = ScaleType.DateTime; //这句话必须有,否则点画不出来.
            ((LineSeriesView)series2.View).LineStyle.DashStyle = DashStyle.Solid;
            series2.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 4 }));
            series2.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 14 }));
            series2.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 17 }));
            series2.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 22 }));
            series2.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 20 }));
            series2.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 15 }));
            series2.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 18 }));
            series2.Points.Add(new SeriesPoint(DateTime.Now.Date.AddDays(i++), new double[] { 11 }));
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((PointSeriesView)series2.View).PointMarkerOptions.Kind = MarkerKind.Cross;

            chartControl1.Series.Clear();
            chartControl1.Series.Add(series1);
            chartControl1.Series.Add(series2);
            chartControl1.Legend.Visible = true;
        }
    }
}