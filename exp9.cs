using System;
using System.Drawing;
using System.Windows.Forms;

public class MDIForm : Form
{
    MenuStrip menuStrip;
    ToolStripMenuItem fileMenu;
    ToolStripMenuItem newWindow;
    ToolStripMenuItem customDialog;
    ToolStripMenuItem exitMenu;
    ToolStripMenuItem windowMenu;

    public MDIForm()
    {
        Text = "MDI Application";
        Size = new Size(800, 500);

        IsMdiContainer = true;

        menuStrip = new MenuStrip();

        fileMenu = new ToolStripMenuItem("File");

        newWindow = new ToolStripMenuItem("New Window");
        customDialog = new ToolStripMenuItem("Custom Dialog");
        exitMenu = new ToolStripMenuItem("Exit");

        newWindow.Click += NewWindow_Click;
        customDialog.Click += CustomDialog_Click;
        exitMenu.Click += ExitMenu_Click;

        fileMenu.DropDownItems.Add(newWindow);
        fileMenu.DropDownItems.Add(customDialog);
        fileMenu.DropDownItems.Add(exitMenu);

        windowMenu = new ToolStripMenuItem("Window");

        menuStrip.Items.Add(fileMenu);
        menuStrip.Items.Add(windowMenu);

        Controls.Add(menuStrip);
        MainMenuStrip = menuStrip;
    }

    private void NewWindow_Click(object sender, EventArgs e)
    {
        ChildForm child = new ChildForm();

        child.MdiParent = this;
        child.Text = "Child Window";

        child.Show();
    }

    private void CustomDialog_Click(object sender, EventArgs e)
    {
        Form dialog = new Form();

        dialog.Text = "Custom Dialog";
        dialog.Size = new Size(350, 200);
        dialog.StartPosition = FormStartPosition.CenterParent;

        Label label = new Label();
        label.Text = "Enter Name:";
        label.Location = new Point(30, 30);
        label.AutoSize = true;

        TextBox textBox = new TextBox();
        textBox.Location = new Point(30, 60);
        textBox.Width = 220;

        Button okButton = new Button();
        okButton.Text = "OK";
        okButton.Location = new Point(30, 100);

        okButton.Click += (s, e) =>
        {
            MessageBox.Show("Hello " + textBox.Text);
            dialog.Close();
        };

        dialog.Controls.Add(label);
        dialog.Controls.Add(textBox);
        dialog.Controls.Add(okButton);

        dialog.ShowDialog();
    }

    private void ExitMenu_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MDIForm());
    }
}

public class ChildForm : Form
{
    public ChildForm()
    {
        Size = new Size(400, 250);

        Label label = new Label();

        label.Text = "This is a Child Form";
        label.Font = new Font("Arial", 16);
        label.AutoSize = true;
        label.Location = new Point(100, 80);

        Controls.Add(label);
    }
}