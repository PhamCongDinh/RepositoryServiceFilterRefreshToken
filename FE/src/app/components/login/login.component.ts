import { Component, OnInit } from '@angular/core';
import { AuthenService } from '../../services/authen.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  constructor(private auth: AuthenService, private router: Router) { }


  login(formdata: any) {
    if (formdata.valid) {
      const data = {
        "email": formdata.value.email,
        "matkhau": formdata.value.matkhau
      };
      this.auth.login(data).subscribe(
        Response => {
          alert("Đăng nhập thành công");
          console.log(Response);
          localStorage.setItem("accessToken", Response.accessToken);
          localStorage.setItem("refreshToken", Response.refreshToken);
          this.router.navigate(['home']);
        },
        Error => {
          alert("email hoặc mật khẩu không đúng!");
        }
      )
    }
  }
}
