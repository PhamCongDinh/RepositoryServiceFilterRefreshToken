import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, catchError, of, switchMap, throwError } from 'rxjs';
import { AuthenService } from './authen.service';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {

  constructor(private auth: AuthenService) { }

  // // private handleAuthError(err: HttpErrorResponse): Observable<any> {
  // //   const data = {
  // //     "accessToken": localStorage.getItem("accessToken"),
  // //     "refreshToken": localStorage.getItem("refreshToken")
  // //   }
  // //   if (err.status === 401 || err.status === 403) {
  // //     this.auth.refreshToken(data).subscribe(
  // //       Response => {
  // //         localStorage.setItem("accessToken", Response.accessToken);
  // //         localStorage.setItem("refreshToken", Response.refreshToken);

  // //       }

  // //     )
  // //     return of(err.message);
  // //   }
  // //   return throwError(err);
  // // }
  // private token = localStorage.getItem('accessToken');

  // intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
  //   const authReq = req.clone({ headers: req.headers.set("Authorization", `Bearer ${this.token}`) });
  //   return next.handle(authReq).pipe(catchError(x => this.handleAuthError(x)));
  // }




  private handleAuthError(err: HttpErrorResponse, req: HttpRequest<any>, next: HttpHandler): Observable<any> {
    const data = {
      "accessToken": localStorage.getItem("accessToken"),
      "refreshToken": localStorage.getItem("refreshToken")
    }
    if (err.status === 401 || err.status === 403) {
      return this.auth.refreshToken(data).pipe(
        switchMap((Response: any) => {
          localStorage.setItem("accessToken", Response.accessToken);
          localStorage.setItem("refreshToken", Response.refreshToken);
          const authReqRepeat = req.clone({
            headers: req.headers.set("Authorization", `Bearer ${Response.accessToken}`)
          });
          return next.handle(authReqRepeat);
        }),
        catchError((refreshErr) => {
          return throwError(refreshErr);
        })
      );
    }
    return throwError(err);
  }
  private token = localStorage.getItem('accessToken');
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const authReq = req.clone({ headers: req.headers.set("Authorization", `Bearer ${this.token}`) });
    return next.handle(authReq).pipe(catchError(x => this.handleAuthError(x, req, next)));
  }
}
