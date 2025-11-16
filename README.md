                                                                                                                      
                                                                                                                      
            CCCCCCCCCCCCC   SSSSSSSSSSSSSSS EEEEEEEEEEEEEEEEEEEEEE    444444444         444444444  555555555555555555 
         CCC::::::::::::C SS:::::::::::::::SE::::::::::::::::::::E   4::::::::4        4::::::::4  5::::::::::::::::5 
       CC:::::::::::::::CS:::::SSSSSS::::::SE::::::::::::::::::::E  4:::::::::4       4:::::::::4  5::::::::::::::::5 
      C:::::CCCCCCCC::::CS:::::S     SSSSSSSEE::::::EEEEEEEEE::::E 4::::44::::4      4::::44::::4  5:::::555555555555 
     C:::::C       CCCCCCS:::::S              E:::::E       EEEEEE4::::4 4::::4     4::::4 4::::4  5:::::5            
    C:::::C              S:::::S              E:::::E            4::::4  4::::4    4::::4  4::::4  5:::::5            
    C:::::C               S::::SSSS           E::::::EEEEEEEEEE 4::::4   4::::4   4::::4   4::::4  5:::::5555555555   
    C:::::C                SS::::::SSSSS      E:::::::::::::::E4::::444444::::4444::::444444::::4445:::::::::::::::5  
    C:::::C                  SSS::::::::SS    E:::::::::::::::E4::::::::::::::::44::::::::::::::::4555555555555:::::5 
    C:::::C                     SSSSSS::::S   E::::::EEEEEEEEEE4444444444:::::4444444444444:::::444            5:::::5
    C:::::C                          S:::::S  E:::::E                    4::::4            4::::4              5:::::5
     C:::::C       CCCCCC            S:::::S  E:::::E       EEEEEE       4::::4            4::::4  5555555     5:::::5
      C:::::CCCCCCCC::::CSSSSSSS     S:::::SEE::::::EEEEEEEE:::::E       4::::4            4::::4  5::::::55555::::::5
       CC:::::::::::::::CS::::::SSSSSS:::::SE::::::::::::::::::::E     44::::::44        44::::::44 55:::::::::::::55 
         CCC::::::::::::CS:::::::::::::::SS E::::::::::::::::::::E     4::::::::4        4::::::::4   55:::::::::55   
            CCCCCCCCCCCCC SSSSSSSSSSSSSSS   EEEEEEEEEEEEEEEEEEEEEE     4444444444        4444444444     555555555     
 

# CSE445 Assignment 5 

### Author - Gage Stenhouse



## Overview

This project is a modular, service-oriented ASP.NET Web Forms application demonstrating multi-tier design, 
user authentication, service consumption, DLL integration, error logging, and file storage. The landing page (Default.aspx)
serves the functionality of TryIt as well as service directory (as stated in Q1a). All functions embedded currently into
the single page, no external TryIt pages needed. 


The system includes:


⦁	A SHA-256 cryptography service (via DLL)

⦁	A file storage service

⦁	A login system with Member/Staff roles

⦁	Global error logging using Global.asax

⦁	A service directory showing the architecture’s components

⦁	Protected pages for Member and Staff roles


## Project Structure



Pages:


Default.aspx 

⦁	Houses all implemented functions (and simple demo/test cases for grader visualization)

⦁	Navigation to Member and Staff pages (placeholders with minimal functionality currently)

⦁	Service Directory with brief descriptions, arguments, file typing, resource usage

⦁	Brief description of the app and its current usage/implements



Login.aspx

⦁	User Authentication (currently hardcoded accounts)

⦁	Redirects to Member or Staff page based on user selection (Default.aspx)

⦁	Back to home function to return to Default.aspx



Member.aspx

⦁	Simple placeholder for basic testing of login process

⦁	Logout and back to home buttons for page exiting



Staff.aspx

⦁	Simple placeholder for basic testing of login process

⦁	Logout and back to home buttons for page exiting

⦁	"View Error Logs" as a simple demo of Global.asax session info storage
	as well as a small insight into some of the future Staff functionality to come



Core Functions:



⦁	CryptoUtils (DLL) 

	Method: ComputeSHA256(string input) -> string
	Computes hashing (as currently demoed in Default.aspx), as well as implements 
	encryption and decryption for later secure data storage implement



⦁	StorageService 

	Method: StoreFile(string url) -> string
	Downloads a file from a provided URL, stores under ~/UploadedFiles/, returns link to file
	Will be used for the completed product, image manipulation, tagging/description, storage and viewing.





⦁	Application_Error

	Added in Global.asax, gets new exception throws, appends to error log for Staff viewing
	Induced for demo purposes on Default.aspx and outcome viewable in Staff.aspx (once logged in)



Service Directory:

Displayed on landing page (Default.aspx)

Provided Components:

⦁	Provider 
⦁	Component Name
⦁	File/Type (ASPX, DLL, CS class)
⦁	Description
⦁	Resources used (DLLs, methods, pages)



Project Files (and their accompanying .cs/.designers when necessary)



1. Default.aspx
2. ErrorLog.aspx
3. Global.asax
4. Login.aspx
5. LoginWindow.ascx
6. Member.aspx
7. Staff.aspx
8. StorageService.asmx
9. Web.config
10. CryptoUtils.cs
11. App\_Data
	ErrorLog.txt

12. UploadedFiles
	(stored files in local testing)

13. Packages/bin/obj/Properties




## Future Implements


XML storage for user data - Staff and Member


Fully integrated services including:



⦁	Image Viewing (once stored view StoreFile)



⦁	Image manipulation 

    Cropping/resizing

    Color/saturation adjustments

    Potentially implementing more complex image modification effects (blur, sharpen, noise reduction, preset color filter overlays)

    Going to research more on possible ASCII art conversion for images oploaded (free/reliable webservice implements)



⦁	Image Tagging

	Descriptions

	Keyword Tagging

	Filing/organization



⦁	Image showcasing/displaying

	user avatars/pfp (minor priority just something cool I want to add)

	simple portfolio/showcase UI with navigable folders/libraries of images



** Potentially ** adding a reverse image search/similarity function
Heavily depends on if I can make use of a free/open API with a large enough query limit
so as to not lose access following testing, so as to keep functionality for demo/grading	
Currently researching/testing:  OpenWeb Ninja Reverse Image Search
