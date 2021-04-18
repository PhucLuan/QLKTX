Chức năng:
- Ứng dụng quản lý thông tin sinh viên KTX
- Xác thực sinh viên ra vào KTX bằng QR code và Nhận diện gương mặt (sử dụng emguCV)
- Sinh viên đăng ký xét vào KTX thông qua google form
- Phân quyền cho nhân viên
- Lập 1 số báo cáo đơn giản: hóa đơn diện nước, hóa đơn tiền phòng
- Lập 1 số thống kê đơn giản: ds sinh viên, sinh viên chưa gia hạn hợp đồng, phòng chưa đóng tiền điện nước, sinh viên có học bổng
HD cài đặt:
- Chạy file script sql
- Debug code ở dạng x64
- Trong lần đầu chạy chương trình sẽ xuất hiện khung "connect to entity framework":
	+ Chọn server name, database, username, password (nếu có)
	+ Với server name là tên server chạy file script, database là tên database sau khi chạy script(mặc định là "DEMOQLKTX")
	+ Chọn connect
- Với những lần sử dụng sau sẽ tự động kết nối
