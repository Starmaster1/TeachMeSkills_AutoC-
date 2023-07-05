﻿using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BussinessObject_SalesForce.Pages
{
    public class NewContactModal
    {
        Input accountName = new("Last Name");
        PartialTextDropDown typeDropDown = new("Account Name");

        Button saveButton = new(By.XPath("//*[@title='Save']//button"));

        public void CreateContact(string name, string listOption)
        {
            accountName.GetElement().SendKeys(name);
            typeDropDown.Select("vladimirvolkov@internetkeno.com");
            typeDropDown.Clear();
            typeDropDown.SelectByPartText("adfg");

            saveButton.GetElement().Click();
        }
    }
}
