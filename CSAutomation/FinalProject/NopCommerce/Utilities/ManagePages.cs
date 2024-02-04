using FinalProject.NopCommerce.PageObjects;

namespace FinalProject.NopCommerce.Utilities
{
    class ManagePages : CommonOps
    {
        public static void InitElements()
        {
            items = new Items();
            sortDisplay = new SortDisplay();
            topMenu = new TopMenu();

        }

    }
}
