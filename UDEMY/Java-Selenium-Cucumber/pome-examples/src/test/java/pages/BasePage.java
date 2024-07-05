package pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

public class BasePage {
    protected WebDriver driver;

    public BasePage(WebDriver driver){
        this.driver=driver;
    }

    public void navigateTo(String Url){
        driver.get(Url);
    }

    public String getPageUrl(){
        return driver.getCurrentUrl();
    }

    public String getPageTitle(){
        return driver.getTitle();
    }

    public WebElement find(By locator){
        return driver.findElement(locator);
    }

    public void click(By locator){
        find(locator).click();
    }
}
