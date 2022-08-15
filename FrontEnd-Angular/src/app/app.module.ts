import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { GridModule } from '@progress/kendo-angular-grid';
import { RippleModule } from '@progress/kendo-angular-ripple';
import { AppComponent } from './app.component';
import { SigninComponent } from './components/signin/signin.component';
import { RegisterComponent } from './components/register/register.component';
import { AngularMaterialModule } from './angular-material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { KendouiComponent } from './components/kendoui/kendoui.component';
import { TaskComponent } from './components/task/task.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';
import { LoginGuard } from './helpers/login.guard';
import { LoginService } from './services/login.service';

@NgModule({
  declarations: [
    AppComponent,
    TaskComponent,
    SigninComponent,
    RegisterComponent,
    KendouiComponent
  ],
  imports: [
    FlexLayoutModule,
    BrowserModule,
    GridModule,
    FormsModule, ReactiveFormsModule,
    AngularMaterialModule,
    BrowserAnimationsModule,
    RippleModule,
    ButtonsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [LoginService,LoginGuard],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]

})
export class AppModule { }
