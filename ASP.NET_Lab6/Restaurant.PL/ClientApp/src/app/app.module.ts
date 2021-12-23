import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {DataService} from "./data.service";
import {HomeComponent} from './home/home.component';
import {MealComponent} from "./meal/meal.component";
import {NewMealComponent} from "./new-meal/new-meal.component";
import {OrdersHistoryComponent} from "./orders-history/orders-history.component";
import {OrderComponent} from "./order/order.component";
import {MakeOrderComponent} from "./make-order/make-order.component";
import {LoadingComponent} from "./loading/loading.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    MealComponent,
    NewMealComponent,
    OrdersHistoryComponent,
    OrderComponent,
    MakeOrderComponent,
    LoadingComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'meal/:id', component: MealComponent},
      {path: 'new-meal', component: NewMealComponent},
      {path: 'orders-history', component: OrdersHistoryComponent},
      {path: 'order/:id', component: OrderComponent},
      {path: 'make-order', component: MakeOrderComponent},
    ])
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
