import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './/app-routing.module';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ProductsComponent } from './products/products.component';
import { CustomersComponent } from './customers/customers.component';
import { NavTopMenuComponent } from './nav-top-menu/nav-top-menu.component';
import { NavSideMenuComponent } from './nav-side-menu/nav-side-menu.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';

import { CustomersClient, ProductsClient } from './northwind-traders-api';

import { CamelCaseToText } from '../pipes/camel-case-to-text';

import { ModalModule } from 'ngx-bootstrap/modal';


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
const pipes = [CamelCaseToText];

@NgModule({
  declarations: [...components, ...pipes],
  imports: [...modules],
  providers: [CustomersClient, ProductsClient],
  entryComponents: [CustomerDetailComponent],
  bootstrap: [AppComponent]
})
export class AppModule {}
