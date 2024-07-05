package org.example;


import io.github.bonigarcia.wdm.WebDriverManager;
import org.apache.commons.io.FileUtils;
import org.openqa.selenium.OutputType;
import org.openqa.selenium.TakesScreenshot;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

import java.io.File;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class ScreenshotTest {
    public WebDriver driver;  // Sınıf düzeyinde ve herkese açık driver

    public void setUp() {
        WebDriverManager.chromedriver().setup();
        driver = new ChromeDriver();
        driver.get("https://booldesk.dev.local");
    }

    public void tearDown() {
        if (driver != null) {
            driver.quit();
        }
    }

    // Screenshot alan metot
    public void takeScreenshot(WebDriver driver, File scrFile, File destFile) {
        TakesScreenshot scrShot = ((TakesScreenshot) driver);
        scrFile = scrShot.getScreenshotAs(OutputType.FILE);
        try {
            FileUtils.copyFile(scrFile, destFile);
            System.out.println("Screenshot saved to " + destFile.getAbsolutePath());
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public void testExample1() {
        // Test işlemleri


        // Ekran görüntüsü alma
        String timestamp = new SimpleDateFormat("yyyyMMddHHmmss").format(new Date());
        File scrFile = new File("");
        File destFile = new File("C:\\Users\\enesxbozkurt\\Downloads\\screenshot_" + timestamp + ".png");
        takeScreenshot(driver, scrFile, destFile);
    }

    public void testExample2() {
        // Test işlemleri
        System.out.println("Running testExample2");

        // Ekran görüntüsü alma
        String timestamp = new SimpleDateFormat("yyyyMMddHHmmss").format(new Date());
        File scrFile = new File("");
        File destFile = new File("C:\\Users\\enesxbozkurt\\Downloads\\screenshot_" + timestamp + ".png");
        takeScreenshot(driver, scrFile, destFile);
    }
}//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {

        }
    }
}