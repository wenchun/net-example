using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace HelpProviderDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.HelpProvider helpProvider1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnuHelpContent;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.button2 = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			this.label1 = new System.Windows.Forms.Label();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuHelpContent = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.AccessibleDescription = "";
			this.checkBox1.AccessibleName = "Check Box";
			this.checkBox1.Location = new System.Drawing.Point(24, 104);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "checkBox1";
			this.toolTip1.SetToolTip(this.checkBox1, "當你用 HelpButton 點我時，我會以 pop-up help 的方式顯示。");
			// 
			// button1
			// 
			this.button1.AccessibleName = "button";
			this.button1.Location = new System.Drawing.Point(24, 160);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.toolTip1.SetToolTip(this.button1, "當你用 HelpButton 點我時，我會開啟一個網頁。");
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 340);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																																									this.statusBarPanel1,
																																									this.statusBarPanel2});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(584, 22);
			this.statusBar1.TabIndex = 2;
			this.statusBar1.Text = "statusBar1";
			this.toolTip1.SetToolTip(this.statusBar1, "xxx");
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Text = "hello!";
			this.statusBarPanel1.ToolTipText = "this is a test";
			this.statusBarPanel1.Width = 200;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Text = "statusBarPanel2";
			this.statusBarPanel2.Width = 300;
			// 
			// button2
			// 
			this.helpProvider1.SetHelpKeyword(this.button2, "js_DateUtil.htm#clacAge");
			this.helpProvider1.SetHelpNavigator(this.button2, System.Windows.Forms.HelpNavigator.Topic);
			this.helpProvider1.SetHelpString(this.button2, "請將輸入焦點移到這裡，然後按 F1 看說明。");
			this.button2.Location = new System.Drawing.Point(128, 160);
			this.button2.Name = "button2";
			this.helpProvider1.SetShowHelp(this.button2, true);
			this.button2.TabIndex = 4;
			this.button2.Text = "button2";
			this.toolTip1.SetToolTip(this.button2, "試試看分別用 HelpButton 和 F1 鍵！");
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// helpProvider1
			// 
			this.helpProvider1.HelpNamespace = "SwjHelp.chm";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(472, 56);
			this.label1.TabIndex = 3;
			this.label1.Text = "Try to hover over each control, then use HelpButton on the caption bar. Note: 由於有" +
				"使用 HelpProvider, 每個元件的 F1 help 都會開啟同一份 HTML help 文件，而且 Form 的 HelpRequested 事件也還" +
				"是會觸發。";
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.menuItem1,
																																							this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.menuItem2});
			this.menuItem1.Text = "&File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "E&xit";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.mnuHelpContent});
			this.menuItem3.Text = "&Help";
			// 
			// mnuHelpContent
			// 
			this.mnuHelpContent.Index = 0;
			this.mnuHelpContent.Text = "&Content";
			this.mnuHelpContent.Click += new System.EventHandler(this.mnuHelpContent_Click);
			// 
			// Form1
			// 
			this.AccessibleDescription = "";
			this.AccessibleName = "This is a demo program";
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(584, 362);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkBox1);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.HelpButton = true;
			this.helpProvider1.SetHelpKeyword(this, "");
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.helpProvider1.SetShowHelp(this, true);
			this.Text = "HelpProvider Demo by Huan-Lin Tsai. Jun-28-2005.";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Form1_HelpRequested);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		public Control[] GetAllControls(Control container) 
		{ 
			ArrayList al = new ArrayList(); 
			foreach (Control ctl in container.Controls) 
			{ 
				GetAllControlsHelper(ctl, al); 
			} 
			return (Control[]) al.ToArray(typeof(Control)); 
		} 

		void GetAllControlsHelper(Control container, ArrayList al) 
		{ 
			al.Add(container); 
			foreach (Control ctl in container.Controls) 
			{ 
				GetAllControlsHelper(ctl, al); 
			} 
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			// 把每個控制項的 tool tip 訊息指定給 Error 屬性
			foreach (Control ctl in GetAllControls(this))
			{
				string toolTip = toolTip1.GetToolTip(ctl);
				if (toolTip.Length == 0)
					continue;
				errorProvider1.SetError(ctl, toolTip);
			}
		}

		private void Form1_HelpRequested(object sender, System.Windows.Forms.HelpEventArgs hlpevent)
		{
			if (Control.MouseButtons == MouseButtons.None)
			{
				// That means user pressed F1 key.
				MessageBox.Show("Help on F1");
			}
			else // User clicked the help button.
			{
				Point pt = this.PointToClient(hlpevent.MousePos);
				if (button1.Bounds.Contains(pt))
				{
					String help = toolTip1.GetToolTip(checkBox1);
					Help.ShowHelp(this, "http://msdn.microsoft.com/library/cht/");
				}
				else if (checkBox1.Bounds.Contains(pt)) 
				{
					String help = toolTip1.GetToolTip(checkBox1);
					Help.ShowPopup(this, help, hlpevent.MousePos);
				}
			}
			hlpevent.Handled = true;
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void mnuHelpContent_Click(object sender, System.EventArgs e)
		{
			Help.ShowHelp(this, helpProvider1.HelpNamespace);
		}
	}
}
