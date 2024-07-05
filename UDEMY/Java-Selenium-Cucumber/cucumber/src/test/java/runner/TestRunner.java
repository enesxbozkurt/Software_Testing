package runner;

import io.cucumber.junit.Cucumber;
import io.cucumber.junit.CucumberOptions;
import org.junit.runner.RunWith;

@RunWith(Cucumber.class)
@CucumberOptions(
        features = "src/test/jaba/features",
        glue = "StepDefinitions",
        plugin = {"pretty","html:target/cucumber-html-report"}
)


public class TestRunner {

}
