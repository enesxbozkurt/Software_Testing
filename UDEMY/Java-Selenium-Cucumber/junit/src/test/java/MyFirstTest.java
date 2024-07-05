import io.github.bonigarcia.wdm.WebDriverManager;
import org.junit.*;
import org.junit.jupiter.api.RepeatedTest;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

import java.time.Duration;

public class MyFirstTest {

    static WebDriver driver;
    @BeforeClass
    public static void hazirlik(){
        WebDriverManager.chromedriver().setup();
        driver=new ChromeDriver();
        driver.manage().window().maximize();
        driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(10));
    }
    @RepeatedTest(3) //Testin kaç kere tekrar edileceğini belirler
    @Test
    public void baslikDogruMu(){
        driver.get("https://booldesk.dev.local");
        String expectedData="BoolDesk";
        String actualData= driver.getTitle();
        Assert.assertEquals(expectedData,actualData);
    }
    @Ignore("Bu teste gerek yok fakat kalması iyi olur")
    @Test(timeout = 4000) //timeout test belirlenen saniyede gerçekleşmiyor ise başarısız olarak algıla
    public void beklenenVarMı(){
        driver.get("https://booldesk.dev.local");
        String expectedData="BoolDesk";
        String actualData= driver.getTitle();
        Assert.assertTrue(actualData.contains(expectedData));
    }
    @AfterClass
    public static void kapanis(){
        driver.quit();
    }




    /*@BeforeClass
    public static void beforeMyClass(){
        System.out.println("Before Test");
    }

    @Before
    public void beforeMyTest(){
        System.out.println("Before Test");
    }
    @Test
    public void myTest1(){
        System.out.println("Test 1");
    }
    @Test
    public void myTest2(){
        System.out.println("Test 2");
    }
    @After
    public void afterMyTest(){
        System.out.println("After Test");
    }
    @AfterClass
    public static void afterMyClass(){
        System.out.println("After Test");
    }*/
}
