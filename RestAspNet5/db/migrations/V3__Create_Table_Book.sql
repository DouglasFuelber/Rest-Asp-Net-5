﻿CREATE TABLE `Book` (
  `Id` INT(10) AUTO_INCREMENT PRIMARY KEY,
  `Author` longtext,
  `LaunchDate` datetime(6) NOT NULL,
  `Price` decimal(65,2) NOT NULL,
  `Title` longtext
)
