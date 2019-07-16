#Automation Test Framework Guide


#Framework
- Using BDD framework (SpecFlow) along with selenium.
- selenium 3.5
- SpecFlow 2.4
- Newtonsoft.Json
- Nunit as unit test provider

#Project Structure 


```
Test Automation
 |
 +-ViewerTestFramework 
 |
 |  +-Docs
 |  |
 |  +-features
 |  |  
 |  +-Main
 |  |  |  +--Helpers
 |  |  |  +--Pages
 |  |  |      |
    |  |      +--my_app_page.cs
 |  |
 |  +-StepDefinitions
 |  |  |
 |  |  |  +--my_app_steps.cs
 |  |
 |  +-TestData
 |  |  |
 |  |  |  +--Viewer_test_config.json
 |  |  
 |  +-Utilities
 |  |  |
 |  |  |  +--ActionMethods.cs
 |  |  |  +--BrowserCommands.cs
 |  |  |  +--BrowserWindows.cs
 |  |  |  +--ElementMethoods.cs
 |  |  |  +--Hooks.cs
 |  |  |  +--JsonUtils.cs
 |  |  |  +--Waits.cs
 |  |  |  +--Operations.cs
 |  |  |  +--ImageUtils.cs
 |  |  |  +--HTMLReporting.cs
 |
 |  +-Reports 
              {
                Reporting:- 
				- As we keep on adding the tests to framework it would be tough to handle or monitor the reporting structure of these testcases,
                - so will be working on creating reporting structure and integrated to the framework,
			    - we can generate the HTML report for all the specflow scenarios whether the test case passed / failed  and this can be easily understood by any non technical persons as well
			  }


```
Note: The above Project structure will be little change as going forward

#Features:
- Behavioral driven development scenarios. This is where we write the scenarios using Gherkin language/syntax.
#Helpers:
- Consists of the reusable methods.
- JSONHelper to take care of reusable comeponents.
#Pages:
- Organizing the code on a page wise basis, Contains Page Objects(elements of a page) and their respective action methods
- All the elements pertaining to a web page are listed out in each page class along with the action pertaining to them. 

#StepDefinitions:
- This is where we actually do the code implementation of the Feature file.

#TestData:

#Utilities: 
- Action methods:  Actions related to mouse are being adden this class to handle mouse hover functionality
- Browser commands: All the browser actions like opening a browser and moving forward and backward in browser history by one page are addded in browser commands class
- Browser windows: Methods related to handling multiple windows or tabs added in browserwindows class
- Element methods: Method related to element methods
- Driver objects will be created in Hooks.cs
- Waits.cs consists of wait methods
- ImageUtils to take the screenshot of the failing place of the application.
- HTMLReports : - Converting the image(screenshot taken during test case failure) into a base64Image so that we can inject this as an HTML string into the report 
                - Thus allowing any remote user to view the screenshot when he/she is looking into the HTML report.
- JsonUtils.cs to handle new Json structure
- Operations.cs: will handle operations that will be performed from C#
- App.config: We can run test suites based on environments by just calling key value
              Example: <add key="Env" value="Test" />
                       <add key="Project" value="NA_7.8" />

#Reports: 
- An HTML Report will be generated after test case execution.
- We are using Extent Reports API to generate HTML Report.
- Screenshots for failed test cases are taken and injected into the HTML report.


#To do List:
- SetUp CI/CD pipeline

