import { Injector, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { FormsModule } from '@angular/forms';
import { IconFieldModule } from 'primeng/iconfield';
import { ToolbarModule } from 'primeng/toolbar';
import { ButtonModule } from 'primeng/button';
import { InputIconModule } from 'primeng/inputicon';
import { CardModule } from 'primeng/card';
import { AuthInterceptorService } from './services/auth-interceptor.service';
import { Router } from '@angular/router';
import { AuthenService } from './services/authen.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    IconFieldModule,
    ToolbarModule,
    ButtonModule,
    InputIconModule,
    CardModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useFactory: function (auth: AuthenService) {
      return new AuthInterceptorService(auth);
    },
    multi: true,
    deps: [AuthenService]
  },],
  bootstrap: [AppComponent]
})
export class AppModule { }
