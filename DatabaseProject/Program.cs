using DatabaseProject.ui;

namespace DatabaseProject
{
    /// <summary>
    /// The main program class responsible for starting the application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        static void Main(string[] args)
        {
            // Start the user interface to interact with the database.
            UI.Start();
        }
    }
}