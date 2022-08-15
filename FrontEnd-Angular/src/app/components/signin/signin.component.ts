import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AppComponent } from 'src/app/app.component';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss'],
})
export class SigninComponent implements OnInit {
  userName!: string;
  password!: string;
  @Output() newItemEvent = new EventEmitter<boolean>();

  constructor(public service: LoginService, private router: Router) {}

  ngOnInit(): void {
    let data = this.service.checklogin();
    if (data) {
      this.newItemEvent.emit(true);

      confirm('Already logged');
      this.router.navigateByUrl('kendo');
    }
  }

  ngAfterViewInit(): void {
    // this.service.checkToken().subscribe((data: any) => {
    //   if (data.success != false) {
    //     this.router.navigateByUrl('kendo');
    //   }
    // });
  }

  Redirect() {
    let data = this.service.logindemo(this.userName, this.password);
    if (data == true) {
      this.router.navigateByUrl('kendo');
      alert('Welcome Admin');

      this.newItemEvent.emit(true);
    } else {
      alert('Incorrect user');
    }
    // this.service.login(this.userName, this.password).subscribe((data: any) => {
    //   console.log(data);

    //   window.localStorage.setItem('token', data.token);
    //   this.router.navigateByUrl('kendo');
    // });
  }
}
