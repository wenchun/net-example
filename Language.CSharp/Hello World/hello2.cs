using System;
using System.Windows.Forms;

public class MainForm : Form
{
  private Button helloButton;
  
  private void helloButtonClicked(object sender, EventArgs e)
  {
    MessageBox.Show("Hello! Windows!");
  }

  public MainForm() 
  {
    // 設定視窗標題  
    Text = "Hello! Windows Form!";
    Width = 400;
    Height = 200;
    
    // 動態建立一個按鈕
    helloButton = new Button();
    helloButton.Left = 40;
    helloButton.Top = 20;
    helloButton.Width = 80;
    helloButton.Height = 30;
    helloButton.Text = "Hello";
    helloButton.BackColor = System.Drawing.Color.Yellow;
    helloButton.Click += new EventHandler(helloButtonClicked);
    
    Controls.Add(helloButton);  // 或者 helloButton.Parent = this;
  }
  
  public static void Main()
  {
    Application.Run(new MainForm());
  }
}