# Eau Claire's Salon

#### A website to track salon stylists and their clients, 18-Oct-2019

#### By **Christine Frank**

## Description

This is a MVC website created to allow a business owner to track stylists and their clients. The user can add new stylists, view existing stylists, and see their clients. The user can additionally add new clients for existing stylists, or see existing client details and stats under the applicable stylist.

## Setup/Installation Requirements

* Clone this repository to your desktop
* Install .NET Core SDK (if not already installed)
* Install REPL *dotnet script* (if not already installed)
    * Command: 'dotnet tool install -g dotnet-script'
* Install MySql Server and WorkBench (if not already installed)
* Open a new Command Terminal and start MySql Server if not already running
    * Command: mysql -uroot -p{EnterYourPassword}

* In the main project folder of the local repository, create a file "appsettings.json" and add the following content:

```JSON
{
  "ConnectionStrings": 
  {
    "DefaultConnection": "Server=localhost;Port=3306;database=christine_frank;uid=root;pwd=epicodus;"
  }
}
```
* Open MySql WorkBench and go to the Administrator tab. Under Management, select "Data Import/Restore"
* In the Data Import window, under Import Options:
  * Select the "Import from Self-Contained File" and then route to the Project Solution Folder and select the "structure.sql" file.
  * Create a new schema named "christine_frank"
  * Under the 'Select Database Objects to Import', select the dropdown option "Dump Structure Only"
  * Press 'Start Import' button
* Confirm successful import
  * If unsuccessful execute the following MySql command in a new query:
  ```SQL
  -- -----------------------------------------------------
  -- Schema christine_frank
  -- -----------------------------------------------------
  CREATE SCHEMA IF NOT EXISTS `christine_frank` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
  USE `christine_frank` ;

  -- -----------------------------------------------------
  -- Table `christine_frank`.`clients`
  -- -----------------------------------------------------
  CREATE TABLE IF NOT EXISTS `christine_frank`.`clients` (
    `ClientId` INT(11) NOT NULL AUTO_INCREMENT,
    `StylistId` INT(11) NOT NULL,
    `FirstName` VARCHAR(255) NULL DEFAULT NULL,
    `LastName` VARCHAR(255) NULL DEFAULT NULL,
    `StartDate` DATETIME NULL DEFAULT NULL,
    `PreferredAppointmentWeekDay` INT(11) NULL DEFAULT NULL,
    `PreferredAppointmentTime` VARCHAR(255) NULL DEFAULT NULL,
    PRIMARY KEY (`ClientId`))
  ENGINE = InnoDB
  AUTO_INCREMENT = 11
  DEFAULT CHARACTER SET = utf8mb4
  COLLATE = utf8mb4_0900_ai_ci;

  -- -----------------------------------------------------
  -- Table `christine_frank`.`stylists`
  -- -----------------------------------------------------
  CREATE TABLE IF NOT EXISTS `christine_frank`.`stylists` (
    `StylistId` INT(11) NOT NULL AUTO_INCREMENT,
    `FirstName` VARCHAR(255) NULL DEFAULT NULL,
    `LastName` VARCHAR(255) NULL DEFAULT NULL,
    `PriceRating` INT(11) NULL DEFAULT NULL,
    `StartDate` DATETIME NULL DEFAULT NULL,
    PRIMARY KEY (`StylistId`))
  ENGINE = InnoDB
  AUTO_INCREMENT = 3
  DEFAULT CHARACTER SET = utf8mb4
  COLLATE = utf8mb4_0900_ai_ci;

  ```

* Open a new Command Terminal and route to the main project folder of the local repository (//Desktop/EauClairesSalon.Solution/EauClairesSalon)
* Enter command 'dotnet run' into the Terminal
* Open a new browser and enter 'http://localhost:5000/'

## Known Bugs

None known at this time.

## Support and contact details

Find a bug?! Add an issue to the GitHub Repo.
Repo: https://github.com/christinelfrank16/EauClairesSolution.Solution

Other Contact
Email: christine.braun13@gmail.com
LinkedIn: https://www.linkedin.com/in/christine-frank/

## Application Specifications

* The user can view the splashpage
* The user can route to a stylists' summary page - view list of all stlylists
* The user can add a new stlylist
* The user routes to the stylist index after adding a new stylist
* The user can view existing stylist's client list and stylist details
* The user can add a new client to a stylist
* The user can NOT add a new client if no stylist is selected
* The user can view existing client details

## Technologies Used

* C#
* MVC
* Entity Framework

### License

*This application is licensed under the MIT license*

Copyright (c) 2019 **Christine Frank**