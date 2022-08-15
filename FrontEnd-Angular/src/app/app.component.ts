import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { LoginService } from './services/login.service';
import { ThemeService } from './theme/theme.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  login = false;
  constructor(
    public service: LoginService,
    private themeService: ThemeService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.themeService.apply();

    let data = this.service.checklogin();
    if (data) {
      this.login = true;
    }
  }

  reload(data: any) {
    if (data.buton != true) {
      this.login = true;
    }
  }

  logout() {
    this.login = false;
    let data = this.service.logout();
    this.router.navigateByUrl('signin');
  }
}
