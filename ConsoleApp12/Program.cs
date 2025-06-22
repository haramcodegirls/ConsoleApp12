

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumLoginTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Navigate to the login page
                driver.Navigate().GoToUrl("https://webconnect.zrg.com/CmmsFoBo/Account/Login.aspx");

                // Enter username
                IWebElement userNameBox = wait.Until(driver => driver.FindElement(By.Id("txtUserName")));
                userNameBox.Clear();
                userNameBox.SendKeys("fahad");

                // Enter password
                IWebElement passwordBox = wait.Until(driver => driver.FindElement(By.Id("txtPassword")));
                passwordBox.Clear();
                passwordBox.SendKeys("Pso123++");

                // Click login button
                Console.WriteLine("Clicking login button...");
                IWebElement loginButton = wait.Until(driver => driver.FindElement(By.Id("btnLogin")));
                loginButton.Click();

                // Wait for the next page and click Add New
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    Console.WriteLine("Alert text: " + alert.Text);
                    alert.Accept(); // Accepts the alert (clicks OK)
                }
                catch (NoAlertPresentException)
                {
                    // No alert to handle, proceed normally
                }
                IWebElement addComp = wait.Until(driver => driver.FindElement(By.Id("btnAddNew")));
                addComp.Click();
                // Optional: switch to iframe if searchBar is inside one
                // driver.SwitchTo().Frame("iframeId"); // 🔁 Uncomment and replace with actual iframe name or ID if needed

                Thread.Sleep(2000); // Optional: allow iframe or JS content to fully load

                Console.WriteLine("Entering Customer Code...");

                // Prefer By.Id if available
                IWebElement custCode = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("searchBar")));
                custCode.Clear();
                custCode.SendKeys("654321");

                // Click the search button
                Console.WriteLine("Clicking search button...");
                IWebElement search = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));
                search.Click();


                ////Optional: switch to iframe if searchBar is inside one
                //     driver.SwitchTo().Frame("iframeId"); // uncomment and replace if needed
                //    Thread.Sleep(2000); // Wait for iframe to load, adjust as necessary

                //    // Interact with search bar
                //    Console.WriteLine("Entering Customer Code...");
                //    IWebElement custCode = wait.Until(driver => driver.FindElement(By.XPath("//input[@placeholder='e.g: XXXXX']")));
                //    //IWebElement custCode = wait.Until(driver => driver.FindElement(By.XPath("//input[contains(@class, 'form-control')]")));


                //    //IWebElement custCode = wait.Until(driver => driver.FindElement(By.Id("searchBar")));
                //    custCode.Clear();
                //    custCode.SendKeys("654321");

                //    //Optionally: submit or click search
                //    IWebElement search = wait.Until(driver => driver.FindElement(By.Id("btnSearch")));
                //    search.Click();

                // Optional: Switch back to default content if you switched to iframe
                // driver.SwitchTo().DefaultContent();

                Console.WriteLine("Search bar automation completed.");

                Thread.Sleep(2000);

                // Enter Complainer Name
                IWebElement complainerName = wait.Until(driver => driver.FindElement(By.Id("txtComplainerName")));
                complainerName.Clear();
                complainerName.SendKeys("haram");

                Thread.Sleep(2000);
                // Enter Complainer Mobile Number
                IWebElement complainerMobile = wait.Until(driver => driver.FindElement(By.Id("txtComplainerMobile")));
                complainerMobile.Clear();
                complainerMobile.SendKeys("03331412356");

                Thread.Sleep(2000);
                // Select Equipment Name
                IWebElement dropdownElement = wait.Until(driver => driver.FindElement(By.Id("sltEquipmentName")));
                SelectElement equipmentNameDropdown = new SelectElement(dropdownElement);
                equipmentNameDropdown.SelectByText("Dispensing Unit");

                Thread.Sleep(2000);
                // Select Equipment Type
                IWebElement dropdownElement1 = wait.Until(driver => driver.FindElement(By.Id("sltEquipmentType")));
                SelectElement equipmentTypeDropdown = new SelectElement(dropdownElement1);
                equipmentTypeDropdown.SelectByText("Dispensing Unit");

                Thread.Sleep(2000);
                // If using a select2-style searchable dropdown for complaint type
                IWebElement select2Dropdown = wait.Until(driver => driver.FindElement(By.CssSelector(".select2-selection")));
                select2Dropdown.Click();

                Thread.Sleep(2000);
                // After clicking, wait for the input field to appear and type the option
                IWebElement searchInput = wait.Until(driver => driver.FindElement(By.XPath("//input[@class='select2-search__field']")));
                searchInput.SendKeys("Adjuster pulley not working");
                searchInput.SendKeys(Keys.Enter);

                Thread.Sleep(4000);

                // Wait until the dropdown is visible
                IWebElement equipmentMakeElement = wait.Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("txtEquipmentMakeName"))
                );

                // Create SelectElement from it
                SelectElement equipmentMakeDropdown = new SelectElement(equipmentMakeElement);

                // Select the desired option
                equipmentMakeDropdown.SelectByText("TATSUNO");

                // Optional: brief wait to observe or wait for dependent fields
                Thread.Sleep(4000);


                ////Wait for Equipment Make dropdown to appear

                //IWebElement equipmentMakeElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtEquipmentMakeName")));
                //SelectElement equipmentMakeDropdown = new SelectElement(equipmentMakeElement);
                //equipmentMakeDropdown.SelectByText("TATSUNO");
                //Thread.Sleep(4000);
                Thread.Sleep(4000);
                Console.WriteLine("Waiting for FXA Code input...");
                IWebElement fxaCodeInput = wait.Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("txtFXACode"))
                );

                fxaCodeInput.Clear();
                fxaCodeInput.SendKeys("53245678");
                Thread.Sleep(4000);

                //// Wait until FXA Code input appears and is populated or visible
                //IWebElement fxaCodeInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtFXACode")));
                //fxaCodeInput.Clear();
                //fxaCodeInput.SendKeys("53245678");
                Thread.Sleep(9000);

                //// Wait until Launch button is enabled and clickable
                //IWebElement launchButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnAddComplain")));
                //wait.Until(driver => launchButton.Enabled);
                //launchButton.Click();

                Console.WriteLine("Waiting for Launch button...");
                IWebElement launchButton = wait.Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnAddComplain"))
                );

                launchButton.Click();
                Console.WriteLine("Launch button clicked.");

                Console.WriteLine("Launch button clicked.");

                // ✅ Handle JavaScript alert (e.g., "New ticket registered successfully")
                try
                {
                    WebDriverWait alertWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    alertWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

                    IAlert popup = driver.SwitchTo().Alert();
                    Console.WriteLine("📢 Alert says: " + popup.Text);
                    popup.Accept(); // ✅ Click OK
                    Console.WriteLine("✅ Alert accepted (OK clicked).");
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine("❌ No alert appeared after submitting.");
                }


                // ✅ Alert accepted (OK clicked).
                Console.WriteLine("✅ Alert accepted (OK clicked).");

                //// ✅ Now perform logout
                //IWebElement menuButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[title='Menu']")));
                //menuButton.Click();

                //IWebElement logoutLink = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("lnkLogout")));
                //logoutLink.Click();

                //Console.WriteLine("✅ Logout successful.");
                Thread.Sleep(4000);

                // ✅ Copy Ticket ID
                //string ticketID = wait.Until(d => d.FindElement(By.Id("lblTicketID"))).GetAttribute("value");
                //Console.WriteLine("📄 Ticket ID: " + ticketID);
                // ✅ Save ticket ID after alert
                string ticketID = wait.Until(d => d.FindElement(By.Id("lblTicketID"))).GetAttribute("value");
                Console.WriteLine("📄 Ticket ID saved at runtime: " + ticketID);

                Thread.Sleep(4000);
                // ✅ Now perform logout
                IWebElement menuButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[title='Menu']")));
                menuButton.Click();

                IWebElement logoutLink = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("lnkLogout")));
                logoutLink.Click();

                Console.WriteLine("✅ Logout successful.");
               

                // ✅ Login Again
                Thread.Sleep(4000);
                IWebElement userNameBox2 = wait.Until(driver => driver.FindElement(By.Id("txtUserName")));
                userNameBox2.Clear();
                userNameBox2.SendKeys("fahad");

                IWebElement passwordBox2 = wait.Until(driver => driver.FindElement(By.Id("txtPassword")));
                passwordBox2.Clear();
                passwordBox2.SendKeys("Pso123++");

                IWebElement loginButton2 = wait.Until(driver => driver.FindElement(By.Id("btnLogin")));
                loginButton2.Click();

                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    Console.WriteLine("Alert text: " + alert.Text);
                    alert.Accept();
                }
                catch (NoAlertPresentException) { }

              Thread.Sleep(4000);
                // ✅ Click View Existing Complaints
                Thread.Sleep(4000);
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnViewExisting"))).Click();
                Console.WriteLine("✅ Clicked 'View Existing Complaints'.");
                Thread.Sleep(4000);

                // ✅ Paste saved Ticket ID into search field
                IWebElement searchInputField = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[type='search'][aria-controls='tblTicket']")));
                searchInputField.Clear();
                searchInputField.SendKeys(ticketID); // 💾 use the ticketID saved earlier
                Console.WriteLine("🔎 Pasted Ticket ID into search: " + ticketID);
                Thread.Sleep(4000);
                // ✅ Wait for the link and click it
                By ticketLinkSelector = By.XPath($"//a[@class='routeWithCaseID' and text()='{ticketID}']");
                IWebElement ticketLink = wait.Until(ExpectedConditions.ElementToBeClickable(ticketLinkSelector));
                ticketLink.Click();
                Console.WriteLine("✅ Clicked on ticket link: " + ticketID);



                Thread.Sleep(4000); 
                // ✅ Step 1: Click on the "Process" tab
                IWebElement processTab = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Process-tab")));
                processTab.Click();
                Console.WriteLine("✅ 'Process' tab clicked.");

                // Optional wait if content loads dynamically
                Thread.Sleep(4000);

                // ✅ Step 2: Click on the "Decline" button
                IWebElement declineButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnDecline")));
                declineButton.Click();
                Console.WriteLine("✅ 'Decline' button clicked.");

                Thread.Sleep(4000); // Optional wait for the decline modal to appear

                // 📝 Step 3: Enter text in RTS Notes
                IWebElement rtsNotes = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtRTSNotes")));
                rtsNotes.Clear();
                rtsNotes.SendKeys("tested text");
                Console.WriteLine("📝 'tested text' entered in RTS Notes.");
                Thread.Sleep(4000); // Optional wait for the decline modal to appear
                // 💾 Step 4: Click on the "Save" button
                IWebElement saveDeclineBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnUpdateDecline")));
                saveDeclineBtn.Click();
                Console.WriteLine("💾 'Save' button clicked after Decline.");

                Thread.Sleep(4000);
                try
                {
                    WebDriverWait alertWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    alertWait.Until(ExpectedConditions.AlertIsPresent());

                    IAlert popup = driver.SwitchTo().Alert();
                    Console.WriteLine("📢 Alert after Save: " + popup.Text);
                    popup.Accept(); // ✅ Click OK
                    Console.WriteLine("✅ Final alert accepted.");
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine("❌ No alert appeared after Save.");
                }
                Thread.Sleep(4000);
                try
                {
                    WebDriverWait alertWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                    // ✅ First alert
                    alertWait.Until(ExpectedConditions.AlertIsPresent());
                    IAlert firstAlert = driver.SwitchTo().Alert();
                    Console.WriteLine("📢 First Alert: " + firstAlert.Text);
                    firstAlert.Accept();
                    Console.WriteLine("✅ First alert accepted.");

                    Thread.Sleep(1000); // Optional small wait

                    // ✅ Second alert (if any)
                    alertWait.Until(ExpectedConditions.AlertIsPresent());
                    IAlert secondAlert = driver.SwitchTo().Alert();
                    Console.WriteLine("📢 Second Alert: " + secondAlert.Text);
                    secondAlert.Accept();
                    Console.WriteLine("✅ Second alert accepted.");
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine("❌ No further alert appeared.");
                }




                Thread.Sleep(4000);

                // ✅ Logout current user
                IWebElement menuBtn2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[title='Menu']")));
                menuBtn2.Click();

                IWebElement logoutLink2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("lnkLogout")));
                logoutLink2.Click();
                Console.WriteLine("🔁 Logged out after Decline flow.");
                Thread.Sleep(4000);

                //// ✅ Login with new user credentials
                //Thread.Sleep(3000);
                //IWebElement userBoxNew = wait.Until(driver => driver.FindElement(By.Id("txtUserName")));
                //userBoxNew.Clear();
                //userBoxNew.SendKeys("alsonstatsunokhi");
                //Thread.Sleep(4000);

                //IWebElement passBoxNew = wait.Until(driver => driver.FindElement(By.Id("txtPassword")));
                //passBoxNew.Clear();
                //passBoxNew.SendKeys("Pso123++");
                //Thread.Sleep(4000);

                //IWebElement loginBtnNew = wait.Until(driver => driver.FindElement(By.Id("btnLogin")));
                //loginBtnNew.Click();
                //Console.WriteLine("🔐 Logged in as alsonstatsunokhi");

                //try
                //{
                //    IAlert alert = driver.SwitchTo().Alert();
                //    Console.WriteLine("📢 Login Alert: " + alert.Text);
                //    alert.Accept();
                //}
                //catch (NoAlertPresentException) { }

                //// ✅ View Existing Complaints
                //Thread.Sleep(4000);
                //wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnViewExisting"))).Click();
                //Console.WriteLine("✅ Viewing complaints");
                //Thread.Sleep(4000);

                //// ✅ Search ticket ID 572489
                //string fixedTicketId = "572489";
                //IWebElement searchInput1 = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[type='search'][aria-controls='tblTicket']")));
                //searchInput.Clear();
                //searchInput.SendKeys(fixedTicketId);
                //Thread.Sleep(4000);

                //// ✅ Click ticket link
                //By ticketLinkSelector2 = By.XPath($"//a[@class='routeWithCaseID' and text()='{fixedTicketId}']");
                //IWebElement ticketLink2 = wait.Until(ExpectedConditions.ElementToBeClickable(ticketLinkSelector2));
                //ticketLink2.Click();
                //Console.WriteLine("✅ Opened ticket ID: " + fixedTicketId);
                //Thread.Sleep(4000);

                //// ✅ Click Process tab
                //IWebElement processTab2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Process-tab")));
                //processTab2.Click();
                //Console.WriteLine("🔁 Clicked Process tab for ticket");
                //Thread.Sleep(4000);

                //// ✅ Click Resolved button
                //IWebElement resolveButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnResolve")));
                //resolveButton.Click();
                //Console.WriteLine("✅ Clicked 'Resolved'");
                //Thread.Sleep(4000);

                //// ✅ Enter 'tested' in textarea
                //IWebElement resolveTextarea = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txtResolve")));
                //resolveTextarea.Clear();
                //resolveTextarea.SendKeys("tested");
                //Console.WriteLine("📝 Wrote 'tested' in resolve notes");
                //Thread.Sleep(4000);

                //// ✅ Click Save button
                //IWebElement resolveSaveBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnResolveUpdate")));
                //resolveSaveBtn.Click();
                //Console.WriteLine("💾 Clicked Save after Resolved");
                //Thread.Sleep(4000);

                //// ✅ Handle alert(s)
                //try
                //{
                //    WebDriverWait alertWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //    alertWait.Until(ExpectedConditions.AlertIsPresent());
                //    IAlert popup = driver.SwitchTo().Alert();
                //    Console.WriteLine("📢 Alert after Resolved Save: " + popup.Text);
                //    popup.Accept();
                //    Console.WriteLine("✅ Final Resolved alert accepted.");
                //    Thread.Sleep(4000);

                //    // Check for second alert again
                //    alertWait.Until(ExpectedConditions.AlertIsPresent());
                //    IAlert secondPopup = driver.SwitchTo().Alert();
                //    Console.WriteLine("📢 Second Alert: " + secondPopup.Text);
                //    secondPopup.Accept();
                //    Console.WriteLine("✅ Second alert accepted.");
                //}
                //catch (WebDriverTimeoutException)
                //{
                //    Console.WriteLine("❌ No further alert after Resolved Save.");
                //}





























            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
            }
            //finally
            //{
            //    // Wait to see result before quitting
            //    System.Threading.Thread.Sleep(3000);
            //    driver.Quit();
            //}
        }
    }
}


