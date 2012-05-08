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
    // �]�w�������D  
    Text = "Hello! Windows Form!";
    Width = 400;
    Height = 200;
    
    // �ʺA�إߤ@�ӫ��s
    helloButton = new Button();
    helloButton.Left = 40;
    helloButton.Top = 20;
    helloButton.Width = 80;
    helloButton.Height = 30;
    helloButton.Text = "Hello";
    helloButton.BackColor = System.Drawing.Color.Yellow;
    helloButton.Click += new EventHandler(helloButtonClicked);
    
    Controls.Add(helloButton);  // �Ϊ� helloButton.Parent = this;
  }
  
  public static void Main()
  {
    Application.Run(new MainForm());
  }
}