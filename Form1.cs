using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Graphical_Programming_Language_App_Medhavi.Components;

namespace Graphical_Programming_Language_App_Medhavi
{
    /// <summary>
    /// Represents the main form of the application.
    /// </summary>
    public partial class Form1 : Form
    {

        /// <summary>
        /// Initializes a new instance of the Form1 class.
        /// </summary>

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// Handles the event when the "Save" button is clicked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void save_Click(object sender, EventArgs e)
        {
            try
            {

                FileHandler fileHandler = new FileHandler();
                fileHandler.Save(textBox1.Text);

                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the event when the "Load" button is clicked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>

        private void load_Click(object sender, EventArgs e)
        {
            FileHandler fileHandler = new FileHandler();
            string text = fileHandler.Load();
            textBox1.Text = text;
        }

       

        /// <summary>
        /// Handles the event when the "Run" button is clicked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void run_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox2.Text.ToLower() != "run" && textBox2.Text != "")
                {
                    if (textBox2.Text.ToLower() == "clear")
                    {
                        Graphics g = panel1.CreateGraphics();
                        g.Clear(panel1.BackColor);
                    }
                    else if (textBox2.Text.ToLower() == "reset")
                    {
                        GlobalConfiguration.xPoint = 10;
                        GlobalConfiguration.yPoint = 10;
                        position.Text = "( " + GlobalConfiguration.xPoint + ", " + GlobalConfiguration.yPoint + " )";

                    }
                    else if (textBox2.Text.ToLower() == "game")
                    {
                        SnakeGame s = new SnakeGame(panel1, scoreBoard);
                    }
                    else
                    {
                        using (Graphics gCommandParser = panel1.CreateGraphics())
                        {
                            new CommandParser(textBox2.Text, gCommandParser);
                        }

                    }
                   
                }
                if (textBox2.Text.ToLower() == "run")
                {
                    if (textBox2.Text.ToLower() == "clear")
                    {
                        Graphics g = panel1.CreateGraphics();
                        g.Clear(panel1.BackColor);
                    }
                    else if(textBox2.Text.ToLower() == "reset")
                    {
                        GlobalConfiguration.xPoint = 10;
                        GlobalConfiguration.yPoint = 10;
                        position.Text = "( " + GlobalConfiguration.xPoint + ", " + GlobalConfiguration.yPoint + " )";
                    }
                    
                    else
                    {

                        if (textBox1.Text.ToLower() == "" )
                        {
                            using (Graphics gProgramHandler = panel1.CreateGraphics())
                            {
                                gProgramHandler.Clear(panel1.BackColor);
                                ProgramHandler p = new ProgramHandler(gProgramHandler);
                                p.Execute(textBox3.Text);
                            }
                        }
                        else if (textBox3.Text.ToLower() == "")
                        {
                            using (Graphics gProgramHandler = panel1.CreateGraphics())
                            {
                                gProgramHandler.Clear(panel1.BackColor);
                                ProgramHandler p = new ProgramHandler(gProgramHandler);
                                p.Execute(textBox1.Text);
                            }
                        }
                        else
                        {
                            using (Graphics gProgramHandler1 = panel1.CreateGraphics())
                            {
                                gProgramHandler1.Clear(panel1.BackColor);

                                ProgramHandler p1 = new ProgramHandler(gProgramHandler1);

                                Thread threadTextBox1 = new Thread(() =>
                                {
                                    p1.Execute(textBox3.Text);
                                });
                                p1.Execute(textBox1.Text);
                                threadTextBox1.Start();
                                threadTextBox1.Join();
                               
                            }
                        }

                    }

                }
                if (textBox2.Text.ToLower() == "run")

                    if (GlobalConfiguration.isFillOn)
                {
                    fill.Text = "on";
                }
                else
                {
                    fill.Text = "off";
                }

                position.Text = "( " + GlobalConfiguration.xPoint + ", " + GlobalConfiguration.yPoint + " )";

            }

            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException invEx)
            {
                MessageBox.Show(invEx.Message, "Invalid Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message, "An error Occur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }

        private void syntax_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Gets the Graphics object of the panel.
        /// </summary>
        /// <returns>The Graphics object of the panel.</returns>
        public Graphics getPanel()
        {
            return panel1.CreateGraphics();
        }

        private void Canva_clear_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);
        }
        internal void Canva_clear_Click()
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);
        }

        private void reset_Click(object sender, EventArgs e)
        {
            GlobalConfiguration.xPoint = 10;
            GlobalConfiguration.yPoint = 10;
            position.Text = "( " + GlobalConfiguration.xPoint + ", " + GlobalConfiguration.yPoint + " )";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void syntax_check_Click(object sender, EventArgs e)
        {
            error.Text = "";
            try
            {
                if (textBox2.Text.ToLower() == "run")
                {
                    if (textBox2.Text.ToLower() == "clear")
                    {
                        Graphics g = panel1.CreateGraphics();
                        g.Clear(panel2.BackColor);
                    }
                    else if (textBox2.Text.ToLower() == "reset")
                    {
                        GlobalConfiguration.xPoint = 10;
                        GlobalConfiguration.yPoint = 10;
                        position.Text = "( " + GlobalConfiguration.xPoint + ", " + GlobalConfiguration.yPoint + " )";
                    }

                    else
                    {

                        if (textBox1.Text.ToLower() == "" && textBox3.Text.ToLower() != "")
                        {
                            using (Graphics gProgramHandler = panel2.CreateGraphics())
                            {
                                gProgramHandler.Clear(panel2.BackColor);
                                ProgramHandler p = new ProgramHandler(gProgramHandler);
                                p.Execute(textBox3.Text);
                            }
                            error.Text = "All Syntax are Clear, You are good to go";
                            error.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (textBox3.Text.ToLower() == "" && textBox1.Text.ToLower() != "")
                        {
                            using (Graphics gProgramHandler = panel2.CreateGraphics())
                            {
                                gProgramHandler.Clear(panel2.BackColor);
                                ProgramHandler p = new ProgramHandler(gProgramHandler);
                                p.Execute(textBox1.Text);
                            }
                            error.Text = "All Syntax are Clear, You are good to go";
                            error.ForeColor = System.Drawing.Color.Red;
                        }
                        else if(textBox1.Text.ToLower() != "" && textBox3.Text.ToLower() != "")
                        {
                            using (Graphics gProgramHandler1 = panel2.CreateGraphics())
                            {
                                gProgramHandler1.Clear(panel2.BackColor);

                                ProgramHandler p1 = new ProgramHandler(gProgramHandler1);

                                // Define and start separate threads to execute commands from textBox1 and textBox3
                                Thread threadTextBox1 = new Thread(() =>
                                {
                                    p1.Execute(textBox3.Text);
                                });
                                p1.Execute(textBox1.Text);
                                threadTextBox1.Start();

                                threadTextBox1.Join();
                                error.Text = "All Syntax are Clear, You are good to go";
                                error.ForeColor = System.Drawing.Color.Red;

                            }
                        }
                        else
                        {
                            error.Text = "Text fields are empty";
                        }
                       


                    }

                }
                else
                {
                    error.Text = "Error: Missing Run command in Singleline Input Box";
                    error.ForeColor = System.Drawing.Color.Red;

                }
            }
            catch(ArgumentException ex) 
            {
                error.Text = $"Error: {ex.Message}";
            }

        }
    }
}


