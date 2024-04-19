import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient, private router: Router) { }
  private apiUrl = "http://localhost:5218/api/Phims"
  private token = localStorage.getItem('accessToken');
  private header = new HttpHeaders().set("Authorization", `Bearer ${this.token}`);

  getallphim(): Observable<any> {
    const url = `${this.apiUrl}/getallphim`;
    return this.http.get(url, { headers: this.header })

    // .pipe(
    //   catchError((error) => {
    //     // if (error.status === 401) {
    //     //   this.router.navigate(['/login']);
    //     // }
    //     return throwError(() => new Error(error));
    //   })
    // );

  }

}
