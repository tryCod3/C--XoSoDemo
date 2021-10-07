


phần mềm dùng csdl mongodb
nên hãy chuẩn bị trước ở dưới để chạy thành công!


1) tải phần mềm mongoDB-compass ở link dưới đây , để theo dõi db một cách trực tiếp , trực quan nhất
https://www.mongodb.com/try/download/community
2) nếu bạn đưuọc thông báo , không tìm thấy namespace MongoDB.Bson , hay MongoDB.Driver , hãy chuột phải vào
References ngay chổ Solution Explorer -> chọn Manage Nuget package -> choise brown -> search mongodb -> install
*
nếu không tìm thấy mongodb trong phần đó , hãy click vào icon setting -> thay thế Source = https://api.nuget.org/v3/index.json 
rồi làm lại theo bước (2)
*
3) open mongoDB-compass mới dowload , click conect , sau đó khi vào được giao diện csdl , hãy click vào chữ Connect trên cùng
ở bên trái , click disconect -> sau đó bạn hãy copy đường dẫn chỗ input text -> tìm fodel database -> tìm ConfigDb -> thay thế
NAME_CONNECT = dán đường đẫn bạn mới copy
4) run


-------------
đây là 1 chương trình demo xổ số đơn giản có sử dụng luồng:
chức năng
- mỗi ngày bạn có 1 lần chạy cho những đài có sẵn trong chương trình 
- chọn đài  và chọn ngày *đảm bảo nó dữ liệu trong db* ở DatetTimePicker , lúc này nó sẽ show ra 1 bảng đã từng thực hiện quay
- điền số , bấm check để thực hiện dò số , việc này thực hiện dựa vào đài và ngày chọn của bạn







