package pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

public class ProductDetailPage extends BasePage{

    @FindBy(className="addBasketUnify")
    private WebElement addToBasket;

    public ProductDetailPage(WebDriver driver){
        super(driver);
    }

    public void addToCard(){
        addToBasket.click();
    }
}
