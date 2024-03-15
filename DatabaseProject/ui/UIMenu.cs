namespace DatabaseProject.ui
{
    /// <summary>
    /// Represents a user interface menu for interacting with the database.
    /// </summary>
    public class UIMenu
    {
        private List<string> menu = new List<string>();
        private bool isMainFilled = false;
        private bool isAddFilled = false;
        private bool isUpdateFilled = false;
        private bool isDeleteFilled = false;
        private bool isListAllFilled = false;
        private bool isDeleteAllFilled = false;

        /// <summary>
        /// Fills the menu with predefined options.
        /// </summary>

        private void FillMainMenu()
        {
            Console.WriteLine("");
            menu.Add("----------------1) ADD");
            menu.Add("----------------2) UPDATE");
            menu.Add("----------------3) DELETE");
            menu.Add("----------------4) LIST ALL");
            menu.Add("----------------5) DELETE ALL");
            menu.Add("----------------6) QUIT");
        }
        private void FillAddMenu()
        {
            Console.WriteLine("");
            menu.Add("----------------1) Add an order");
            menu.Add("----------------2) Add a product");
            menu.Add("----------------3) Add an ordered product");
            menu.Add("----------------4) Add a supplier");
            menu.Add("----------------5) Add a customer");
            menu.Add("----------------6) Import customers");
            menu.Add("----------------7) Import suppliers");
            menu.Add("----------------8) RETURN TO MAIN MENU");
        }

        private void FillUpdateMenu()
        {
            Console.WriteLine("");
            menu.Add("----------------1) Update an order");
            menu.Add("----------------2) Update a product");
            menu.Add("----------------3) Update an ordered product");
            menu.Add("----------------4) Update a supplier");
            menu.Add("----------------5) Update a customer");
            menu.Add("----------------6) RETURN TO MAIN MENU");
        }

        private void FillDeleteMenu()
        {
            Console.WriteLine("");
            menu.Add("----------------1) Delete an order");
            menu.Add("----------------2) Delete a product");
            menu.Add("----------------3) Delete an ordered product");
            menu.Add("----------------4) Delete a supplier");
            menu.Add("----------------5) Delete a customer");
            menu.Add("----------------6) RETURN TO MAIN MENU");
        }

        private void FillListAllMenu()
        {
            Console.WriteLine("");
            menu.Add("----------------1) List all orders");
            menu.Add("----------------2) List all products");
            menu.Add("----------------3) List all ordered products");
            menu.Add("----------------4) List all suppliers");
            menu.Add("----------------5) List all customers");
            menu.Add("----------------6) List all tables");
            menu.Add("----------------7) RETURN TO MAIN MENU");
        }
        private void FillDeleteAllMenu()
        {
            Console.WriteLine("");
            menu.Add("----------------1) Delete all orders");
            menu.Add("----------------2) Delete all products");
            menu.Add("----------------3) Delete all ordered products");
            menu.Add("----------------4) Delete all suppliers");
            menu.Add("----------------5) Delete all customers");
            menu.Add("----------------6) RETURN TO MAIN MENU");
        }

        /// <summary>
        /// Prints the filled menus to the console.
        /// </summary>
       
        public void PrintMainMenu()
        {
            if (!isMainFilled)
            {
                FillMainMenu();
                isMainFilled = true;
            }

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }
        public void PrintAddMenu()
        {
            if (!isAddFilled)
            {
                FillAddMenu();
                isAddFilled = false;
            }

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }
        
        public void PrintUpdateMenu()
        {
            if (!isUpdateFilled)
            {
                FillUpdateMenu();
                isUpdateFilled = false;
            }

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }
        
        
        public void PrintDeleteMenu()
        {
            if (!isDeleteFilled)
            {
                FillDeleteMenu();
                isDeleteFilled = false;
            }

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }
        
        public void PrintListAllMenu()
        {
            if (!isListAllFilled)
            {
                FillListAllMenu();
                isListAllFilled = false;
            }

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }
        
        public void PrintDeleteAllMenu()
        {
            if (!isDeleteAllFilled)
            {
                FillDeleteAllMenu();
                isDeleteAllFilled = false;
            }

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }
    }
}