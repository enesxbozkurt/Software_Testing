package com.examples.pom;

import org.openqa.selenium.WebElement;
import org.testng.annotations.Test;
import pages.ProductDetailPage;
import pages.ResultPage;
import pages.TabBarPage;

public class N11Test extends BaseTest{
    TabBarPage tabBarPage;

    ResultPage resultPage;

    ProductDetailPage productDetailPage;

    @Test(priority = 1)
    public void searchTest(){
        tabBarPage=new TabBarPage(driver);
        tabBarPage.navigateTo("https://n11.com");
        tabBarPage.redClick();
        tabBarPage.search("Laptop");

    }

    @Test(priority = 2)
    public void resultTest(){
        resultPage=new ResultPage(driver);
        WebElement resultWebElement=resultPage.getResultWebElement();
        softAssert.assertTrue(resultWebElement.isDisplayed());
        resultPage.clickToProduct(2);
    }

    @Test(priority = 3)
    public void addToCardTest(){
        productDetailPage=new ProductDetailPage(driver);
        productDetailPage.addToCard();
        try {
            Thread.sleep(3000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
        softAssert.assertTrue(tabBarPage.getBasketTotalNumber().equals("1"));
    }
}
