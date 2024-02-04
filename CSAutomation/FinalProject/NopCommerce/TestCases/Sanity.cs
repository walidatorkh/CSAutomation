using FinalProject.NopCommerce.Extensions;
using FinalProject.NopCommerce.Utilities;
using FinalProject.NopCommerce.WorkFlows;
using NUnit.Framework;

namespace FinalProject.NopCommerce.TestCases
{
    [TestFixture]
    class Sanity : CommonOps
    {

        [Test]
        public void Test01_VerifyNumberOfBooksItems()
        {
            UIFlows.DisplayItems(topMenu.link_Books, 2);
            Verifications.VerifyEquals(3, UIActions.GetListCount(items.list_Items));
        }

        [Test]
        public void Test02_VerifyNumberOfApparelItems()
        {
            UIFlows.DisplayCategories(topMenu.link_Apparel);
            Verifications.VerifyEquals(3, UIActions.GetListCount(items.list_Items));
        }

        [Test]
        public void Test03_VerifyNumberOfDigitalDownloadsItems()
        {
            UIFlows.DisplayItems(topMenu.link_Digital_downloads, 2);
            Verifications.VerifyEquals(3, UIActions.GetListCount(items.list_Items));
        }

        [Test]
        public void Test04_VerifyNumberOfJewelryItems()
        {
            UIFlows.DisplayItems(topMenu.link_Jewelry, 2);
            Verifications.VerifyEquals(3, UIActions.GetListCount(items.list_Items));
        }

        [Test]
        public void Test05_VerifyNumberOfComputersItems()
        {
            UIFlows.DisplayCategories(topMenu.link_Computers);
            Verifications.VerifyEquals(3, UIActions.GetListCount(items.list_Items));
        }

        [Test]
        public void Test06_VerifyNumberOfElectronicsItems()
        {
            UIFlows.DisplayCategories(topMenu.link_Electronics);
            Verifications.VerifyEquals(3, UIActions.GetListCount(items.list_Items));
        }

        [Test]
        public void Test07_VerifyNumberOfGiftCardsItems()
        {
            UIFlows.DisplayItems(topMenu.link_Gift_Cards, 2);
            Verifications.VerifyEquals(3, UIActions.GetListCount(items.list_Items));
        }

        [Test]
        public void Test08_VerifyNavigateUsingMouseHover()
        {
            UIFlows.NavigateMouseHover(topMenu.link_Apparel, items.link_Show_Shoes);
            Verifications.VerifyEquals(3, UIActions.GetListCount(items.list_Items));
        }

        [Test]
        public void Test09_VerifyScreenshotDuringFail()
        {
            UIFlows.NavigateMouseHover(topMenu.link_Apparel, items.link_Show_Shoes);
            Verifications.VerifyEquals(30, UIActions.GetListCount(items.list_Items));
        }

    }
}
