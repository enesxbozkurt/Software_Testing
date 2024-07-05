package com.examples.tests;

import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

public class DataProviderExample {
    @DataProvider(name="testdata")
    public Object [][] testdata(){
        return new Object[][]{
                {"Enes", 23},
                {"Ayşe", 20}
        };
    }
    @Test(dataProvider = "testdata")
    public void testMethod(String name, int age) {
        System.out.println("İsim: "+name +" "+"Yaş:"+" "+age);
    }
}
