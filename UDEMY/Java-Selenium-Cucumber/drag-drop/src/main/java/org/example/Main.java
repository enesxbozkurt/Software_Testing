package org.example;

import io.github.bonigarcia.wdm.WebDriverManager;
import org.apache.commons.io.FileUtils;
import org.openqa.selenium.*;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.interactions.Actions;

import javax.swing.*;
import java.io.File;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URL;
import java.sql.DriverManager;
import java.sql.SQLOutput;
import java.time.Duration;
import java.util.Iterator;
import java.util.List;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {

        //dragAndDrop

        WebDriverManager.chromedriver().setup();
        WebDriver driver = new ChromeDriver();
        driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(10));
        driver.manage().window().maximize();

        driver.get("http://www.dhtmlgoodies.com/scripts/drag-drop-custom/demo-drag-drop-3.html");

        WebElement oslo = driver.findElement(By.id("box1"));
        WebElement stockholm = driver.findElement(By.id("box2"));
        WebElement washington = driver.findElement(By.id("box3"));
        WebElement copenhagen = driver.findElement(By.id("box4"));
        WebElement seoul = driver.findElement(By.id("box5"));
        WebElement rome = driver.findElement(By.id("box6"));
        WebElement madrid = driver.findElement(By.id("box7"));

        WebElement norway = driver.findElement(By.id("box101"));
        WebElement swaden = driver.findElement(By.id("box102"));
        WebElement unitedstates = driver.findElement(By.id("box103"));
        WebElement denmark = driver.findElement(By.id("box104"));
        WebElement southkorea = driver.findElement(By.id("box105"));
        WebElement italy = driver.findElement(By.id("box106"));
        WebElement spain = driver.findElement(By.id("box107"));

        Actions actions = new Actions(driver);
        actions.dragAndDrop(oslo, norway).build().perform();
        actions.dragAndDrop(stockholm, swaden).build().perform();
        actions.dragAndDrop(washington, unitedstates).build().perform();
        actions.dragAndDrop(copenhagen, denmark).build().perform();
        actions.dragAndDrop(seoul, southkorea).build().perform();
        actions.dragAndDrop(rome, italy).build().perform();
        actions.dragAndDrop(madrid, spain).build().perform();


        //RightClick
        driver.get("https://demo.guru99.com/test/simple_context_menu.html");

        WebElement rightClickButton = driver.findElement(By.xpath("//*[@id=\"authentication\"]/span"));
        actions.contextClick(rightClickButton).perform();
        try {
            Thread.sleep(2000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
        WebElement copy = driver.findElement(By.cssSelector(".context-menu-icon-copy"));
        copy.click();
        try {
            Thread.sleep(2000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
        driver.switchTo().alert().accept();

        //doubleClick
        WebElement dClickButton = driver.findElement(By.xpath("//button[text()='Double-Click Me To See Alert']"));
        actions.doubleClick(dClickButton).perform();
        driver.switchTo().alert().accept();

        /*mouseMoveToElement
        driver.get("https://www.amazon.com.tr");
        WebElement git=driver.findElement(By.xpath("//*[@id=\"nav-bb-searchbar\"]/form/input"));
        git.click();
        WebElement imlecGelecek=driver.findElement(By.xpath("//*[@id=\"nav-link-accountList\"]/span/span"));
        actions.moveToElement(imlecGelecek).perform();*/

        //File Download
        driver.get("https://demoqa.com/upload-download");
        Actions spaceActions=new Actions(driver);
        spaceActions.sendKeys(Keys.SPACE).perform();
        try {
            Thread.sleep(2000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
        driver.findElement(By.id("downloadButton")).click();
        String downloadPath = "C:\\Users\\enesxbozkurt\\Downloads";
        String fileName = "sampleFile.jpeg";
        try {
            Thread.sleep(2000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
        System.out.println(isFileDownloaded(downloadPath,fileName));


        //popUpMessages
        driver.get("https://demo.guru99.com/test/delete_customer.php");
        driver.findElement(By.name("cusid")).sendKeys("1071");
        driver.findElement(By.name("submit")).click();
        Alert alert=driver.switchTo().alert();
        String alertMessage=driver.switchTo().alert().getText();
        System.out.println(alertMessage);
        try {
            Thread.sleep(2000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
        alert.accept();
        driver.switchTo().alert().accept();


        //tabsSwitch
        driver.get("https://demo.guru99.com/popup.php");
        driver.findElement(By.xpath("//a[text()='Click Here']")).click();
        List<String> tabs=new java.util.ArrayList<>(driver.getWindowHandles());
        driver.switchTo().window(tabs.get(1));

        driver.findElement(By.name("emailid")).sendKeys("denemekeys@gmail.com");
        driver.findElement(By.name("btnLogin")).click();
        driver.close();
        driver.switchTo().window(tabs.get(0));

        //tooltipCheck
        driver.get("https://demo.guru99.com/test/social-icon.html");
        String expectedData="Github";
        WebElement githubButton=driver.findElement(By.xpath("//*[@id=\"page\"]/div[2]/div/a[4]"));
        String actualData=githubButton.getAttribute("title");
        if (expectedData.equals(actualData))
        {
            System.out.println("Tooltip Check True");
        }
        else
        {
            System.out.println("Tooltip Check False");
        }

        //scrollBar
        driver.get("https://chromewebstore.google.com/?hl=en");
        JavascriptExecutor js=(JavascriptExecutor) driver;
        //js.executeScript("window.scrollBy(0,500)");
        //WebElement help=driver.findElement(By.xpath("//*[@id=\"ZCHFDb\"]/footer/ul/li[5]/a"));
        //js.executeScript("arguments[0].scrollIntoView();",help);
        js.executeScript("window.scrollBy(0,document.body.scrollHeight)");

        //takeScreenshot
        TakesScreenshot scrShot=((TakesScreenshot)driver);
        File scrFile=scrShot.getScreenshotAs(OutputType.FILE);
        File destFile=new File("C:\\Users\\enesxbozkurt\\Downloads\\test.png");
        try {
            FileUtils.copyFile(scrFile,destFile);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        //Sayfadaki tüm linklerin doğruluğunu kontrol etme
        /*String url="";
        HttpURLConnection huc=null;
        int respCode=200;
        driver.get(baseUrl);
        List<WebElement> links= driver.findElement(By.tagName("a"));
        Iterator<WebElement> it= links.iterator(); //Döngüye sokabilmek için iterator sınıfına çevrildi

        while(it.hasNext())
        {
            url=it.next().getAttribute("href");
            if (url==null || url.isEmpty())
            {
                System.out.println("Bu bağlantı boş geçildi.");
                continue;
            }
            if (!url.startsWith(baseUrl))
            {
                System.out.println("URL Sayfamıza Ait Değil!");
                continue;
            }
            try {
                huc=(HttpURLConnection)(new URL(url).openConnection());
                huc.setRequestMethod("HEAD");
                huc.connect();
                respCode=huc.getResponseCode();
                if (respCode>=400)
                {
                    System.out.println("Link Arızalı");
                }
                else
                {
                    System.out.println("Geçerli link");
                }
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }*/













    }
    //fileDownload
    public static boolean isFileDownloaded(String downloadPath, String fileName) {
        File file = new File(downloadPath);
        File[] files = file.listFiles();
        for (int i = 0; i <= files.length; i++) {
            if (files[i].getName().equals(fileName)) {
                return true;
            }
        }
        return false;

    }

}
