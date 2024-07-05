package pages;

import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;

public class TabBarPage extends BasePage{

     @FindBy(className = "searchData")
     private WebElement searchBox;

    @FindBy(className = "basketTotalNum")
    private WebElement basketTotalNumber;

    @FindBy(xpath = "//*[@id=\"2a7d83f8-effc-496f-ab9f-ed6840f0a847\"]")
    private WebElement redCookies;

    public TabBarPage(WebDriver driver){
        super(driver);
        PageFactory.initElements(driver, this);
    }

    public void search(String searchWord){
        searchBox.sendKeys(searchWord+ Keys.ENTER);
    }

    public String getBasketTotalNumber(){
        return basketTotalNumber.getText();
    }

    public void redClick(){
        redCookies.click();
    }
}