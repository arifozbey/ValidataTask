import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Users } from '../helpers/users';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  errorHandel: any;
  loginUrl: string = 'http://localhost:9480/login';
  checkTokenUrl: string = 'http://localhost:9480/checkToken';
  constructor(private http: HttpClient) {}

  logindemo(user: string, pass: string) {
    if (user == 'test' && pass == 'test') {
      window.localStorage.setItem(
        'token',
        'd23d23d2d22d22d938hd9238hd02d8203jd2d02dj802d20d'
      );
      return true;
    }
    return false;
  }

  checklogin() {
    let check = localStorage.getItem('token');
    if (check) {
      return true;
    }
    return false;
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('token');
    return true;
  }

  public login(userName: string, password: string): Observable<Users> {
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    };
    return this.http
      .post<Users>(
        this.loginUrl,
        { username: userName, password: this.Encrypt(password) },
        httpOptions
      )
      .pipe(retry(1), catchError(this.errorHandel));
  }

  public checkToken(): Observable<Users> {
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + this.GetToken(),
      }),
    };
    return this.http
      .get<Users>(this.checkTokenUrl, httpOptions)
      .pipe(retry(1), catchError(this.errorHandel));
  }

  GetToken() {
    // if (window.localStorage.getItem('token') != null) {
    //   return window.localStorage.getItem('token');
    // }
  }

  public Encrypt(password: string) {
    let keyStr: string =
      'ABCDEFGHIJKLMNOP' +
      'QRSTUVWXYZabcdef' +
      'ghijklmnopqrstuv' +
      'wxyz0123456789+/' +
      '=';

    password = password.split('+').join('|');
    //let input = escape(password);
    /* let input = password; */
    let input = encodeURI(password);
    let output = '';
    let chr1, chr2, chr3;
    let enc1, enc2, enc3, enc4;
    let i = 0;

    do {
      chr1 = input.charCodeAt(i++);
      chr2 = input.charCodeAt(i++);
      chr3 = input.charCodeAt(i++);

      enc1 = chr1 >> 2;
      enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
      enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
      enc4 = chr3 & 63;

      if (isNaN(chr2)) {
        enc3 = enc4 = 64;
      } else if (isNaN(chr3)) {
        enc4 = 64;
      }
      output =
        output +
        keyStr.charAt(enc1) +
        keyStr.charAt(enc2) +
        keyStr.charAt(enc3) +
        keyStr.charAt(enc4);
      chr1 = chr2 = chr3 = '';
      enc1 = enc2 = enc3 = enc4 = '';
    } while (i < input.length);
    //console.log("Password :" + output);
    return output;
  }
}
