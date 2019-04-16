import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavSideMenuComponent } from './nav-side-menu/nav-side-menu.component';
import { NavTopMenuComponent } from './nav-top-menu/nav-top-menu.component';
import { HomeComponent } from './home/home.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';

import { CustomersClient, ProductsClient } from './northwind-traders-api';
import { AppRoutingModule } from './/app-routing.module';
import { ProductsComponent } from './products/products.component';

import { ModalModule } from 'ngx-bootstrap/modal';
import { FirstLetterUpperCasePipe } from '../pipes/first-letter-upper-case.pipe';

const modules = [
  BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
  HttpClientModule,
  FormsModule,
  AppRoutingModule,
  ModalModule.forRoot()
];
const components = [
  AppComponent,
  NavTopMenuComponent,
  NavSideMenuComponent,
  HomeComponent,
  ProductsComponent,
  CustomersComponent,
  CustomerDetailComponent
];
const pipes = [FirstLetterUpperCasePipe];

@NgModule({
  declarations: [...components, ...pipes],
  imports: [...modules],
  providers: [CustomersClient, ProductsClient],
  entryComponents: [CustomerDetailComponent],
  bootstrap: [AppComponent]
})
export class AppModule {}
