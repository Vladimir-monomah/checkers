
// Bring the needed packages into the global scope
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Resources;

public class AboutBox: Form {
  public AboutBox () {
    // Set the window title
      Checkers ks = new Checkers();
      
          Text = "� �������";
      
         
    // Set the window size
    ClientSize = new Size (400, 130);

    // Don't allow resize of the box
    FormBorderStyle = FormBorderStyle.FixedDialog;
    MinimizeBox = false;
    MaximizeBox = false;

    // Create the picture box for the image
    PictureBox picture = new PictureBox ();
    ResourceManager resources = new ResourceManager(typeof(AboutBox));
    picture.Image = ((System.Drawing.Bitmap)(resources.GetObject("AboutBox.jpg")));
    picture.Location = new Point(8, 8);
    picture.Size = new Size(152, 144);
    Controls.Add (picture);

      
    // Create the label for the copyright
    AddLabel(new Point(170, 8), new Size(128, 16), "������");

    // Create the labels for the license message
    AddLabel (new Point(170, 38), new Size(128, 16), "�������� 547 ������ ");
    
    AddLabel (new Point(170, 68), new Size(128, 16), "������ ���������");

   
    // Create an 'OK' button
    Button btn = new Button ();
    btn.Text = "&OK";
    btn.Location = new Point (250, 100);
    btn.Click += new EventHandler (OnClick);

    // This button is the default one
    AcceptButton = btn;
  
    // The box should appear in the middle of the screen
    StartPosition = FormStartPosition.CenterScreen;

    // Add the button to the form
    Controls.Add (btn);
  }

  /// <sumary> 
  /// Helper method to add the labels to the form in a
  /// generic way.
  /// </sumary>
  private void AddLabel (Point location, Size area, string str) {
    Label label = new Label ();

    // Set the label message
    label.Text = str;

    // Set the location inside the form
    label.Location = location;

    // Set the label dimension
    label.Size = area;

    // Add the Label to the form
    Controls.Add (label);
  }

  /// <sumary> 
  /// Helper method to add the link labels to the form in a
  /// generic way.
  /// </sumary>
  private void AddLinkLabel (Point location, Size area, string str) {
    LinkLabel label = new LinkLabel ();

    // Set the label message
    label.Text = str;

    // Set the location inside the form
    label.Location = location;

    // Set the label dimension
    label.Size = area;

     // Add the Label to the form
    Controls.Add (label);
  }

  /// <sumary> 
  /// Handler for the "Click" event in the 'OK' button
  /// </sumary>
  private void OnClick (object sender, EventArgs ev) {
    Close ();
  }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // AboutBox
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

    }

    /// <sumary> 
    /// Handler for the "Click" event in the 'GPL' link
    /// </sumary>


}
