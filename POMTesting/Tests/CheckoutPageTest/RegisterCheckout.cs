﻿using FluentAssertions;
using NUnit.Framework;

namespace Store.PageObjects
{
    class RegisterCheckout : InitClass
    {
        HomePage home;
        CartPage cart;
        CheckoutStep1Page step1;
        CheckoutStep2Page step2;
        CheckoutStep3Page step3;
        CheckoutStep4Page step4;
        CheckoutStep5Page step5;
        CheckoutStep6Page step6;
        SuccessPage success;

        public CheckoutStep1Page PrepareProductsToChekout()
        {
            home = new HomePage(driver);
            home.AddProductToChart();
            home.AddProductToChart();
            home.GetCartButtonMessage().Should().Contain("2 item(s)", "Invalid cart items amount");
            cart = home.GoToCartPage();
            return cart.ClickOnCheckoutButton();
        }

        [Test]
        public void ShouldDisplayMessageAboutMandatoryFieldsOnStep2ForRegister()
        {
            step1 = PrepareProductsToChekout();
            step1.CheckRegister();

            step2 = step1.FinishStep1();
            step2.TryToFinishStep2();
            step2.GetValidationMessage().Should().Contain("must be", "Invalid mandatory field message");
        }

        [Test]
        public void ShouldDisplayMessageAboutMandatoryAcceptedPrivacyPolicyForRegister()
        {
            step1 = PrepareProductsToChekout();
            step1.CheckRegister();

            step2 = step1.FinishStep1();
            step2.SetPersonalDetails();
            step2.SetPassword();
            step2.SetAddress();
            step2.TryToFinishStep2();
            step2.GetAlertMessage().Should().Contain("You must agree to the Privacy Policy!", "Invalid mandatory Privacy Policy message");
        }

        [Test]
        public void ShouldSuccessfullyOrderTwoProductsForRegister()
        {
            step1 = PrepareProductsToChekout();
            step1.CheckRegister();
            step2 = step1.FinishStep1();

            step2.SetPersonalDetails();
            step2.SetPassword();
            step2.SetAddress();
            step2.CheckPrivacyPolicy();
            step3 = step2.FinishStep2();

            step4 = step3.FinishStep3();

            step5 = step4.FinishStep4();
            step5.AgreeTerms();

            step6 = step5.FinishStep5();

            success = step6.ConfirmOrder();
            success.GetMessage().Should().Contain("Your order has been placed!", "Invalid success message");
        }
    }
}
