using FinalProject.NopCommerce.Extensions;
using FinalProject.NopCommerce.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.NopCommerce.WorkFlows
{
    class UIFlows : CommonOps
    {
        public static void DisplayItems(IWebElement elem, int number)
        {
            UIActions.Click(elem);
            UIActions.UpdateDropDown(sortDisplay.drop_Display, number);
        }
        public static void DisplayCategories(IWebElement elem)
        {
            UIActions.Click(elem);
            UIActions.GetListCount(sortDisplay.counted_Categories);
        }

        public static void NavigateMouseHover(IWebElement elem, IWebElement elem2)
        {
            UIActions.UpdateMouseHover(elem);
            UIActions.Click(elem2);
        }
    }
}
