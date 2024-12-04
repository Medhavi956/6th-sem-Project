using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Graphical_Programming_Language_App_Medhavi.Components
{
    /// <summary>
    /// Handles file operations such as saving and loading text files.
    /// </summary>
    public class FileHandler
    {
        /// <summary>
        /// Saves the provided text content into a text file.
        /// </summary>
        /// <param name="text">The text content to be saved.</param>
        public void Save(string text)
        {
            var SaveFileDialog = new SaveFileDialog
            {
                FileName = "program.txt",
                Filter = @"Text File | *.txt"
            };

            if (SaveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var write = new StreamWriter(SaveFileDialog.OpenFile());
            WriteToFile(write, text);
        }

        /// <summary>
        /// Writes text to the provided StreamWriter object.
        /// </summary>
        /// <param name="writer">The StreamWriter object to write to.</param>
        /// <param name="text">The text content to be written.</param>
        internal void WriteToFile(StreamWriter writer, string text)
        {
            try
            {
                text.Split('\n')
                    .ToList()
                    .ForEach(writer.WriteLine);
            }
            catch (Exception ex)
            {
                throw new IOException($"An Error occurred while saving the program: {ex.Message} ");
            }
            finally
            {
                writer.Dispose();
                writer.Close();
            }
        }

        /// <summary>
        /// Loads text content from a selected text file.
        /// </summary>
        /// <returns>The loaded text content as a string.</returns>
        public string Load()
        {
            string loadedText = null;

            var openFileDialog = new OpenFileDialog
            {
                Filter = @"Text Files|*.txt",
                Title = "Select a Text File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var reader = new StreamReader(openFileDialog.FileName))
                    {
                        loadedText = reader.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    throw new IOException($"An error occurred while loading the file: {ex.Message}");
                }
            }

            return loadedText;
        }
    }
}
