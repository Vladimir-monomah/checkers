// Bring the needed packages into the global scope
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
//using CheckersCtrl;
using System.Diagnostics;

/// <sumary>
///  The form that holds the Checkers control.
/// </sumary>
class Checkers: Form  {

              
  // Reference to the checkers control
    private BoardView m_view;

  // Menu options for setting the game level
  // Needed because we need to set/unset the checkmarks
  private MenuItem language;
      /// <sumary> 
  ///  Creates a from with a checkers game control
  /// </sumary>
  /// 
  

  public Checkers () {

      

    // Set the window title
    Text = "�����";
    //Names name_window = new Names();
    //name_window.ShowDialog();
    // Set the window size
   // ClientSize = new Size (300, 300);

    // Create the menu
    MainMenu menu = new MainMenu ();
    MenuItem item = new MenuItem ("&����");
    menu.MenuItems.Add(item);

    // Add the menu entries to the "File" menu    
    item.MenuItems.Add (new MenuItem ("&����� ����", new EventHandler (OnNewGame)));
    item.MenuItems.Add (new MenuItem ("&�������...", new EventHandler (OnOpen)));
    item.MenuItems.Add (new MenuItem ("&���������...", new EventHandler (OnSave)));
    item.MenuItems.Add (new MenuItem ("&�����", new EventHandler (OnExit)));

   
    // Create a new Menu
    item = new MenuItem ("&������");
    menu.MenuItems.Add (item);

    // Add the menu entries to the "Help" menu
    item.MenuItems.Add (new MenuItem ("&� �������", new EventHandler (OnAbout)));

    // Attach the menu to the window
    Menu = menu;

    // Add the checkers control to the form
    m_view = new BoardView (this);
    m_view.Location = new Point (0,0);
    m_view.Size = ClientSize;
    Controls.Add (m_view);
  }


  /// <sumary> 	
  // Handler for the "New Game" option
  /// </sumary>
  private void OnNewGame (object sender, EventArgs ev) {
    // Save the current dificulty level
    int level = m_view.depth;
    m_view.newGame ();
    m_view.depth = level;
  }

  /// <sumary> 
  // Handler for the "Open" option
  /// </sumary>
  private void OnOpen (object sender, EventArgs ev) {
    
    OpenFileDialog openDlg = new OpenFileDialog();

    openDlg.InitialDirectory = Directory.GetCurrentDirectory ();
    openDlg.Filter = "Checker files (*.sav)|*.sav|All files (*.*)|*.*";
    openDlg.FilterIndex = 1;
    openDlg.RestoreDirectory = true;

    if(openDlg.ShowDialog() == DialogResult.OK) {
        FileStream kl = new FileStream(openDlg.FileName, FileMode.Open);

        if((kl != null)) {
            m_view.loadBoard (kl);
            kl.Close();
        }
    }        
  }

  /// <sumary> 
  /// Handler for the "Save" option
  /// </sumary>
  private void OnSave (object sender, EventArgs ev) {
    
    SaveFileDialog saveDlg = new SaveFileDialog();
    
    saveDlg.InitialDirectory = Directory.GetCurrentDirectory ();
    saveDlg.Filter = "Checker files (*.sav)|*.sav|All files (*.*)|*.*";
    saveDlg.FilterIndex = 1;
    saveDlg.RestoreDirectory = true;

    if(saveDlg.ShowDialog() == DialogResult.OK) {
        FileStream fs1 = new FileStream(saveDlg.FileName, FileMode.Create);
        
        StreamWriter myStream = new StreamWriter(fs1);
        if((myStream  != null)) {
          m_view.saveBoard (fs1); 
          myStream.Close();
        }
    }        
  }

  /// <sumary> 
  /// Handler for the "Exit" option
  /// </sumary>
  private void OnExit (object sender, EventArgs ev) {
    Close ();
  }

  /// <sumary> 	
  // Handler for the "Easy" option
  /// </sumary>
  private void OnEasyOpt (object sender, EventArgs ev) {
    m_view.depth = 1;
    
  }

  /// <sumary> 	
  // Handler for the "Medium" option
  /// </sumary>
  private void OnMediumOpt (object sender, EventArgs ev) {
    m_view.depth = 3;
   
  }

  /// <sumary> 	
  // Handler for the "Hard" option
  /// </sumary>
  private void OnHardOpt (object sender, EventArgs ev) {
    m_view.depth = 6;
    
  }

  
    /// </sumary>
  private void OnAbout (object sender, EventArgs ev) {
      
          AboutBox about = new AboutBox();
          about.ShowDialog();
          about = null; // Help the GC
  }

  /// <sumary> 
  /// Processes the window resizing
  /// </sumary>
  protected override void OnSizeChanged (EventArgs e) {
    base.OnSizeChanged (e);
    if (m_view != null) {
      m_view.Size = ClientSize;
      m_view.Invalidate ();
    }
  }

  /// <sumary> 
  /// Program entry point
  /// </sumary>
  
    [STAThread]
  public static void Main (String [] args) {
    Debug.Listeners.Add(new TextWriterTraceListener(System.Console.Out));
    Application.Run (new Checkers ());
  }
    
    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // Checkers
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "Checkers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.ResumeLayout(false);

    }

    

    

   
        
            
        
        
    }

    


