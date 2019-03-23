import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { NavSideMenuComponent } from "./nav-side-menu/nav-side-menu.component";
import { NavTopMenuComponent } from "./nav-top-menu/nav-top-menu.component";
import { HomeComponent } from "./home/home.component";
import { CustomersComponent } from "./customers/customers.component";

import { CustomersClient, ProductsClient } from "./northwind-traders-api";
import { AppRoutingModule } from ".//app-routing.module";
import { ProductsComponent } from "./products/products.component";

@NgModule({
  declarations: [AppComponent, NavTopMenuComponent, NavSideMenuComponent, HomeComponent, CustomersComponent, ProductsComponent],
  imports: [BrowserModule.withServerTransition({ appId: "ng-cli-universal" }), HttpClientModule, FormsModule, AppRoutingModule],
  providers: [CustomersClient, ProductsClient],
  bootstrap: [AppComponent]
})
export class AppModule {}
