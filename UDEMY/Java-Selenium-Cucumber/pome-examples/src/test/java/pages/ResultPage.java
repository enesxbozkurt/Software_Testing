package pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindAll;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;

import java.util.List;

public class ResultPage extends BasePage{

    @FindBy(className="resultText")
    private WebElement resultText;

    @FindBy(className="productName")
    private WebElement productName;

    //@FindBy()

    @FindAll(@FindBy(className = "productName"))
    public List<WebElement> productList;

    public ResultPage(WebDriver driver){
        super(driver);
        PageFactory.initElements(driver, this);
    }

    public WebElement getResultWebElement(){
        return resultText;
    }

    public void clickToFirstProduct(){
        productName.click();
    }

    public void clickToProduct(int index){
        productList.get(index).click();
    }

    /*public void clickToCookies{

    }*/
}
