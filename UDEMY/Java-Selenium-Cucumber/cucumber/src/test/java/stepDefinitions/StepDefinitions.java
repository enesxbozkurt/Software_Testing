package stepDefinitions;

import io.cucumber.java.en.And;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import org.apache.commons.logging.Log;
import org.junit.Assert;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import pages.LoginPage;
import utilities.MyDriver;

import java.sql.DriverManager;
import java.time.Duration;

public class StepDefinitions {

    private WebDriver driver;

    LoginPage loginPage;

    @Given("go to login page")
    public void go_to_login_page() {
        driver.get("https://practicetestautomation.com/practice-test-login/");
    }
    @When("click button")
    public void click_button() {
        loginPage.clickButton();
    }
    @Then("assert to success message")
    public void assert_to_success_message() {
        loginPage.assertToSuccessMessages();
        MyDriver.closeDriver();
    }

    @And("type username {string}")
    public void typeUsername(String username) {
        loginPage=new LoginPage(driver);
        loginPage.setUsername(username);
    }

    @And("type password {string}")
    public void typePassword(String password) {
        loginPage.setPassword("Password123");
    }

    @Given("settingDriver")
    public void settingdriver() {
        driver= MyDriver.getDriver();
        driver.manage().window().maximize();
        driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(10));
    }

    @Given("go to homepage")
    public void goToHomepage() {
        driver.get("https://practicetestautomation.com/");
    }

    @When("wait two seconds")
    public void waitTwoSeconds() {
        try {
            Thread.sleep(2000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
    }

    @Then("see {string} text")
    public void seeText(String text) {
        WebElement hello=driver.findElement(By.className("post-title"));
        String helloText=hello.getText();
        Assert.assertTrue(helloText.equals(text));
    }
}
