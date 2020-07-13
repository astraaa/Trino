CREATE TABLE Users
(
UserID int not null,
UserName nvarchar(25),
UserSurname nvarchar(25),
UserFathersName nvarchar(25),
PhoneNumber nvarchar(15),
Adress nvarchar(50),
UserGroup nvarchar(25),
/* UserAvatar */
Email nvarchar(25) not null,
PRIMARY KEY (UserID)
)

drop table Users

CREATE TABLE Teams
(
TeamID int not null,
TeamName nvarchar(25),
 /* TeamLogotype */
UserID INT references Users(UserID),
PRIMARY KEY (TeamID)
)

drop table Teams


