import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SigninComponent } from './components/signin/signin.component';
import { RegisterComponent } from './components/register/register.component';
import { KendouiComponent } from './components/kendoui/kendoui.component';
import { LoginGuard } from './helpers/login.guard';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'signin'  },
  { path: 'signin', component: SigninComponent },
  { path: 'kendo', component: KendouiComponent,canActivate: [LoginGuard] },
  { path: 'register', component: RegisterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
