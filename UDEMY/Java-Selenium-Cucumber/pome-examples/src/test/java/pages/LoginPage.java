package pages;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;

public class LoginPage extends BasePage{
    @FindBy(id="email")
    private WebElement emailInput;

    @FindBy(name = "password")
    private WebElement passwordInput;

    @FindBy(id = "loginButton")
    private WebElement button;

    @FindBy(className = "error-message")
    private WebElement errorMessage;

    public LoginPage(WebDriver driver) {
        super(driver);
        PageFactory.initElements(driver,this);
    }

    public void typeEmail(String email){
        emailInput.sendKeys(email);
    }

    public void typePassword(String password){
        passwordInput.sendKeys(password);
    }

    public void click(){
        button.click();
    }

    public WebElement getErrorMessage(){
       return errorMessage;
    }
}
