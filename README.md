# Sparta Global - Trainee Tracker Group 1

## Group Members
Adam Reed  
Jai Bharat Kothari  
Mark William Pollard  
Michael Bonardi Davies  
Robert Green  
Syed Ahmed  
Tudor Ionut Biragau  
William Stickler  

---
<br>

## Table Of Contents
- [Overview](#overview)
- [Getting Started](#getting-started)
- [The Design Process](#the-design-process)
- [How To Use](#how-to-use)
- [API Documentation](#api-documentation)

---
<br>

## Overview
This repository contains the final project for the Sparta Global C# Development Stream "Engineering 128 & 151" group 1. The aim of this project is to use ASP.NET Core to create a Web App and an API.

## Getting Started
???

## The Design Process
???

## How To Use The Website

The below documents the walkthrough of the webpages, beginning with an account setup and profile editing, then the pages each user role will be able to access and use.

## Register

Upon starting the web application, a user without an account is greeted with a welcome message and a request with links to either login or register. The user can also click the register or login buttons in the top right corner. The login link and button directs the user to the login page and the register link and button directs them to a register page.
![Welcome Page](./ImagesForReadme/WelcomePage.png)

When the user is on the register page, they can enter their details and click register as long as their details are valid. This will take them to the trainee home page as this is the default role. Role promotion is handled by admins.
![Register Page](./ImagesForReadme/RegisterPage.png)

If the email or passwords are incorrect, they will be given error messages.
![Email error](./ImagesForReadme/InvalidEmail.png)
![Password missmatch](./ImagesForReadme/PasswordMissmatch.png)
![Password incorrect](./ImagesForReadme/PasswordIncorrect.png)

## Login
On the login page a user is given instructions to login. There is are email and password fields they use to enter their login details. They are given the option to have the web application remember their login details for next time so they do not need to login again. This is enabled by using the checkbox. The user can then click the login button which, if the details are correct will direct them to the home page of their account's role. They can also click the "Register as a new user" link to take them to the register page. The forgot password and resend email confirmation links will take them to their respective pages, but these functions have **not yet been implemented**.
![Login Page with correct details](./ImagesForReadme/LoginCorrect.png)

If the user entered incorrect details and clicked log in, they would be provided with an error message.
![Login Page with incorrect details](./ImagesForReadme/LoginIncorrect.png)

## Profile and Logout
A user, once logged in, can access their profile by clicking their email in the top right in any page. This will display a page that has 3 options: Profile; Email; Password. The profile tab allows a user to edit their first and last name as well as their phone number. The user must click the edit button to unlock the fields for editing, as this prevents accidental editing. After editing, to confirm changes, the user has to click the save button. This notifies the user of the update. The user can also click the API key button which copies the the user ID to the clipboard. The email tab functionality is **not yet implemented.**
![Profile Edit Tab](./ImagesForReadme/ProfileEditTab.png)

On the password tab, a user can change their password by entering their current password, then entering and rentering the new password. The user must click update password to save the change.
![Change Password Tab](./ImagesForReadme/PasswordTab.png)

## Trainee
**INDEX PAGE:**

When logged in, a trainee will see an index page of their weeks. If it is a new user, there will be no weeks and the only option available to them will be to create a new week. The trainee can see each week's start date and a summary of their skill level in each category. They also have details, edit and delete buttons available to them. The details button will direct them to a page listing the information of that week. The edit button will direct them to a page where they can edit that specific week's details. The delete button will not direct them to a page, but instead display a prompt asking if they are sure they want to delete the selected week. If a new week is to be created, a trainee can click the create new button, where they will be directed to a create page.
![Week Index Page](./ImagesForReadme/TraineeIndexPage.png)
![Week Index Page with delete prompt](./ImagesForReadme/TraineeIndexPageDeletePrompt.png)

**CREATE PAGE:**

On the create page, a user can enter text for the start, stop and continue categories. They can also use a calendar view to select when the week starting, add a link to the respective week's repository and use the drop down to select a skill level for both categories. If they reached this page by accident or do not wish to create a new week, they can click the back to list button to return to the index page. The create button will add the week and the information entered to the database, and direct the trainee back to the index page where they will see the week added.
![Create Week Page](./ImagesForReadme/CreateWeekPage.png)

**DETAILS PAGE:**

This page allows the user to view the details of a chosen week. It displays the week start, a link to the repository of that week the user can click, and the information for the start, stop, contoinue and skills categories. From here the user can click back to list to return to the index page, or click edit to be taken to the edit page for the week displayed.
![Week Details Page](./ImagesForReadme/WeekDetailsPage.png)

**EDIT PAGE:**

The edit page is functionally similar to the create page, as data can be entered by the trainee, but data from the existing week they wish to edit will appear and they can alter it. The back to list button is here again incase the user got to the page by accident or no longer needs to edit the week. The save button will change the data for the selected week and update the database. This button will then direct them to the details page of the week they edited so they can see the changes.
![Week Edit Page](./ImagesForReadme/WeekEditPage.png)

## Trainer
**INDEX PAGE:**

When logged in, a trainer will see a list of all trainees. For each trainee, they can view their details or tracker by clicking the respective buttons. On clicking the details button, they are directed to the details page. When the tracker button is clicked they are directed to the tracker page to view their weekly reflectives.
![Trainee Index Page](./ImagesForReadme/TrainerIndexPage.png)

**DETAILS PAGE:**

On the details page, a trainer can see all necessary information on the trainee, including name and email. The trainer can then click the back to list button when finished viewing the details, which will bring them back to the index page.
![Trainee Details Page](./ImagesForReadme/TraineeDetailsPage.png)

**TRACKER PAGE:**

When viewing the tracker page, a trainer can see the weekly reflectives of the trainee they selected and a small summary of the skill level they have placed themselves at. They can also click the week details button to view all information of a specific week reflective. A trainer can click back to list to return to the index page.
![Tracker Details Page](./ImagesForReadme/TrackerDetails.png)

**WEEK DETAILS PAGE:**

On the week details page, a trainer will see the start, stop and continue categories and the information a trainee has added to them, as well as the skill level they feel they are at for the technical and consultant categories. A link to the trainee's repository of that week can be clicked to bring the user to the repository page, if the trainee had provided the link when filling out that weeks reflective. When done viewing, a trainer can click back to list to return to the index page.
![Trainee-Week Details Page](./ImagesForReadme/TraineeWeekDetailsPage.png)

## Admin
**INDEX PAGE:**

When logged in, the admin will be directed to the spartans view page where they can see all user accounts.

![Admin Index Page](./ImagesForReadme/AdminIndex.png)

From here they are able to either delete or change the role of the users by clicking the respective buttons. The promote button will direct the admin to a new page, while the delete button will display a prompt. This is to prevent accidental deletion of users. Here the admin can either commit to deleting the user by clicking the delete button, where the user will be removed from the database permanently. They can alternatively click "Close" if deletion is not intended and the prompt is closed.
![Delete Spartan Page](./ImagesForReadme/AdminDeletePrompt.png)

**ROLE PAGE:**

The promote page displays a dropdown menu where the admin can select the role they wish to change the user to. Once selected and the save button has been clicked, the database will update the user's role and the admin will be taken back to the index page. The admin can also go back to the index page if necessary using the back to list button. 
![Promote Spartan Page](./ImagesForReadme/AdminPromotePage.png)

## API Documentation
???
