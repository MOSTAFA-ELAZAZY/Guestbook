# Guestbook
The Project Is .Net Core 6 With Dapper ANd FluentValidation
I Use Dapper To Run Query In DataBase 
This Is My First Time I use IT  But I preferred Use It For Learn New Way for Communication With DataBase 
and at First I think  Dapper Like Entity Fram Wrok 

******************************************************************************************************************************************

My DataBase structure Is Two Table 

1- Table For Users Have column (
Id int
Name nvarchar
Email nvarchar
Password nvarchar
Gender int
)

2- Table For Messages Have column (
Id int
Message nvarchar
IsReplay int 
UserId int Fk.Users
ServerNow Datetime DefultValue GetDate()
Status int DefultValue 1
MainMessageId  int 
)
