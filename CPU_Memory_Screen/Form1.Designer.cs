namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pRAM = new System.Diagnostics.PerformanceCounter();
            this.pCPU = new System.Diagnostics.PerformanceCounter();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroProgressBarCPU = new MetroFramework.Controls.MetroProgressBar();
            this.metroProgressBarRAM = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblCPU = new MetroFramework.Controls.MetroLabel();
            this.lblRAM = new MetroFramework.Controls.MetroLabel();
            this.GraphTracker = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphTracker)).BeginInit();
            this.SuspendLayout();
            // 
            // pRAM
            // 
            this.pRAM.CategoryName = "Memory";
            this.pRAM.CounterName = "% Committed Bytes in Use";
            // 
            // pCPU
            // 
            this.pCPU.CategoryName = "Processor";
            this.pCPU.CounterName = "% Processor Time";
            this.pCPU.InstanceName = "_Total";
            // 
            // Timer
            // 
            this.Timer.Interval = 350;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(23, 130);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(52, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "CPU:";
            // 
            // metroProgressBarCPU
            // 
            this.metroProgressBarCPU.Location = new System.Drawing.Point(98, 130);
            this.metroProgressBarCPU.Name = "metroProgressBarCPU";
            this.metroProgressBarCPU.Size = new System.Drawing.Size(538, 25);
            this.metroProgressBarCPU.TabIndex = 1;
            // 
            // metroProgressBarRAM
            // 
            this.metroProgressBarRAM.Location = new System.Drawing.Point(98, 173);
            this.metroProgressBarRAM.Name = "metroProgressBarRAM";
            this.metroProgressBarRAM.Size = new System.Drawing.Size(538, 25);
            this.metroProgressBarRAM.TabIndex = 3;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(25, 173);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(56, 25);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "RAM:";
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCPU.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblCPU.Location = new System.Drawing.Point(667, 130);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(38, 25);
            this.lblCPU.TabIndex = 4;
            this.lblCPU.Text = "0%";
            // 
            // lblRAM
            // 
            this.lblRAM.AutoSize = true;
            this.lblRAM.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblRAM.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblRAM.Location = new System.Drawing.Point(667, 173);
            this.lblRAM.Name = "lblRAM";
            this.lblRAM.Size = new System.Drawing.Size(38, 25);
            this.lblRAM.TabIndex = 5;
            this.lblRAM.Text = "0%";
            // 
            // GraphTracker
            // 
            chartArea1.Name = "ChartArea1";
            this.GraphTracker.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.GraphTracker.Legends.Add(legend1);
            this.GraphTracker.Location = new System.Drawing.Point(98, 248);
            this.GraphTracker.Name = "GraphTracker";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "CPU";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "RAM";
            this.GraphTracker.Series.Add(series1);
            this.GraphTracker.Series.Add(series2);
            this.GraphTracker.Size = new System.Drawing.Size(679, 250);
            this.GraphTracker.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Controls.Add(this.GraphTracker);
            this.Controls.Add(this.lblRAM);
            this.Controls.Add(this.lblCPU);
            this.Controls.Add(this.metroProgressBarRAM);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroProgressBarCPU);
            this.Controls.Add(this.metroLabel1);
            this.Name = "Form1";
            this.Text = "CPU && RAM";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphTracker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.PerformanceCounter pRAM;
        private System.Diagnostics.PerformanceCounter pCPU;
        private System.Windows.Forms.Timer Timer;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroProgressBar metroProgressBarCPU;
        private MetroFramework.Controls.MetroProgressBar metroProgressBarRAM;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblCPU;
        private MetroFramework.Controls.MetroLabel lblRAM;
        private System.Windows.Forms.DataVisualization.Charting.Chart GraphTracker;
    }
}

