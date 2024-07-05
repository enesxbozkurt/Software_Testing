package com.examples.tests;

import io.github.bonigarcia.wdm.WebDriverManager;
import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.interactions.Actions;
import org.testng.Assert;
import org.testng.annotations.AfterClass;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.Parameters;
import org.testng.annotations.Test;
import java.time.Duration;
import java.util.ArrayList;
import java.util.List;


public class MyTests {
    static WebDriver driver;
    private boolean isClicked = false;
    private boolean isClicked2 = false;
    @Parameters({"browser"})
    @BeforeClass
    public static void setUp(String browser){
        switch (browser){
            case "chrome":
                WebDriverManager.chromedriver().setup();
                driver=new ChromeDriver();
                break;
            case "firefox":
                WebDriverManager.firefoxdriver().setup();
                driver=new FirefoxDriver();
                break;
            default:
                throw new IllegalArgumentException("invalid browser value");
        }
        driver.manage().window().maximize();
        driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(20));
    }
    @Test(priority = 1, invocationCount = 2)//Ne kadar tekrar edeceğini belirtir
    public void searchTest(){
        driver.get("https://www.trendyol.com");
        try {
            Thread.sleep(2000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
        if (!isClicked) {
            WebElement element =driver.findElement(By.xpath("//*[@id=\"Rating-Review\"]"));
            element.click();
            WebElement element2=driver.findElement(By.xpath("//*[@id=\"onetrust-accept-btn-handler\"]"));
            element2.click();
            isClicked = true;
        }
        driver.findElement(By.xpath("//*[@id=\"autoCompleteAppWrapper\"]")).click();
        WebElement input=driver.findElement(By.xpath("//*[@id=\"sfx-discovery-search-suggestions\"]/div/div[1]/input"));
        input.sendKeys("İphone");
        input.sendKeys(Keys.ENTER);
        WebElement bodyElement = driver.findElement(By.tagName("body"));
        String result=bodyElement.getText();
        Assert.assertFalse(result.contains("aramanız için ürün bulunamadı. Aşağıdakiler ilginizi çekebilir."));
    }
    @Test(dependsOnMethods = "searchTest",priority = 2,enabled = false, description = "Önceliği 2 ve test aktif değil",timeOut = 5000) //Önceliği 2 ve test aktif değil
    public void addToBasketTest(){
        WebElement overlay=driver.findElement(By.xpath("//*[@id=\"search-app\"]/div/div[1]/div[2]/div[4]/div[1]/div/div[4]/div[1]/a/div[1]/div[2]/div[2]"));
        Actions actions=new Actions(driver);
        if (!isClicked2) {
            actions.moveToElement(overlay).click().perform();
            isClicked2 = true;
        }
        actions.moveToElement(overlay).click().perform();
        List<String> tabs=new ArrayList<>(driver.getWindowHandles());
        driver.switchTo().window(tabs.get(1));
        try {
            Thread.sleep(5000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
        WebElement hover=driver.findElement(By.xpath("//*[@id=\"product-detail-app\"]/div/div[2]/div/div[2]/div[2]/div/div[1]/div[5]/button"));
        actions.moveToElement(hover).click().perform();
    }
    @AfterClass
    public static void afterClass(){
        driver.close();
    }
}
