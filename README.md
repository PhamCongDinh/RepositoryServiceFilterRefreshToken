- phân chia nghiệp vụ từng nơi:
  + tạo IRepository: khai báo các interface
  + tạo Repository : gọi các interface tương tác với database
  + các service: logic và xử lý thông tin truyền vào các Repository
  + các controller: truyền dữ liệu vào các service
- Action Filter: ghi lại thao tác, thông tin mà người dùng tương tác với BE
  + OnActionExecuting: ghi logg lại thông tin người dùng truyền vào
  + OnActionExecuted: ghi logg dữ liệu trả về cho người dùng
- Token: Authentication(JWT)
  + người dùng login thành công sẽ tạo ra AccessToken và RefreshToken
  + RefreshToken sẽ được update vào database của user tương ứng
  + AccessToken sẽ tồn tại trong 1 thời gian nhất định
  + Khi token hết hạn ta gọi hàm refresh để tạo mới một AccessToken khác để tránh gây khó chịu với người dùng khi pải đăng nhập lại nhiều lần
