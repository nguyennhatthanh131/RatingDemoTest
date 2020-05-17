# RatingDemoTest
ALT test

I. Database migration
  1. Create DB name: RatingDemoTest.
  2. Edit SQL connection string in RatingDemoContext.cs: serverName, username, password.
  3. Using Package Manager Console to migrate and update database to create table in MSSQLServer.

II. Tasks Done:
  1. Login to different services with passcode respectively.
  2. Logout
  3. Change service
  4. Submit the rating feedback include rating point and comment.

III. Tasks Todo & Improving Suggestion:
  1.  a2. Lưu lại phiên đăng nhập sau khi đăng nhập thành công => There is a column name IsStillLogin in LoginServices table - Unless the user click on "Thoát", this IsStillLogin is always keep as true since the user login. Otherwise, it will be switched to false.
  
  2.  b2. Kết thúc 1 lượt đánh giá ở trang thank you, sau 5s tự động chuyển về trang đánh giá mới. => I did not have enough time to do this part.
  
      b3. Ghi nhận kết quả đánh giá khi offline (không có kết nối): Cần có giải pháp để đảm bảo 2 yêu cầu b1 & b2 vẫn thực hiện được,(nghĩa là ko mất dữ liệu đánh giá của người dùng) => All the information of rating in b1 & b2 would be stored in localStorage as a list of ServicesRating in case of connection lost. Therefore, whenever the user goes back online, there will be the previous information to submit to server.
      
  3.  d1. Thể hiện được kinh nghiệm về cải tiến trải nghiệm người dùng 
	    d2. Thể hiện được kinh nghiệm về kiểm tra, ràng buộc dữ liệu input từ người dùng. => Only done on passcode validation when user logins to each service.
      
  4.  e. Logging: lưu trữ lịch sử khi tương tác với backend dành cho các chức năng: đăng nhập, đăng xuất, lưu thông tin đánh giá (ứng viên được tùy chọn provider). => I might user NLogger to log out some exceptions when the users login, rating etc. Moreover, in each table, I would add more column such as SQLCreateTime, SQLLastModification etc to keep track of data changing.
  
  Bonus: Due to an insufficient amount of time to develope, I decided design a really simple structure for this project as well as develop on some main features as required. If I have more time, I would seperate different business concerns into different layers like BL, DO, and DAL as well as using DependencyInjection for breaking down to multiple services and repositories. Finally, I also would like to set up a VueJS project for FE so that it would be more efficient to develope responsive UI.

