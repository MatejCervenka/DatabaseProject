namespace DatabaseProject
{
    /// <summary>
    /// Represents a user interface menu for interacting with the database.
    /// </summary>
    public class UIMenu
    {
        private List<string> menu = new List<string>();
        private bool isFilled = false;

        /// <summary>
        /// Adds a new item to the menu.
        /// </summary>
        /// <param name="item">The item to add to the menu.</param>
        public void AddItem(string item)
        {
            menu.Add(item);
        }

        /// <summary>
        /// Fills the menu with predefined options.
        /// </summary>
        public void FillMenu()
        {
            Console.WriteLine();
            menu.Add("----------------1) Add an order");
            menu.Add("----------------2) Add a product");
            menu.Add("----------------3) Add an ordered product");
            menu.Add("----------------4) Add a supplier");
            menu.Add("----------------5) Add a customer");
            menu.Add("----------------6) Update an order");
            menu.Add("----------------7) Update a product");
            menu.Add("----------------8) Update an ordered product");
            menu.Add("----------------9) Update a supplier");
            menu.Add("----------------10) Update a customer");
            menu.Add("----------------11) Delete an order");
            menu.Add("----------------12) Delete a product");
            menu.Add("----------------13) Delete an ordered product");
            menu.Add("----------------14) Delete a supplier");
            menu.Add("----------------15) Delete a customer");
            menu.Add("----------------16) List all orders");
            menu.Add("----------------17) List all products");
            menu.Add("----------------18) List all ordered products");
            menu.Add("----------------19) List all suppliers");
            menu.Add("----------------20) List all customers");
            menu.Add("----------------21) Delete all orders");
            menu.Add("----------------22) Delete all products");
            menu.Add("----------------23) Delete all ordered products");
            menu.Add("----------------24) Delete all suppliers");
            menu.Add("----------------25) Delete all customers");
            menu.Add("----------------26) List all tables");
            menu.Add("----------------27) Import customers");
            menu.Add("----------------28) Import suppliers");
            menu.Add("----------------29) Quit");
        }

        /// <summary>
        /// Prints the filled menu to the console.
        /// </summary>
        public void Print()
        {
            if (!isFilled)
            {
                FillMenu();
                isFilled = true;
            }

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }
    }
}